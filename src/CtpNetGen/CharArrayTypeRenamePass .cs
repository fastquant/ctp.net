using System.Text.RegularExpressions;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;

namespace ctp.net
{
    internal class CharArrayTypeRenamePass : RenamePass
    {
        private bool isHooked;

        public override bool VisitClassDecl(Class @class)
        {
            if (!isHooked)
            {
                Driver.Generator.OnUnitGenerated += OnUnitGenerated;
                isHooked = true;
            }
            return base.VisitClassDecl(@class);
        }

        private void OnUnitGenerated(GeneratorOutput output)
        {
        }

        public override bool Rename(Declaration decl, out string newName)
        {
            if (decl.Name == "TradeID")
            {
                newName = "_TradeID";
                decl.Access = AccessSpecifier.Internal;
                return true;
            }
            //var inclass = decl.Namespace as Class;


            newName = null;
            return false;
        }
    }
}