using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class Ammeter : CircuitDiagram
    {
        public Ammeter(int _i)
        {
            Indexer = _i;
            Resistance = Voltage = Amperage = 0;
            Type = DEFINE.TYPE_Ampe;
        }
        public override void Caculate()
        {
            Amperage = Circuit.MainCircuitAmperage;
            return;
        }
        public override int[] LeftRight()
        {
            return new int[2] { 0, 0 };
        }
        public override void CheckDen()
        {
            return;
        }
        public override string ShowResult()
        {
            return $"I: "+ Amperage.ToString("F3");
        }

    }
}
