
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neetcode150
{
    public class BitManipulatiuonNeet
    {
        #region Reverse Bits 
        /*
        Extra Test Cases:
        00000000000000000000000000000100
        */
        public uint reverseBits(uint n)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                uint temp = (n & 1);
                result = (result << 1) + temp;
                n >>= 1;
            }
            return result;
        }
        #endregion

    }
}