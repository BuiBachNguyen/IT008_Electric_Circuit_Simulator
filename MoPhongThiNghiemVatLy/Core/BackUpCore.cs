using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy.Core
{
    internal class BackUpCore
    {
        public  int indexOfNode = 0;
        public  int indexOfRes = 0;
        public  int indexOfVol = 0;
        public  int indexOfAmpe = 0;
        public  int indexOfSwitch = 0;
        public  int indexOfLight = 0;
        public  List<CircuitDiagram> mainCircuit = new List<CircuitDiagram>();

        public  BackUpCore(int _indexOfNode,
                            int _indexOfRes,
                            int _indexOfVol,
                            int _indexOfAmpe,
                            int _indexOfSwitch,
                            int _indexOfLight,
                            List<CircuitDiagram> _mainCircuit)
        {
            indexOfNode = _indexOfNode;
            indexOfRes = _indexOfRes;
            indexOfVol = _indexOfVol;
            indexOfAmpe = _indexOfAmpe;
            indexOfSwitch = _indexOfSwitch;
            indexOfLight = _indexOfLight;
            mainCircuit = _mainCircuit.ToList();
        }
        public  void ReturnValue()
        {
            MainCircuit.indexOfNode = indexOfNode;
            MainCircuit.indexOfRes = indexOfRes;
            MainCircuit.indexOfVol = indexOfVol;
            MainCircuit.indexOfAmpe = indexOfAmpe;
            MainCircuit.indexOfSwitch = indexOfSwitch;
            MainCircuit.indexOfLight = indexOfLight;
            MainCircuit.mainCircuit = mainCircuit.ToList();
        }
    }

}
