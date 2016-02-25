using CppSharp;

namespace CtpNetGen
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleDriver.Run(new AllLibrary("ctpmissing", "CtpNetMissing"));
            ConsoleDriver.Run(new AllLibrary("thostmduserapi", "CtpNetMd"));
            ConsoleDriver.Run(new AllLibrary("thosttraderapi", "CtpNetTrader"));
        }
    }
}
