using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace YouTubeCodeGen.CodeGenerator
{
    public class MapObjectGenerator : ICodeGenerator
    {
        public MapObjectGenerator(AttributeData attributeData)
        {
        }

        public Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(TransformationContext context, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            var classText = GenerateClass(context);

            var syntaxTree = SyntaxFactory.ParseSyntaxTree(classText);

            var memberDeclaration = syntaxTree.GetRoot()
                .DescendantNodesAndSelf()
                .OfType<MemberDeclarationSyntax>()
                .First();

            var results = SyntaxFactory.SingletonList(memberDeclaration);
            return Task.FromResult(results);
        }

        private static string GenerateClass(TransformationContext context)
        {
            var semanticModel = context.SemanticModel;
            var interfaceNode = (InterfaceDeclarationSyntax)context.ProcessingNode;

            var className = interfaceNode.Identifier.ValueText.Substring(1);

            var cb = new CodeBuilder();

            cb.Write($"public sealed class {className} : {interfaceNode.Identifier.ValueText}");
            cb.StartBlock();

            foreach (var method in interfaceNode.Members.OfType<MethodDeclarationSyntax>())
                GenerateMapMethod(semanticModel, cb, method);

            cb.EndBlock();
            return cb.ToString();
        }

        private static void GenerateMapMethod(SemanticModel semanticModel, CodeBuilder cb, MethodDeclarationSyntax method)
        {
            var methodModel = semanticModel.GetDeclaredSymbol(method);

            var parameter = methodModel.Parameters[0];

            var paramName = parameter.Name;
            var paramsStr = parameter.RefKind == RefKind.In
                ? $"in {parameter.Type.Name} {paramName}"
                : $"{parameter.Type.Name} {paramName}";

            var propertiesToGet = parameter.Type.GetMembers().OfType<IPropertySymbol>();
            var returnType = methodModel.ReturnType;
            var propertiesToSet = returnType.GetMembers().OfType<IPropertySymbol>();
            var propertyNames = propertiesToSet.Join(propertiesToGet, p => p.Name, p => p.Name, (p1, p2) => p1.Name);
            cb.Write($"public {returnType.Name} {methodModel.Name}({paramsStr})");
            cb.StartBlock();
            cb.Write($"var destination = new {returnType.Name}();");
            foreach (var prop in propertyNames)
                cb.Write($"destination.{prop} = {paramName}.{prop};");

            var attributes = methodModel.GetAttributes();
            foreach (var attr in attributes.Where(x => x.AttributeClass.Name == nameof(MapProperty)))
            {
                var (source, dest) = (attr.ConstructorArguments[0], attr.ConstructorArguments[1]);
                
                cb.Write($"destination.{dest.Value.ToString()} = {paramName}.{source.Value.ToString()};");
            }

            cb.Write($"return destination;");
            cb.EndBlock();
        }
    }
}
