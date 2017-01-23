using System.Collections.Generic;

namespace TOHU.Toolbox.Utility.AOP_UT
{
    internal class CallStacks
    {
        static private Queue<string> m_objCalls;

        internal static void Reset()
        {
            if (m_objCalls == null)
            {
                m_objCalls = new Queue<string>();
            }
            else
            {
                m_objCalls.Clear();
            }
        }

        internal static Queue<string> GetCalls() { return m_objCalls; }

        internal static void Call(string pi_sCall) { m_objCalls.Enqueue(pi_sCall); }
    }
}
