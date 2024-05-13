using System;

namespace RSM.HCD.CSharp.Core
{
    public static class Try
    {
        public static bool Catch(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
