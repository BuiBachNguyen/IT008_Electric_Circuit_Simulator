using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class DEFINE
    {
        //For Type of Circuit
        public const int TYPE_Res = 1;
        public const int TYPE_Node = 0;
        public const int TYPE_Ampe = -2;
        public const int TYPE_Vol = -4;
        public const int TYPE_Switch = -3;
        public const int TYPE_Light = -1;
        //For function/method 
        public const int SERIES = 1;
        public const int PARALLEL = 2;
        public const int ENDINPUT = 3;
        public const int REMOVE = 4;
        public const int UNDO = 5;
        //GLOBAL VAR
        public static bool isCalc = false;
        public static bool isRunOpening= false;
        public static bool isFirstTime = true;
    }
}
