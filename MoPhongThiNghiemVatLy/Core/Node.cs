using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class Node : CircuitDiagram
    {
        public Node(int _i)
        {
            Indexer = _i;
            Resistance = Voltage = Amperage = 0;
            Type = DEFINE.TYPE_Node;
        }
        public override void Caculate()
        {
            return;
        }
        public override void CheckDen()
        {
            return;
        }
        public override int[] LeftRight()
        {
            return new int[2] { 0, 0 };
        }
        public override string ShowResult()
        {
            return $"{Indexer}\n";
        }
    }
}
