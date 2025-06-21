using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class Switch : CircuitDiagram
    {
        public Switch(int _i)
        {
            Indexer = _i;
            Resistance = Voltage = Amperage = 0;
            Type = DEFINE.TYPE_Switch;
        }
        public override void Caculate()
        {
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
            return $"Khóa thứ: {Indexer}\n";
        }
    }
}
