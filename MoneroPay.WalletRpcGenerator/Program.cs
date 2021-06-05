using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
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
            result.Typedefs.Add(new Typedef("subaddress_index", "cryptonote::subaddress_index"));
            result.Structures.Add(new Structure("subaddress_index")
            {
                Fields = new()
                {
                    new FieldDefinition("major", "uint32_t") { InKvSerialize = true },
                    new FieldDefinition("minor", "uint32_t") { InKvSerialize = true }
                }
            });           

            var @namespace = NamespaceDeclaration(IdentifierName("MoneroPay.WalletRpc.Models"))
                .AddUsings(
                    UsingDirective(ParseName("System")),
                    UsingDirective(ParseName("System.Text.Json.Serialization")),
                    UsingDirective(ParseName("System.Collections.Generic")));

            var fieldTypeTypeSyntaxResolver = ModelGenerator.GetFieldTypeTypeSyntaxResolver(result.Typedefs, result.Structures);
            var defaultEqualsValueClauseResolver = ModelGenerator.GetDefaultEqualsValueCaluseSyntaxResolver();
            foreach (var structure in result.Structures)
            {
                @namespace = @namespace.AddMembers(
                    ModelGenerator.CreateClass(structure.Name, structure.Fields, fieldTypeTypeSyntaxResolver, defaultEqualsValueClauseResolver));
            }

            foreach (var command in result.RpcCommands)
            {
                @namespace = @namespace.AddMembers(ModelGenerator.CreateClass(command.RequestStructure.Name, command.RequestStructure.Fields, fieldTypeTypeSyntaxResolver, defaultEqualsValueClauseResolver));
                @namespace = @namespace.AddMembers(ModelGenerator.CreateClass(command.ResponseStructure.Name, command.ResponseStructure.Fields, fieldTypeTypeSyntaxResolver, defaultEqualsValueClauseResolver));
            }

            using var workspace = new AdhocWorkspace();
            var code = Formatter.Format(@namespace, workspace).ToFullString();
            Console.WriteLine(code);
        }
    }
}
