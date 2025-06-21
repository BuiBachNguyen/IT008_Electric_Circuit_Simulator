using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal abstract class CircuitDiagram
    {
        protected int indexer = 0;
        protected int type;
        protected double resistance, voltage, amperage, eropc; //eropc =  Equivalent resistance of parallel circuit

        public double Resistance
        {
            get { return resistance; }
            set { resistance = value; }
        }
        public double Voltage {
            get { return voltage; }
            set { voltage = value; }
        }
        public double Amperage
        {
            get { return amperage; }
            set { amperage = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public double Eropc
        {
            get { return eropc; }
            set { eropc = value; }
        }
        public int Indexer
        {
            get { return indexer; }
            set { indexer = value; }
        }

        public abstract void Caculate();
        public abstract int[] LeftRight();
        public abstract void CheckDen();
        public abstract string ShowResult();
    }
}
