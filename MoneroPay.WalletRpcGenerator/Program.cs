using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace MoneroPay.WalletRpcGenerator
{
    public class Program
    {
        const string WALLET_RPC_CMD_DEFS_SRC_URL = "https://raw.githubusercontent.com/monero-project/monero/master/src/wallet/wallet_rpc_server_commands_defs.h";
        public static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();
            var sourceCodeResponse = await httpClient.GetAsync(WALLET_RPC_CMD_DEFS_SRC_URL);
            sourceCodeResponse.EnsureSuccessStatusCode();
            var sourceCode = await sourceCodeResponse.Content.ReadAsStreamAsync();

            var result = RpcHeaderParser.ParseHeader(sourceCode);

            var @namespace = NamespaceDeclaration(IdentifierName("MoneroPay.WalletRpc.Models"))
                .AddUsings(
                    UsingDirective(ParseName("System")),
                    UsingDirective(ParseName("System.Text.Json.Serialization")));

            var fieldTypeTypeSyntaxResolver = ModelGenerator.GetFieldTypeTypeSyntaxResolver(ModelGenerator.NamingConvention.SnakeCase, result.Typedefs, result.Structures);
            foreach (var structure in result.Structures)
            {
                @namespace = @namespace.AddMembers(
                    ModelGenerator.CreateClass(ModelGenerator.NamingConvention.SnakeCase, structure.Name, structure.Fields, fieldTypeTypeSyntaxResolver));
            }

            foreach (var command in result.RpcCommands)
            {
                @namespace = @namespace.AddMembers(ModelGenerator.CreateClass(ModelGenerator.NamingConvention.SnakeCase,command.RequestStructure.Name, command.RequestStructure.Fields, fieldTypeTypeSyntaxResolver));
                @namespace = @namespace.AddMembers(ModelGenerator.CreateClass(ModelGenerator.NamingConvention.SnakeCase,command.ResponseStructure.Name, command.ResponseStructure.Fields, fieldTypeTypeSyntaxResolver));
            }

            using var workspace = new AdhocWorkspace();
            var code = Formatter.Format(@namespace, workspace).ToFullString();
            Console.WriteLine(code);
        }
    }
}
