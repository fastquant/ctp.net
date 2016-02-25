using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLib;

namespace SimpleLibSharp.Test
{
    public class MyCallback : SimpleCallback
    {
        public override unsafe void OnFrontConnected()
        {
            base.OnFrontConnected();
            Console.WriteLine($"{nameof(MyCallback)}::{nameof(OnFrontConnected)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lib = CSimpleLib.Create("hello");
            Console.WriteLine(lib.Value);
            lib.RegisterCallback(new MyCallback());
            var info = new Info();
            var id = new sbyte[21];
            id[0] = 12;
            id[1] = 14;
            info.TradeID = id;
            lib.RegisterInfo(info);
            lib.Init();
            Console.WriteLine(info.TradeID[0]);
            Console.WriteLine(info.TradeID[1]);
            Console.WriteLine(info.TradeID[2]);
            Console.ReadLine();
        }
    }
}
