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
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Runtime.ExceptionServices;
using MoPhongThiNghiemVatLy.AddWindow;
using Newtonsoft.Json.Linq;

namespace MoPhongThiNghiemVatLy
{
    internal class ToolbarButton
    {
        public static void SourceBtn_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Nguồn đã tồn tại. Không thể thêm mới");
                customMessageBox.ShowDialog();
                return;
            }
            else
            {
                var inputWindow = new AddWindow.NhapUToanMach
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Topmost = true,
                    ResizeMode = ResizeMode.NoResize,
                    ShowInTaskbar = false
                };
                if (inputWindow.ShowDialog() == true)
                {
                    Circuit.MainCurcuitVoltage = inputWindow.Value;
                    Drawing.AddSourceToCanvas(CircuitCanvas, 0, 0);
                    MainWindow.Instance.isSourceAdded = true;
                    MainCircuit.indexOfNode += 1;
                    MainCircuit.mainCircuit.Add(new Node(MainCircuit.indexOfNode));
                }
            }
        }
        public static void MNTBtn_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }
            BackUpComponent(); // backup trước khi làm gì nhé
            double resistorValue = Drawing.ShowInputBoxForResistor(MainWindow.Instance.resistorCount + 1);
            if (resistorValue <= 0) return;

            MainWindow.Instance.seriesResistorCount++; // Tăng đt nối tiếp
            MainWindow.Instance.resistorCount++;
            MainWindow.Instance.index++;
            MainWindow.Instance._seriesResistorCount[MainWindow.Instance.index] = 1;
            MainWindow.Instance.resistorValues[MainWindow.Instance.resistorCount] = resistorValue;
            Drawing.UpdateCircuitAfterAdd(CircuitCanvas, 1);
            MainCircuit.AddSeries(MainCircuit.mainCircuit, resistorValue);

            if (MainWindow.Instance.resistorCount == 1 && MainWindow.Instance.seriesResistorCount == 1)
            {
                MainWindow.Instance.checkDotForVolt = true;
            }
            else
            {
                MainWindow.Instance.checkDotForVolt = false;
            }
        }

        public static void MSSBtn_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }

            BackUpComponent(); // backup trước khi làm gì nhé

            var dialog = new ThemSLDienTro()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Topmost = true, 
                ResizeMode = ResizeMode.NoResize,
                ShowInTaskbar = false 
            };
            bool? result = dialog.ShowDialog();
            if (result == true) 
            {
                int count = dialog.ParallelResistorCount;
                MainWindow.Instance.parallelResistorCount = count;
                MainWindow.Instance.resistorCount += count;
                MainWindow.Instance.index++;
                MainWindow.Instance._seriesResistorCount[MainWindow.Instance.index] = count;

                Drawing.UpdateCircuitAfterAdd(CircuitCanvas, count);
                Drawing.ShowInputBoxForParallelResistors(count);
            }
        }
        public static void Đèn_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }
        
            BackUpComponent();
            double[] Value = Drawing.ShowInputBoxForLight();
            if (Value == null) return;
            MainWindow.Instance.index++;
            MainWindow.Instance._seriesResistorCount[MainWindow.Instance.index] = -1;
            Drawing.UpdateCircuitAfterAdd(CircuitCanvas, 0);
            MainCircuit.AddLight(MainCircuit.mainCircuit, Value);
        }
        public static void Ampe_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }

            BackUpComponent(); // backup trước khi làm gì nhé
            MainWindow.Instance.index++;
            MainWindow.Instance._seriesResistorCount[MainWindow.Instance.index] = -2;
            Drawing.UpdateCircuitAfterAdd(CircuitCanvas, 0);
            MainCircuit.AddAmmeter(MainCircuit.mainCircuit);
        }
        public static void Khóa_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }

            BackUpComponent(); // backup trước khi làm gì nhé
            MainWindow.Instance.index++;
            MainWindow.Instance._seriesResistorCount[MainWindow.Instance.index] = -3;
            MainWindow.Instance.isLightOn[MainWindow.Instance.numKey] = true;
            MainWindow.Instance.numKey++;
            Drawing.UpdateCircuitAfterAdd(CircuitCanvas, 0);
            if (MainWindow.Instance.numKey >= 1) MainWindow.Instance.isHaveKey = true;
            else MainWindow.Instance.isHaveKey = false;
            MainCircuit.AddSwitch(MainCircuit.mainCircuit);
        }
        public static void VoltmeterButton_Click(Canvas CircuitCanvas, object sender)
        {
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance._seriesResistorCount.Count == 0) 
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm chi tiết khác trước!");
                customMessageBox.ShowDialog();
                return;
            }
            MainWindow.Instance.isVoltmeterMode = !MainWindow.Instance.isVoltmeterMode;
            Button voltmeterButton = sender as Button;         
            var buttonBackground = voltmeterButton.Template.FindName("ButtonBackground", voltmeterButton) as Border;
            if (buttonBackground != null)
            {
                if (MainWindow.Instance.isVoltmeterMode)
                {

                    buttonBackground.Background = new SolidColorBrush(Colors.LightGreen);
                    CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Voltmeter mode: on. Hãy chọn 2 điểm để mắc Vol kế.");
                    customMessageBox.ShowDialog();
                    Drawing.VisibleDots();
                    if (!MainWindow.Instance.areDotsDrawn)
                    {
                        Drawing.DrawDotsAndVoltmeter(); 
                        MainWindow.Instance.areDotsDrawn = true; 
                    }
                }
                else
                {
                    buttonBackground.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                    CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Voltmeter mode: Off");
                    customMessageBox.ShowDialog();
                    MainWindow.Instance.areDotsDrawn = false;
                    if(MainWindow.Instance.firstDot != null || MainWindow.Instance.secondDot != null)
                    {
                        Drawing.ResetSelectedDots();
                    }
                    Drawing.InvisibleDots();
                }
            }
        }

        public static Stack<StorageInformation> history = new Stack<StorageInformation>();
        public static Stack<StorageInformation> redoStack = new Stack<StorageInformation>();

        public static void BackUpComponent() //lưu lại data
        {
            history.Push(new StorageInformation(MainWindow.Instance.resistorCount,
                                                MainWindow.Instance.index,
                                                MainWindow.Instance._seriesResistorCount, 
                                                MainWindow.Instance.connectedDots, 
                                                MainWindow.Instance.resistorValues, 
                                                MainWindow.Instance.LightData, 
                                                MainWindow.Instance.m, 
                                                MainWindow.Instance.n,
                                                MainWindow.Instance.lineHeight));
        }
        public static void UndoClick()
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (history.Count == 0)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Bạn không thể thực hiện thao tác \"UNDO\" \n Vì không còn thao tác cũ hơn !");
                customMessageBox.ShowDialog();
                return;
            }
            redoStack.Push(new StorageInformation(MainWindow.Instance.resistorCount,
                                                MainWindow.Instance.index,
                                                MainWindow.Instance._seriesResistorCount,
                                                MainWindow.Instance.connectedDots,
                                                MainWindow.Instance.resistorValues,
                                                MainWindow.Instance.LightData,
                                                MainWindow.Instance.m,
                                                MainWindow.Instance.n,
                                                MainWindow.Instance.lineHeight));
            history.Pop().ReturnValueOfCircuit();
            Drawing.UpdateCircuit(MainWindow.Instance.CircuitCanvas, 0);
        }
        public static void RedoClick()
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (redoStack.Count == 0)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Bạn không thể thực hiện thao tác \"REDO\" \n Vì không còn thao tác cũ hơn !");
                customMessageBox.ShowDialog();
                return;
            }
            BackUpComponent();
            redoStack.Pop().ReturnValueOfCircuit();
            Drawing.UpdateCircuit(MainWindow.Instance.CircuitCanvas, 0);
        }
        public static void Check_Click(Canvas CircuitCanvas, object sender)
        {
            Calculate();
            if (!MainWindow.Instance.isSourceAdded && MainWindow.Instance._seriesResistorCount.Count < 1)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Không có mạch điện để kiểm tra!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            // Đổi trạng thái sáng/tối
            MainWindow.Instance.isLightMode = !MainWindow.Instance.isLightMode;
            Button lightButton = sender as Button;
            var buttonBackground = lightButton.Template.FindName("ButtonBackground", lightButton) as Border;
            if (buttonBackground != null)
            {
                buttonBackground.Background = MainWindow.Instance.isLightMode
                    ? new SolidColorBrush(Colors.LightGreen)
                    : new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }
            // Điều khiển electron
            if (MainWindow.Instance.isLightMode) 
            {
                Drawing.DrawRealElectron(CircuitCanvas, 0.5); // animate electron
            }
            else 
            {
                Drawing.StopDrawingElectrons(); // Dừng timer (dừng tạo electron)
            }
        }

        public static void CalculateButton_Click(Canvas CircuitCanvas, object sender)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.resistorCount <= 0 && MainWindow.Instance.LightData.Count <=0)
            {
                // Tạo và hiển thị Custom MessageBox
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Hãy thêm chi tiết để tính toán!");
                customMessageBox.ShowDialog();
            }
            else
            {
                // Tạo và hiển thị Custom MessageBox
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Đã thực hiện xong tính toán rồi. \nTrỏ chuột vào chi tiết cần xem để xem nhé");
                customMessageBox.ShowDialog();
            }
            Calculate();
            Drawing.ShowValueAfterCalcCircuit(CircuitCanvas, 0);
        }
        public static void Calculate()
        {
            Circuit.MainCircuitEROC = Circuit.EquivalentResistance(MainCircuit.mainCircuit);
            Circuit.MainCircuitAmperage = Circuit.MainCurcuitVoltage / Circuit.MainCircuitEROC;
            Circuit.CalculateForAllDetails(MainCircuit.mainCircuit, Circuit.MainCircuitAmperage);
            
        }
        public static void Xóa_Click(Canvas CircuitCanvas)
        {
            if (MainWindow.Instance.isVoltmeterMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt chế độ Vol kế!");
                customMessageBox.ShowDialog();
                return;
            }
            if (MainWindow.Instance.isLightMode)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng tắt kiểm tra đèn!");
                customMessageBox.ShowDialog();
                return;
            }
            if (!MainWindow.Instance.isSourceAdded)
            {
                CustomizeMessageBox customMessageBox = new CustomizeMessageBox("Vui lòng thêm nguồn trước khi thao tác!");
                customMessageBox.ShowDialog();
                return;
            }

            BackUpComponent(); // backup trước khi xóa nhé
            var result = Drawing.ShowInputForXoa();
            if (result != null)
            {
                int targetKey = 0;
                int type = result[0];
                int index = result[1];
                int count = 0;
                if (type == -4)
                {
                    var tempList = MainWindow.Instance.connectedDots.ToList();
                    if (index > 0 && index <= tempList.Count)
                    {
                        tempList.RemoveAt(index - 1);
                    }
                    MainWindow.Instance.connectedDots = new HashSet<(int, int)>(tempList);
                    Drawing.UpdateCircuitAfterDelete(MainWindow.Instance.CircuitCanvas, 0, 0);
                }
                else
                {

                    foreach (var kvp in MainWindow.Instance._seriesResistorCount)
                    {
                        if (type == 1 && kvp.Value >= 1) count += kvp.Value;
                        else if (type == kvp.Value) count++;

                        if (count >= index)
                        {
                            targetKey = kvp.Key;
                            break;
                        }
                    }
                    if (targetKey == 0) return;
                    if (type >= 1)
                    {
                        for (int i = index; i < MainWindow.Instance.resistorValues.Count(); i++)
                            MainWindow.Instance.resistorValues[i] = MainWindow.Instance.resistorValues[i + 1];
                        MainWindow.Instance.resistorValues.Remove(MainWindow.Instance.resistorValues.Count());
                        MainWindow.Instance.resistorCount--;
                    }
                    else if (type == -1)
                    {
                        MainWindow.Instance.iOfLight--;
                        for (int i = index; i < MainWindow.Instance.LightData.Count(); i++)
                            MainWindow.Instance.LightData[i] = MainWindow.Instance.LightData[i + 1];
                        MainWindow.Instance.LightData.Remove(MainWindow.Instance.LightData.Count());
                    }
                    if (type == 1) MainWindow.Instance.seriesResistorCount--;
                    if (MainWindow.Instance._seriesResistorCount[targetKey] > 1)
                    {
                        MainWindow.Instance._seriesResistorCount[targetKey]--;
                        Drawing.UpdateCircuitAfterDelete(MainWindow.Instance.CircuitCanvas, 1, 0);
                    }
                    else
                    {
                        XoaPhanTu(targetKey);
                        Drawing.UpdateCircuitAfterDelete(MainWindow.Instance.CircuitCanvas, 0, 1);
                    }
                }
                Drawing.UpdateResistorValuesDisplay();
                MainCircuit.RemoveDetail(MainCircuit.mainCircuit, result[0], result[1]);
            }
        }
        private static void XoaPhanTu(int key)
        {
            var tempList = MainWindow.Instance.connectedDots.ToList(); // Chuyển HashSet thành List
            for (int i = 0; i < tempList.Count; i++)
            {
                var item = tempList[i]; // Lấy giá trị tuple (int, int)

                // Kiểm tra và giảm giá trị nếu cần
                if (item.Item1 >= key) item.Item1--;
                if (item.Item2 >= key) item.Item2--;

                tempList[i] = item;
            }
            // Cập nhật lại HashSet với giá trị đã thay đổi
            MainWindow.Instance.connectedDots = new HashSet<(int, int)>(tempList);
            MainWindow.Instance.connectedDots = MainWindow.Instance.connectedDots
            .Where(pair => pair.Item1 != pair.Item2 && pair.Item1 >= 0 && pair.Item2 >= 0) // Lọc các phần tử thỏa mãn điều kiện
            .ToHashSet(); // Cập nhật lại HashSet
            for (int i = key; i < MainWindow.Instance._seriesResistorCount.Count(); i++)
                MainWindow.Instance._seriesResistorCount[i] = MainWindow.Instance._seriesResistorCount[i + 1];
            MainWindow.Instance._seriesResistorCount.Remove(MainWindow.Instance._seriesResistorCount.Count());
            MainWindow.Instance.index--;
        }
    }
}
