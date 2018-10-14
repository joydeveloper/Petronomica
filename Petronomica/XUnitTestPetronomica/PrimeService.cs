using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestPetronomica
{
    class PrimeService
    {
        internal bool IsPrime(int v)
        {
            if(v==0)
                return false;
            else
                return true;
        }
    }
}
