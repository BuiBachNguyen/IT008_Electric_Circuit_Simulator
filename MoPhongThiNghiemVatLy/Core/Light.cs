using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class Light : CircuitDiagram
    {
        private double power;
        public double Power
        {
            get { return power; }
            set { power = value; }
        }
        public Light(int _i, double[] data)
        {
            Indexer = _i;
            Resistance = data[1];
            Amperage = Voltage = 0;
            Power = data[0];
            Type = DEFINE.TYPE_Light;
        }
        public Light(int _i, double _r, double _p)
        {
            Indexer = _i;
            Resistance = _r;
            Amperage = Voltage = 0;
            Power = _p;
            Type = DEFINE.TYPE_Light;
        }
        public override void Caculate()
        {
            Voltage = Amperage * Resistance;
        }
        public override string ShowResult()
        {
            string res = "Độ sáng: " + (Voltage / Math.Sqrt(Power * Resistance)).ToString("F3");
            return res;
        }
        public override int[] LeftRight()
        {
            return new int[2] { 0, 0 };
        }
        public override void CheckDen()
        {
            double ratedVoltage = Math.Sqrt(Power*Resistance);
            double percent = Voltage / ratedVoltage;
            MainWindow.Instance.LightPercentData.Add(Indexer,  percent);
        }
    }
}
