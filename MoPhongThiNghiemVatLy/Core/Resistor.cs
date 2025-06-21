using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class Resistor : CircuitDiagram
    {
        
        public Resistor(double _resistance, int _i) 
        {
            Resistance = _resistance;
            Voltage = 0;
            Amperage = 0;
            Indexer = _i;
            Type = DEFINE.TYPE_Res;
        }
        public override int[] LeftRight()
        {
            return new int[2] { 0, 0 };
        }
        public override void Caculate()
        {
            Voltage = Amperage * Resistance;
        }
        public override void CheckDen()
        {
            return;
        }
        public override string ShowResult()
        {
            return "U: " + Voltage.ToString("F3") + "\nI: " + Amperage.ToString("F3");
        }
    }
}
