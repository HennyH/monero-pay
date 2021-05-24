using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace MoneroPay.WalletRpcGenerator
{
    internal static class ModelGenerator
    {
        public enum NamingConvention
        {
            SnakeCase,
            PascalCase
        }

        private static List<(Regex Regex, Func<Match, Func<string, TypeSyntax>, TypeSyntax> TypeSyntaxFactory)> GetDefaultTypeMappings(NamingConvention namingConvention)
        {
            return new()
            {
                { (new Regex("bool"), (_, _) => IdentifierName(typeof(bool).Name)) },
                { (new Regex("cryptonote::subaddress_index"), (_, _) => IdentifierName(namingConvention == NamingConvention.PascalCase ? "SubaddressIndex" : "subaddress_index")) },
                { (new Regex("int8_t"), (_, _) => IdentifierName(typeof(byte).Name)) },
                { (new Regex("int32_t"), (_, _) => IdentifierName(typeof(Int32).Name)) },
                { (new Regex("int64_t"), (_, _) => IdentifierName(typeof(Int64).Name)) },
                { (new Regex("std::string"), (_, _) => IdentifierName(typeof(string).Name)) },
                { (new Regex("unsigned"), (_, _) => IdentifierName(typeof(uint).Name)) },
                {
                    (
                        new Regex("std::list<(?<type>.*)>"),
                        (m, resolveTypeSyntax) =>
                        {
                            var itemTypeText = m.Groups["type"].Value;
                            var itemTypeSyntax = resolveTypeSyntax(itemTypeText);
                            return
                                GenericName(
                                    Identifier("List"))
                                .WithTypeArgumentList(
                                    TypeArgumentList(
                                        SingletonSeparatedList<TypeSyntax>(
                                            itemTypeSyntax)));
                        }
                    )
                },
                {
                    (
                        new Regex("std::vector<(?<type>.*)>"),
                        (m, resolveTypeSyntax) =>
                        {
                            var itemTypeText = m.Groups["type"].Value;
                            var itemTypeSyntax = resolveTypeSyntax(itemTypeText);
                            if (itemTypeSyntax == null) throw new Exception($"Could not resolve a type syntax for type {itemTypeText}");
                            return
                                GenericName(
                                    Identifier("List"))
                                .WithTypeArgumentList(
                                    TypeArgumentList(
                                        SingletonSeparatedList<TypeSyntax>(
                                            itemTypeSyntax)));
                        }
                    )
                },
                {
                    (
                        new Regex("std::set<(?<type>.*)>"),
                        (m, resolveTypeSyntax) =>
                        {
                            var itemTypeText = m.Groups["type"].Value;
                            var itemTypeSyntax = resolveTypeSyntax(itemTypeText);
                            if (itemTypeSyntax == null) throw new Exception($"Could not resolve a type syntax for type {itemTypeText}");
                            return
                                GenericName(
                                    Identifier("Set"))
                                .WithTypeArgumentList(
                                    TypeArgumentList(
                                        SingletonSeparatedList<TypeSyntax>(
                                            itemTypeSyntax)));
                        }
                    )
                }
            };
        }

        public static Func<string, TypeSyntax> GetFieldTypeTypeSyntaxResolver(NamingConvention namingConvention, IEnumerable<Typedef> typedefs, IEnumerable<Structure> structures)
        {
            var defaultTypeMappings = GetDefaultTypeMappings(namingConvention);
            var aliasToType = typedefs.ToDictionary(td => td.Alias, td => td.Type, StringComparer.OrdinalIgnoreCase);
            var nameToStructure = structures
                .GroupBy(s => s.Name)
                .Select(g =>
                {
                    var matches = g.ToList();
                    if (matches.Any(outerMatch =>
                            matches.Any(innerMatch =>
                                !outerMatch.Fields.All(outerField =>
                                    innerMatch.Fields.Any(innerField => innerField == outerField)))))
                    {
                        throw new Exception($"The structure {g.Key} was defined multiple times with conflicting field sets");
                    }
                    return matches.First();
                })
                .ToDictionary(s => s.Name, StringComparer.OrdinalIgnoreCase);

            TypeSyntax resolver(string fieldType)
            {
                foreach (var (regex, typeSyntaxFactory) in defaultTypeMappings)
                {
                    var match = regex.Match(fieldType);
                    if (!match.Success) continue;
                    return typeSyntaxFactory(match, resolver);
                }

                if (nameToStructure.TryGetValue(fieldType, out var structure))
                {
                    return IdentifierName(structure.Name);
                }

                if (aliasToType.TryGetValue(fieldType, out var aliasedType))
                {
                    return resolver(aliasedType);
                }

                throw new Exception($"Could not resolve a type syntax for type {fieldType}");
            }

            return resolver;
        }

        public static ClassDeclarationSyntax CreateClass(NamingConvention namingConvention, string name, IEnumerable<FieldDefinition> fields, Func<string, TypeSyntax?> getTypeSyntaxForFieldType)
        {
            // TODO(HH): Apply naming conventions here so that we have the original names
            // for use in the JsonProperty attribute. Also need to support defaults here which
            // we don't have parsing code for atm.

            var @class = ClassDeclaration(Identifier(name));
            // Add the public modifier: (public class X)
            @class = @class.AddModifiers(Token(SyntaxKind.PublicKeyword));

            // Add the properties for each field
            foreach (var field in fields)
            {
                var attributeList =
                    AttributeList(
                        SingletonSeparatedList<AttributeSyntax>(
                            Attribute(
                                IdentifierName("JsonProperty"))
                            .WithArgumentList(
                                AttributeArgumentList(
                                    SingletonSeparatedList<AttributeArgumentSyntax>(
                                        AttributeArgument(
                                            LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                Literal(field.Name))))))));
                var fieldTypeSyntax = getTypeSyntaxForFieldType(field.Type);
                if (fieldTypeSyntax == null) throw new Exception($"Unable to determine type syntax for field type {field.Type}");
                var property =
                    PropertyDeclaration(
                        fieldTypeSyntax,
                        Identifier(field.Name))
                    .WithAccessorList(
                        AccessorList(
                            List<AccessorDeclarationSyntax>(
                                new AccessorDeclarationSyntax[] {
                                    AccessorDeclaration(
                                        SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(
                                        Token(SyntaxKind.SemicolonToken)),
                                    AccessorDeclaration(
                                        SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(
                                        Token(SyntaxKind.SemicolonToken))
                                }
                            )
                        )
                    )
                    .WithAttributeLists(SingletonList<AttributeListSyntax>(attributeList));
                @class = @class.AddMembers(property);
            }

            return @class;
        }
    }
}