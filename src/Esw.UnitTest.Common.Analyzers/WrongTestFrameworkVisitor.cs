namespace Esw.UnitTest.Common.Analyzers
{
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class WrongTestFrameworkVisitor : CSharpSyntaxVisitor<bool>
    {
        public override bool VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (node.AttributeLists.SelectMany(l => l.Attributes).Any(a => a.Name.ToString() == "TestMethod"))
            {
                return true;
            }

            return false;
        }
    }
}