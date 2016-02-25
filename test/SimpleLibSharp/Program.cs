using CppSharp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ctp.net;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Passes;

namespace SimpleLibSharp
{
    internal class MyPass : TranslationUnitPass
    {
        public override bool VisitClassDecl(Class @class)
        {
            if (@class.Name.EndsWith("Info"))
            {
                foreach (var ctor in @class.Constructors)
                    ctor.ExplicitlyIgnore();

              //  @class.Destructors
                //foreach (var f in @class.Fields.Where(f => f.Type.Desugar() is ArrayType))
                //{
                //    var t = f.Type.Desugar() as ArrayType;
                //    if (t.SizeType == ArrayType.ArraySize.Constant)
                //    {
                //        f.Access = AccessSpecifier.Internal;
                //        f.Name = f.Name+"CharArray";
                //    }
                //}
            }
            return base.VisitClassDecl(@class);
        }
    }

    class SimpleLibrary : ILibrary
    {
        public static string DllSrcPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "SimpleLib");
        public static string ProjPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", ".."));

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            //ctx.IgnoreClassWithName("SimpleCallback");
            //ctx.IgnoreClassWithName("Info");
            ctx.IgnoreClassMethodWithName("Info", "Info");
        }

        public void Setup(Driver driver)
        {
            var options = driver.Options;
            options.StripLibPrefix = false;
            options.SharedLibraryName = "libsimple";
            options.LibraryName = "SimpleLib";
            options.addIncludeDirs(DllSrcPath);
            options.Headers.Add("SimpleLib.h");
            options.GenerateClassMarshals = true;
            //options.CodeFiles.Add(Path.Combine(ProjPath, "MySimpleLib.cs"));
            //options.CompileCode = true;
        }

        public void SetupPasses(Driver driver)
        {
            //driver.AddTranslationUnitPass(new FieldToPropertyPass());
           // driver.AddTranslationUnitPass(new CharArrayTypeRenamePass());
            driver.AddTranslationUnitPass(new MyPass());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SimpleLibrary.DllSrcPath);
            ConsoleDriver.Run(new SimpleLibrary());
        }
    }
}
