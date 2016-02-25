using System;
using System.Runtime.InteropServices;
using System.Text;
using CppSharp.Runtime;

namespace SimpleLib
{
    public unsafe partial class SimpleCallback
    {
        //public SimpleCallback()
        //{
        //    __Instance = Marshal.AllocHGlobal(4);
        //    __ownsNativeInstance = true;
        //    NativeToManagedMap[__Instance] = this;
        //    // Internal.ctor_0((__Instance + __PointerAdjustment));
        //}
    }
    public unsafe partial class Info
    {
        public Info()
        {
            __Instance = Marshal.AllocHGlobal(56);
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
           // Internal.ctor_0((__Instance + __PointerAdjustment));
        }

        public string TradeId {
            get { return Encoding.Default.GetString((byte[]) (Array) TradeID); }
            set
            {
                TradeID = (sbyte[]) (Array)Encoding.Default.GetBytes(value);
            }
        }

        public string InvestorId
        {
            get
            {
                return Encoding.Default.GetString((byte[])(Array)InvestorID);
            }
            set
            {
                InvestorID = (sbyte[])(Array)Encoding.Default.GetBytes(value);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public partial class CSimpleLib
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}