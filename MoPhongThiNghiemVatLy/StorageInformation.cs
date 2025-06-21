using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoPhongThiNghiemVatLy
{
    internal class StorageInformation
    {
        public int resistorCount;
        public int index;
        public Dictionary<int, int> data;
        public HashSet<(int, int)> dots;
        public Dictionary<int, double> resValues;
        public Dictionary<int, (double, double)> bulbData;
        public double m;
        public double n;
        public double lineHeight;

        public StorageInformation(  int _resistorCount,
                                    int _index,     
                                    Dictionary<int, int> _data, 
                                    HashSet<(int, int)> _dots,
                                    Dictionary<int, double> _resValues,
                                    Dictionary<int, (double, double)> _bulbData,
                                    double _m, 
                                    double _n,
                                    double _lineHeight) 
        {
            resistorCount = _resistorCount;
            index = _index;
            DEFINE.isCalc = false;
            data = _data.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            dots = _dots.ToHashSet();
            resValues = _resValues.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            bulbData = _bulbData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            m = _m;
            n = _n;
            lineHeight = _lineHeight;
        }

        public void ReturnValueOfCircuit()
        {
            MainWindow.Instance.resistorCount = resistorCount;
            MainWindow.Instance.index = index;
            MainWindow.Instance._seriesResistorCount = data.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            MainWindow.Instance.connectedDots = dots;
            MainWindow.Instance.resistorValues = resValues.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            MainWindow.Instance.LightData = bulbData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            MainWindow.Instance.m = m;
            MainWindow.Instance.n = n;
            MainWindow.Instance.lineHeight = lineHeight;
        }
    }
}
