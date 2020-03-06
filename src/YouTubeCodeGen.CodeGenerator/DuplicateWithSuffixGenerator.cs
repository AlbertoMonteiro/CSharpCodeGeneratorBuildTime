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
    public class DuplicateWithSuffixGenerator : ICodeGenerator
    {
        private readonly string suffix;

        public DuplicateWithSuffixGenerator(AttributeData attributeData)
        {
            suffix = (string)attributeData.ConstructorArguments[0].Value;
        }

        public Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(TransformationContext context, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            // Our generator is applied to any class that our attribute is applied to.
            var applyToClass = (ClassDeclarationSyntax)context.ProcessingNode;

            var tree = SyntaxFactory.ParseSyntaxTree($"public class OlaMundo{suffix} {{}}");

            var classDeclaration = tree.GetRoot().DescendantNodes().OfType<MemberDeclarationSyntax>().First();

            // Apply a suffix to the name of a copy of the class.
            //var copy = applyToClass.WithIdentifier(SyntaxFactory.Identifier(applyToClass.Identifier.ValueText + suffix));

            // Return our modified copy. It will be added to the user's project for compilation.
            //var results = SyntaxFactory.SingletonList<MemberDeclarationSyntax>(copy);
            var results = SyntaxFactory.SingletonList(classDeclaration);
            return Task.FromResult(results);
        }
    }
}
