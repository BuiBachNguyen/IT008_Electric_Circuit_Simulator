using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoPhongThiNghiemVatLy
{
    internal class Volmeter : CircuitDiagram
    {
        int nodeLeft;
        int nodeRight;
        public Volmeter(int _l, int _r, int _i)
        {
            if (_l <= _r)
            {
                nodeLeft = _l;
                nodeRight = _r;
            }
            else
            {
                nodeLeft = _r;
                nodeRight = _l;
            }
            Resistance = Voltage = Amperage = 0;
            Indexer = _i;
            Type = DEFINE.TYPE_Vol;
        }
        public Volmeter(Volmeter other)
        {
            nodeLeft = other.nodeLeft;
            nodeRight = other.nodeRight;
            Resistance = Voltage = Amperage = 0;
            Indexer = other.Indexer;
            Type = DEFINE.TYPE_Vol;
        }
        public override void Caculate()
        {
            Voltage = 0;
            bool isReach = false;
            for (int i = 0; i < MainCircuit.mainCircuit.Count; i++)
            {
                if (MainCircuit.mainCircuit[i].Type == DEFINE.TYPE_Node)
                {
                    if (MainCircuit.mainCircuit[i].Indexer == nodeRight) return;
                    if (MainCircuit.mainCircuit[i].Indexer == nodeLeft) isReach = true;
                }
                if (isReach == true)
                {
                    if (i + 1 < MainCircuit.mainCircuit.Count)
                    {
                        if ((MainCircuit.mainCircuit[i].Type == DEFINE.TYPE_Res
                            || MainCircuit.mainCircuit[i].Type == DEFINE.TYPE_Light)
                            && MainCircuit.mainCircuit[i + 1].Type == DEFINE.TYPE_Node)
                        {
                            Voltage += MainCircuit.mainCircuit[i].Voltage;
                        }
                    }
                }
            }
        }
        public override int[] LeftRight()
        {
            int[] res = new int[2];
            res[0] = nodeLeft;
            res[1] = nodeRight;
            return res;
        }
        public override void CheckDen()
        {
            return;
        }
        public override string ShowResult()
        {
            return $"V : " + voltage.ToString("F3");
        }
    }
}
