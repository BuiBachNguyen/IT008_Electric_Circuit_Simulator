using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class IndexForShowResult
    {
        public static int indexOfRes = 0;
        public static int indexOfVol = 0;
        public static int indexOfAmpe = 0;
        public static int indexOfLight = 0;
        public static int indexOfKey = 0;

        public static void Reset()
        { 
            indexOfRes
            = indexOfAmpe
            = indexOfVol
            = indexOfLight 
            = indexOfKey = 0;
        }
    }
}
