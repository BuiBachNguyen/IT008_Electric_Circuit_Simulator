using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Drawing;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Windows.Markup;
using MoPhongThiNghiemVatLy.Core;

namespace MoPhongThiNghiemVatLy
{
    internal class MenuStrip
    {

        private MainWindow mainWindow;
        public MenuStrip(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        //DEFINE
        private string currentFilePath = string.Empty;
        private string currentPicturesPath = string.Empty;

        public void New_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance.isSave == false)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Bạn có muốn lưu lại kết quả không?",
                    "Thông báo",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFile_Click(sender, e);
                    CreateNew();
                }
                else if (result == MessageBoxResult.No)
                {
                    CreateNew();
                }
            }
            else
            {
                CreateNew();
            }

        }

        public void CreateNew()
        {
            var oldWindow = Application.Current.MainWindow;
            RefreshData();
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            oldWindow?.Close();
        }

        private void RefreshData()
        {
            ToolbarButton.history.Clear();
            ToolbarButton.redoStack.Clear();
            MainCircuit.indexOfNode = 0;
            MainCircuit.indexOfRes = 0;
            MainCircuit.indexOfVol = 0;
            MainCircuit.indexOfAmpe = 0;
            MainCircuit.indexOfSwitch = 0;
            MainCircuit.indexOfLight = 0;

            MainCircuit.mainCircuit = new List<CircuitDiagram>();
            MainCircuit.history = new Stack<BackUpCore>();  // Lịch sử các hành động (cho undo)
            MainCircuit.redoStack = new Stack<BackUpCore>();  // Lịch sử các hành động đã undo (cho redo)

            Circuit.MainCurcuitVoltage = 0;
            Circuit.MainCircuitEROC = 0;
            Circuit.MainCircuitAmperage = 0;
        }

        public void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance.isSourceAdded == true && MainWindow.Instance.isSave == false)
            {
                // Hiển thị MessageBox để hỏi người dùng có muốn lưu không
                MessageBoxResult result = MessageBox.Show(
                    "Bạn có muốn lưu lại kết quả không?",
                    "Thông báo",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFile_Click(sender, e);
                    CreateNew();
                }
                else if (result == MessageBoxResult.No)
                {
                    // Nếu người dùng chọn No, không lưu, tiếp tục tạo mới
                    CreateNew();
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Open JSON File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                LoadToFile(filePath);
                currentFilePath = filePath;
                MainWindow.Instance.isSave = true;
                // Đọc nội dung file JSON (bạn có thể sử dụng Json.NET hoặc các phương thức khác để parse JSON)
            }
        }
        public void LoadToFile(string filePath)
        {

            string jsonContent = File.ReadAllText(filePath);
            dynamic circuitData = JsonConvert.DeserializeObject(jsonContent);
            try
            {
                // Khôi phục biến toàn cục
                MainWindow.Instance.iOfLight = (int)circuitData.GlobalVariables.iofLight;
                MainWindow.Instance.checkDotForVolt = (bool)circuitData.GlobalVariables.checkDotForVolt;
                MainWindow.Instance.isSourceAdded = (bool)circuitData.GlobalVariables.isSourceAdded;
                MainWindow.Instance.lineHeight = (double)circuitData.GlobalVariables.lineHeight;
                MainWindow.Instance.m = (double)circuitData.GlobalVariables.m;
                MainWindow.Instance.n = (double)circuitData.GlobalVariables.n;
                MainWindow.Instance.xA = (double)circuitData.GlobalVariables.xA;
                MainWindow.Instance.yA = (double)circuitData.GlobalVariables.yA;
                MainWindow.Instance.xB = (double)circuitData.GlobalVariables.xB;
                MainWindow.Instance.yB = (double)circuitData.GlobalVariables.yB;
                MainWindow.Instance.lightAcp = (bool)circuitData.GlobalVariables.lightAcp;
                MainWindow.Instance.areDotsDrawn = (bool)circuitData.GlobalVariables.areDotsDrawn;
                MainWindow.Instance.voltNum = (int) circuitData.GlobalVariables.voltNum;


                // Khôi phục đoạn thẳng AB
                if (circuitData.LineAB != null)
                {
                    MainWindow.Instance.AB = new Line
                    {
                        X1 = (double)circuitData.LineAB.x1,
                        Y1 = (double)circuitData.LineAB.y1,
                        X2 = (double)circuitData.LineAB.x2,
                        Y2 = (double)circuitData.LineAB.y2
                    };
                }

                MainWindow.Instance.InorderToCal = ((JArray)circuitData.CircuitComponents.InorderToCal).ToObject<List<char>>();
                if (circuitData.GlobalVariables.connectedDots is JArray connectedDotsArray)
                {
                    MainWindow.Instance.connectedDots = new HashSet<(int, int)>(
                        connectedDotsArray.Select(pair => (
                            (int)pair["Item1"],  // Lấy giá trị Item1
                            (int)pair["Item2"]   // Lấy giá trị Item2
                        ))
                    );
                }
                else
                {
                    MainWindow.Instance.connectedDots = new HashSet<(int, int)>();
                }
                if (circuitData.GlobalVariables.indexofParallel is JArray indexofParallelArray)
                {
                    MainWindow.Instance.indexofParallel = new HashSet<(int, int)>(
                        indexofParallelArray.Select(pair => (
                            (int)pair["Item1"],  // Lấy giá trị Item1
                            (int)pair["Item2"]   // Lấy giá trị Item2
                        ))
                    );
                }
                else
                {
                    MainWindow.Instance.indexofParallel = new HashSet<(int, int)>();
                }
                MainWindow.Instance.addedHeight = (int)circuitData.GlobalVariables.addedHeight; 
                MainWindow.Instance.numKey = (int)circuitData.GlobalVariables.numKey;
                MainWindow.Instance.isKey = (bool) circuitData.GlobalVariables.isKey;
                // Khôi phục resistorValues
                if (circuitData.CircuitComponents.resistorValues is JObject jResistorValues)
                {
                    MainWindow.Instance.resistorValues = jResistorValues
                        .Properties()
                        .ToDictionary(p => int.Parse(p.Name), p => (double)p.Value);
                }
                else if (circuitData.CircuitComponents.resistorValues is JArray jArrayResistorValues)
                {
                    MainWindow.Instance.resistorValues = jArrayResistorValues
                        .ToObject<Dictionary<int, double>>();
                }

                // Khôi phục seriesResistorCount
                if (circuitData.CircuitComponents._seriesResistorCount is JObject jSeriesResistorCount)
                {
                    MainWindow.Instance._seriesResistorCount = jSeriesResistorCount
                        .Properties()
                        .ToDictionary(p => int.Parse(p.Name), p => (int)p.Value);
                }
                else if (circuitData.CircuitComponents._seriesResistorCount is JArray jArraySeriesResistorCount)
                {
                    MainWindow.Instance._seriesResistorCount = jArraySeriesResistorCount
                        .ToObject<Dictionary<int, int>>();
                }
                if (circuitData.GlobalVariables?.isLightOn != null)
                {
                    if (circuitData.GlobalVariables.isLightOn is JObject jIsLightOn)
                    {
                        MainWindow.Instance.isLightOn = jIsLightOn
                            .Properties()
                            .ToDictionary(p => int.Parse(p.Name), p => (bool)p.Value);
                    }
                    else if (circuitData.GlobalVariables.isLightOn is JArray jArrayIsLightOn)
                    {
                        MainWindow.Instance.isLightOn = jArrayIsLightOn
                            .ToObject<Dictionary<int, bool>>();
                    }
                    else
                    {
                        MainWindow.Instance.isLightOn = new Dictionary<int, bool>();
                    }
                }
                else
                {
                    MainWindow.Instance.isLightOn = new Dictionary<int, bool>();
                }
                MainWindow.Instance.index = MainWindow.Instance._seriesResistorCount.Count();
                int MaxHeight = 1;
                foreach (var kvp in MainWindow.Instance._seriesResistorCount)
                    if (kvp.Value > MaxHeight)
                        MaxHeight = kvp.Value;
                MainWindow.Instance.hadVoltmeter = (bool)circuitData.GlobalVariables.hadVoltmeter;
                MainWindow.Instance.resistorCount = (int)circuitData.CircuitComponents.resistorCount;
                MainWindow.Instance.seriesResistorCount = (int)circuitData.CircuitComponents.seriesResistorCount;
                MainWindow.Instance.parallelResistorCount = (int)circuitData.CircuitComponents.parallelResistorCount;
                MainWindow.Instance.LightData = ((JArray)circuitData.CircuitComponents.LightData)
    .ToObject<List<dynamic>>()
    .ToDictionary(
        item => (int)item.index,
        item => ((double)item.power, (double)item.resistance)
    );

                MainWindow.Instance.LightPercentData = ((JObject)circuitData.CircuitComponents.LightPercentData)
    .ToObject<Dictionary<int, double>>();


                MainWindow.Instance.LightStatus = ((JArray)circuitData.CircuitComponents.LightStatus)
                    .ToObject<List<dynamic>>()
                    .ToDictionary(
                        item => ParsePoint((string)item.point), // Chuyển đổi `dynamic` thành `string` rồi parse thành `Point`
                        item => (bool)item.isBroken
                    );


                MainWindow.Instance.LightPosition = ((JArray)circuitData.CircuitComponents.LightPosition)
                    .Select(point => ParsePoint(point.ToString()))
                    .ToList();

                MainWindow.Instance.KeyPosition = ((JArray)circuitData.CircuitComponents.KeyPosition)
                    .Select(point => ParsePoint(point.ToString()))
                    .ToList();

                MainWindow.Instance.TongHopCacDiem = ((JArray)circuitData.CircuitComponents.TongHopCacDiem)
                    .Select(point => ParsePoint(point.ToString()))
                    .ToList();

                MainWindow.Instance.beginEparallel = ((JArray)circuitData.CircuitComponents.beginEparallel)
                    .Select(point => ParsePoint(point.ToString()))
                    .ToList();

                MainWindow.Instance.endEparallel = ((JArray)circuitData.CircuitComponents.endEparallel)
                    .Select(point => ParsePoint(point.ToString()))
                    .ToList();

                MainWindow.Instance.fusion = ((JObject)circuitData.CircuitComponents.fusion)
                    .ToObject<Dictionary<string, JArray>>()
                    .ToDictionary(
                        kv => ParsePoint(kv.Key),
                        kv => kv.Value.Select(point => ParsePoint(point.ToString())).ToList()
                    );

                // Khôi phục UI Elements
                MainWindow.Instance.labels = ((JArray)circuitData.UIElements.labels)
                    .Select(label => new TextBlock { Text = (string)label })
                     .ToList();

                MainWindow.Instance.sourceElements = ((JArray)circuitData.UIElements.sourceElements)
                    .Select(name => CreateUIElementByName((string)name))
                    .ToList();

                MainWindow.Instance.LightBulbs = ((JArray)circuitData.UIElements.LightBulbs)
                    .Select(name => CreateUIElementByName((string)name))
                    .ToList();

                MainWindow.Instance.ampeList = ((JArray)circuitData.UIElements.ampeList)
                    .Select(name => CreateUIElementByName((string)name))
                    .ToList();

                // Load các biến từ MainCircuitData
                dynamic mainCircuitData = circuitData.MainCircuitData;
                Circuit.MainCircuitEROC = mainCircuitData.mainCircuitEROC;
                Circuit.MainCircuitAmperage = mainCircuitData.mainCircuitAmperage;
                Circuit.MainCurcuitVoltage = mainCircuitData.mainCircuitVoltage; 

                // Khôi phục danh sách mainCircuit
                MainCircuit.mainCircuit = new List<CircuitDiagram>();
                foreach (var item in (IEnumerable<dynamic>)mainCircuitData.mainCircuit)
                {
                    MainCircuit.mainCircuit.Add(CreateCircuitDiagramFromJson(item));
                    MainCircuit.mainCircuit[MainCircuit.mainCircuit.Count - 1].Resistance = item.resistance;
                    MainCircuit.mainCircuit[MainCircuit.mainCircuit.Count - 1].Voltage = item.voltage;
                    MainCircuit.mainCircuit[MainCircuit.mainCircuit.Count - 1].Amperage = item.amperage;
                    MainCircuit.mainCircuit[MainCircuit.mainCircuit.Count - 1].Eropc = item.eropc;
                }

                
                // Khôi phục các chỉ số
                MainCircuit.indexOfNode = mainCircuitData.indexOfNode;
                MainCircuit.indexOfRes = mainCircuitData.indexOfRes;
                MainCircuit.indexOfVol = mainCircuitData.indexOfVol;
                MainCircuit.indexOfAmpe = mainCircuitData.indexOfAmpe;
                MainCircuit.indexOfSwitch = mainCircuitData.indexOfSwitch;
                MainCircuit.indexOfLight = mainCircuitData.indexOfLight;
                // Cập nhật giao diện canvas
                Drawing.UpdateCircuitAfterAdd(MainWindow.Instance.CircuitCanvas, MaxHeight);
                MainWindow.Instance.isSave = true;
                Drawing.UpdateResistorValuesDisplay();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in LoadToFile: {ex.Message}");
            }
        }
        private Point ParsePoint(string pointString)
        {
            var coordinates = pointString.Split(',').Select(double.Parse).ToArray();
            return new Point(coordinates[0], coordinates[1]);
        }
        // Phương thức hỗ trợ
        private UIElement CreateUIElementByName(string name)
        {
            // Tạo UIElement tương ứng dựa vào tên lớp
            switch (name)
            {
                case "Rectangle": return new Rectangle();
                case "Ellipse": return new Ellipse();
                case "Line": return new Line();
                default: return new UIElement();
            }
        }

        private Ellipse CreateEllipseFromJson(dynamic json)
        {
            // Tạo lại Ellipse từ thông tin JSON
            return new Ellipse
            {
                Width = (double)json["Width"],
                Height = (double)json["Height"],
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString((string)json["Fill"]))
            };
        }

        private CircuitDiagram CreateCircuitDiagramFromJson(dynamic json)
        {
            int type = json.type; // Kiểm tra null cho type

            switch (type)
            {
                case DEFINE.TYPE_Res:
                    return new Resistor(
                        (double)json.resistance,
                        (int)(json.indexer ?? 0) // Kiểm tra null và gán giá trị mặc định 0
                    );

                case DEFINE.TYPE_Ampe:
                    return new Ammeter((int)(json.indexer ?? 0)); // Kiểm tra null và gán giá trị mặc định 0

                case DEFINE.TYPE_Light:
                    return new Light(
                        (int)(json.indexer ?? 0),
                        (double)(json.resistance ?? 0), // Kiểm tra null cho resistance
                        (double)(json.power ?? 0) // Kiểm tra null cho eropc
                    );

                case DEFINE.TYPE_Node:
                    return new Node((int)(json.indexer ?? 0)); // Kiểm tra null cho indexer

                case DEFINE.TYPE_Vol:
                    // Kiểm tra nếu LeftRight có dữ liệu và tách ra thành nodeLeft và nodeRight
                    var leftRight = json.leftright as JArray;
                    int nodeLeft = (leftRight != null && leftRight.Count > 0) ? (int)(leftRight[0] ?? 0) : 0;
                    int nodeRight = (leftRight != null && leftRight.Count > 1) ? (int)(leftRight[1] ?? 0) : 0;

                    // Tạo đối tượng Volmeter
                    return new Volmeter(
                        nodeLeft,  // nodeLeft được lấy từ LeftRight[0]
                        nodeRight, // nodeRight được lấy từ LeftRight[1]
                        (int)(json.indexer ?? 0) // Kiểm tra null cho indexer
                    );
                case DEFINE.TYPE_Switch:
                    return new Switch(
                        (int)(json.indexer ?? 0)
                    );
                default:
                    throw new InvalidOperationException($"Unknown circuit diagram type: {type}");
            }
        }
        public void SaveToFile(string filePath)
        {
            MainWindow.Instance.isSave = true;
            try
            {
                var circuitData = new
                {
                    GlobalVariables = new
                    {
                        iofLight = MainWindow.Instance.iOfLight,
                        checkDotForVolt = MainWindow.Instance.checkDotForVolt,
                        isSourceAdded = MainWindow.Instance.isSourceAdded,
                        lineHeight = MainWindow.Instance.lineHeight,
                        m = MainWindow.Instance.m,
                        n = MainWindow.Instance.n,
                        xA = MainWindow.Instance.xA,
                        yA = MainWindow.Instance.yA,
                        xB = MainWindow.Instance.xB,
                        yB = MainWindow.Instance.yB,
                        lightAcp = MainWindow.Instance.lightAcp,
                        isVoltmeterMode = MainWindow.Instance.isVoltmeterMode,
                        areDotsDrawn = MainWindow.Instance.areDotsDrawn,
                        connectedDots = MainWindow.Instance.connectedDots.ToList(),
                        dotDegrees = MainWindow.Instance.dotDegrees.Select(kv => new { dot = kv.Key, degree = kv.Value }).ToList(),
                        indexDot = MainWindow.Instance.indexDot.ToDictionary(kv => kv.Key.ToString(), kv => kv.Value),
                        voltNum = MainWindow.Instance.voltNum,
                        indexofParallel = MainWindow.Instance.indexofParallel.ToList(),
                        addedHeight = MainWindow.Instance.addedHeight,
                        hadVoltmeter = MainWindow.Instance.hadVoltmeter,
                        isLightOn = MainWindow.Instance.isLightOn,
                        numKey = MainWindow.Instance.numKey,
                        isKey = MainWindow.Instance.isKey
                    },
                    LineAB = MainWindow.Instance.AB != null ? new
                    {
                        x1 = MainWindow.Instance.AB.X1,
                        y1 = MainWindow.Instance.AB.Y1,
                        x2 = MainWindow.Instance.AB.X2,
                        y2 = MainWindow.Instance.AB.Y2
                    } : null,
                    Dots = new
                    {
                        dotIndex = MainWindow.Instance.dotIndex,
                        checkDots = MainWindow.Instance.checkDots
                    },
                    CircuitComponents = new
                    {
                        InorderToCal = MainWindow.Instance.InorderToCal,
                        resistorValues = MainWindow.Instance.resistorValues,
                        _seriesResistorCount = MainWindow.Instance._seriesResistorCount,
                        resistorCount = MainWindow.Instance.resistorCount,
                        seriesResistorCount = MainWindow.Instance.seriesResistorCount,
                        parallelResistorCount = MainWindow.Instance.parallelResistorCount,
                        seriesResistors = MainWindow.Instance.seriesResistors.Select(r => new { r.Width, r.Height }),
                        parallelResistors = MainWindow.Instance.parallelResistors.Select(r => new { r.Width, r.Height }),
                        gapRec = MainWindow.Instance.gapRec.Select(r => new { r.Width, r.Height }),
                        numsofParallelResistor = MainWindow.Instance.numsofParallelResistor,
                        LightData = MainWindow.Instance.LightData.Select(kv => new { index = kv.Key, power = kv.Value.Item1, resistance = kv.Value.Item2 }).ToList(),
                        LightPercentData = MainWindow.Instance.LightPercentData,
                        LightStatus = MainWindow.Instance.LightStatus.Select(kv => new { point = kv.Key, isBroken = kv.Value }).ToList(),
                        LightPosition = MainWindow.Instance.LightPosition,
                        KeyPosition = MainWindow.Instance.KeyPosition,
                        TongHopCacDiem = MainWindow.Instance.TongHopCacDiem,
                        beginEparallel = MainWindow.Instance.beginEparallel,
                        endEparallel = MainWindow.Instance.endEparallel,
                        fusion = MainWindow.Instance.fusion.ToDictionary(kv => kv.Key, kv => kv.Value),
                    },
                    UIElements = new
                    {
                        labels = MainWindow.Instance.labels.Select(l => l.Text).ToList(),
                        sourceElements = MainWindow.Instance.sourceElements.Select(e => e.GetType().Name).ToList(),
                        LightBulbs = MainWindow.Instance.LightBulbs.Select(e => e.GetType().Name).ToList(),
                        ampeList = MainWindow.Instance.ampeList.Select(e => e.GetType().Name).ToList(),
                        key = MainWindow.Instance.key.Select(e => e.GetType().Name).ToList(),
                        voltmeterElements = MainWindow.Instance.voltmeterElements.Select(e => e.GetType().Name).ToList(),
                        connectingLines = MainWindow.Instance.connectingLines.Select(l => new
                        {
                            x1 = l.X1,
                            y1 = l.Y1,
                            x2 = l.X2,
                            y2 = l.Y2
                        }).ToList()
                    },
                    MainCircuitData = new
                    {
                        mainCircuitVoltage = Circuit.MainCurcuitVoltage,
                        mainCircuitEROC = Circuit.MainCircuitEROC,
                        mainCircuitAmperage = Circuit.MainCircuitAmperage,
                        mainCircuit = MainCircuit.mainCircuit.Select(c => new
                        {
                            indexer = c.Indexer,
                            resistance = c.Resistance,
                            voltage = c.Voltage,
                            amperage = c.Amperage,
                            type = c.Type,
                            eropc = c.Eropc,
                            power = c is Light light ? light.Power : (double?)null,
                            leftright = c is Volmeter volmeter ? volmeter.LeftRight() : null
                        }).ToList(),
                        indexOfNode = MainCircuit.indexOfNode,
                        indexOfRes = MainCircuit.indexOfRes,
                        indexOfVol = MainCircuit.indexOfVol,
                        indexOfAmpe = MainCircuit.indexOfAmpe,
                        indexOfSwitch = MainCircuit.indexOfSwitch,
                        indexOfLight = MainCircuit.indexOfLight
                    }
                };

                // Serialize the circuit data to JSON with formatting
                string jsonContent = JsonConvert.SerializeObject(circuitData, Formatting.Indented);

                // Save the JSON content to the specified file path
                File.WriteAllText(filePath, jsonContent);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving circuit data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        public void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance.isVoltmeterMode == true)
            {
                MessageBox.Show("Vui lòng tắt Vol kế!");
                return;
            }
            // Nếu file đã có đường dẫn (đã được lưu trước đó), chỉ cần lưu lại
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                SaveToFile(currentFilePath);
            }
            else
            {
                SaveAsFile_Click(sender, e); // Gọi Save As để người dùng chọn đường dẫn lưu file
            }
        }

        public void SaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Instance.isVoltmeterMode == true)
            {
                MessageBox.Show("Tắt vôn kế đi không lưu lỗi đó ạ!");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Save JSON File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                // Ghi nội dung vào file đã chọn
                SaveToFile(filePath);
                currentFilePath = filePath; // Lưu đường dẫn của file đã lưu
            }
        }
        public void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*",
                Title = "Save Image File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                SaveCanvasAsImage(MainWindow.Instance.CircuitCanvas, filePath);
                currentPicturesPath = filePath;
            }
        }

        public void SaveCanvasAsImage(Canvas canvas, string filePath)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                (int)canvas.ActualWidth,
                (int)canvas.ActualHeight,
                96,
                96,
                PixelFormats.Pbgra32);
            renderTargetBitmap.Render(canvas);
            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                pngEncoder.Save(fileStream);
            }
        }
        public void Undo_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.UndoClick();
        }
        public void Redo_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.RedoClick();
        }
        public void Help_Click(object sender, RoutedEventArgs e)
        {
            var HelpWindow = new AddWindow.HelpWindow();
            HelpWindow.ShowDialog();
        }
    }
}
