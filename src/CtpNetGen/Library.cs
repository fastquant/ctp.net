using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;
using CppSharp.Types;

namespace CtpNetGen
{
    class LibraryConst
    {
        public static string ProjDir =
            Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", ".."));
        public static string CtpIncludeDir = Path.Combine(ProjDir, "ctp", "include");
        public static string LibExt => Platform.IsWindows ? "dll" : Platform.IsMacOS ? "dylib" : "so";
        public static string MdLibName => "thostmduserapi";
        public static string TradeLibName => "thosttraderapi";
        public static string MissingLibName => "ctpmissing";
        public static string MdLibFileName => $"{MdLibName}.{LibExt}";
        public static string TradeLibFileName => $"{TradeLibName}.{LibExt}";
        public static string MissingLibFileName => $"{MissingLibName}.{LibExt}";

    }

    class AllLibrary : ILibrary
    {
        private string sharedLibName;
        private string outputDir;

        public AllLibrary(string sharpedLibName, string outputDir)
        {
            this.sharedLibName = sharpedLibName;
            this.outputDir = outputDir;
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Setup(Driver driver)
        {
            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.SharedLibraryName = this.sharedLibName;
            options.LibraryName = "CtpNet";
            options.addIncludeDirs(LibraryConst.CtpIncludeDir);
            options.Headers.Add(Path.Combine(LibraryConst.CtpIncludeDir, "ctpmissing.h"));
            options.Headers.Add(Path.Combine(LibraryConst.CtpIncludeDir, "ThostFtdcTraderApi.h"));
            options.Headers.Add(Path.Combine(LibraryConst.CtpIncludeDir, "ThostFtdcMdApi.h"));
            options.OutputNamespace = "CtpNet";
            options.OutputDir = this.outputDir;
            options.Verbose = true;
        }

        public void SetupPasses(Driver driver)
        {
        }
    }
}