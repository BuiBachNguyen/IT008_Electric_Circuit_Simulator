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
using static System.Net.WebRequestMethods;
using System.Diagnostics.Eventing.Reader;
using System.Security;

namespace MoPhongThiNghiemVatLy
{
    public partial class MainWindow : Window
    {
        
        private MenuStrip menuStrip;
        public static MainWindow Instance { get; private set; }
        public System.Windows.Threading.DispatcherTimer electronTimer;
        public MainWindow()
        {
            InitializeComponent();
            menuStrip = new MenuStrip(this);
            Instance = this;

            if (DEFINE.isFirstTime)
            {
                AddWindow.Intro intro = new AddWindow.Intro();
                intro.ShowDialog();

                AddWindow.Instruction instruction = new AddWindow.Instruction();
                instruction.ShowDialog();

                DEFINE.isFirstTime = false;
            }
        }

        //LIST
        public List<TextBlock> labels = new List<TextBlock>();
        public List<UIElement> sourceElements = new List<UIElement>();
        public List<UIElement> LightBulbs = new List<UIElement>();
        public List<UIElement> ampeList = new List<UIElement>();
        public List<UIElement> key = new List<UIElement>();
        public List<UIElement> voltmeterElements = new List<UIElement>();
        public List<Line> connectingLines = new List<Line>();

        //DANH SÁCH PHẦN TỬ TRONG MẠCH (CANVAS + TÍNH TOÁN)
        public List<char> InorderToCal = new List<char>();
        public HashSet<(int, int)> connectedDots = new HashSet<(int, int)>();  //list pair lưu lại (1,2) chứng tỏ vẽ rồi
        public Dictionary<Ellipse, int> dotDegrees = new Dictionary<Ellipse, int>();  //dotDegrees[dotx] = 3: bậc dotx = 3
        public Dictionary<int, Dot> indexDot = new Dictionary<int, Dot>();  //indexDot[3]: Dot3
        public HashSet<(int, int)> indexofParallel = new HashSet<(int, int)>(); // indexofParallel[i] = j: ở vị trí i có j điện trở song song
        public Dictionary<int, int> checkDots = new Dictionary<int, int>();
        public List<int> dotIndex = new List<int>();
        public Dictionary<int, bool> isLightOn = new Dictionary<int, bool>();  //nếu tất cả bằng true => đèn sáng
        public Dictionary<int,(double, double)> LightData = new Dictionary<int,(double, double)>(); //1: công suất, 2 điện trở
        public int iOfLight = 0;
        public Dictionary<int, double> LightPercentData = new Dictionary<int, double>(); //1: index, 2 phần trăm
        public Dictionary<Point, bool> LightStatus = new Dictionary<Point, bool>();//true: hỏng, false: ko hỏng
        public List<Brush> LightColorArray = new List<Brush> { Brushes.LightYellow, Brushes.Yellow, Brushes.Red };
        public List<Point> LightPosition = new List<Point>();
        public List<Point> KeyPosition = new List<Point>();
        public List<Point> TongHopCacDiem = new List<Point>();
        public List<Point> beginEparallel = new List<Point>();
        public List<Point> endEparallel = new List<Point>();
        public Dictionary<Point, List<Point>> fusion = new Dictionary<Point, List<Point>>();
        public List<int> numsofParallelResistor = new List<int>();

        //ĐIỆN TRỞ
        public int resistorCount = 0; //tổng
        public int seriesResistorCount = 0;
        public int parallelResistorCount = 0;
        public Dictionary<int, TextBlock> seriesLabels = new Dictionary<int, TextBlock>();
        public Dictionary<int, TextBlock> parallelLabels = new Dictionary<int, TextBlock>();
        public List<Rectangle> seriesResistors = new List<Rectangle>();
        public List<Rectangle> parallelResistors = new List<Rectangle>();
        public List<Rectangle> gapRec = new List<Rectangle>();
        public Dictionary<int, double> resistorValues = new Dictionary<int, double>();// resistorValues[i] = n

        public Dictionary<int, int> _seriesResistorCount = new Dictionary<int, int>();
        // _seriesResistorCount[i] = 1 nếu là 1 điện trở nối tiếp
        // _seriesResistorCount[i] = n nếu là n điện trở song song
        // _seriesResistorCount[i] = -1 nếu là đèn
        // _seriesResistorCount[i] = -2 nếu là ampe
        // _seriesResistorCount[i] = -3 nếu là khóa

        //------------------------------------------------------

        public bool isSourceAdded = false;
        public Line AB = null;
        public double xA, yA, xB, yB;
        public double m = 0, n = 0; //kéo dài nguồn
        public double lineHeight = 150; //cao gốc
        public int addedHeight = 50; //kéo thêm khi có song song
        public double xPositive, yPositive, xNegative, yNegative;
        public double xStraightP, yStraightP, xStraightN, yStraightN;

        public bool areDotsDrawn = false;
        public bool hadVoltmeter = false;
        public bool isVoltmeterMode = false;
        public bool checkDotForVolt = false;
        public Dot firstDot = null;
        public Dot secondDot = null;
        public int voltNum = 0;  //số lượng vôn kế

        public bool isSave = true;
        public int numKey = 0;
        public bool isKey = true;
        public int index = 0; //lưu index để lưu mạch chính
        public bool lightAcp = false;
        public bool isInteractingWithKey = false;
        public bool isHaveKey = false;
        public bool isLightMode = false;
        public double delayBetweenElectrons = 2;

        //-------------------------------------------

        // MENUSTRIP
        private void New_Click(object sender, RoutedEventArgs e) => menuStrip.New_Click(sender, e);
        private void OpenFileButton_Click(object sender, RoutedEventArgs e) => menuStrip.OpenFileButton_Click(sender, e);
        private void SaveFile_Click(object sender, RoutedEventArgs e) => menuStrip.SaveFile_Click(sender, e);
        private void SaveAsFile_Click(object sender, RoutedEventArgs e) => menuStrip.SaveAsFile_Click(sender, e);
        private void Undo_Click(object sender, RoutedEventArgs e) => menuStrip.Undo_Click(sender, e);
        private void Redo_Click(object sender, RoutedEventArgs e) => menuStrip.Redo_Click(sender, e);
        private void Help_Click(object sender, RoutedEventArgs e) => menuStrip.Help_Click(sender, e);
        private void Export_Click(object sender, RoutedEventArgs e) => menuStrip.Export_Click(sender, e);


        //-------------------------------------------

        // TOOLBAR BUTTON

        private void SourceBtn_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.SourceBtn_Click(CircuitCanvas);
        }
        private void MNTBtn_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.MNTBtn_Click(CircuitCanvas);
        }
        private void MSSBtn_Click(Object sender, RoutedEventArgs e)
        {
            ToolbarButton.MSSBtn_Click(CircuitCanvas);
        }
        private void Đèn_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.Đèn_Click(CircuitCanvas);
        }
        private void Ampe_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.Ampe_Click(CircuitCanvas);
        }
        private void Khóa_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.Khóa_Click(CircuitCanvas);
        }
        private void VoltmeterButton_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.VoltmeterButton_Click(CircuitCanvas, sender);
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            ToolbarButton.CalculateButton_Click(CircuitCanvas, sender);
        }
        private void UndoClick(object sender, RoutedEventArgs e)
        {
            ToolbarButton.UndoClick();
            MainCircuit.Undo();
        }
        private void RedoClick(object sender, RoutedEventArgs e)
        {
            ToolbarButton.RedoClick();
            MainCircuit.Redo();
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.Check_Click(CircuitCanvas, sender);
        }
        private void Xóa_Click(object sender, RoutedEventArgs e)
        {
            ToolbarButton.Xóa_Click(CircuitCanvas);
        }



        //ZOOM, KÉO THẢ

        private bool isPanning = false;
        private Point panStartPoint;

        private void CircuitCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double scaleFactor = e.Delta > 0 ? 1.1 : 0.9;
            var scaleTransform = CanvasScaleTransform;
            var translateTransform = CanvasTranslateTransform;
            double newScale = scaleTransform.ScaleX * scaleFactor;
            
            if (newScale < 0.5 || newScale > 3) return; // Giới hạn zoom từ 0.5x đến 3x
            scaleTransform.ScaleX = newScale;
            scaleTransform.ScaleY = newScale;
            double deltaX = e.GetPosition(CircuitCanvas).X * (1 - scaleFactor);
            double deltaY = e.GetPosition(CircuitCanvas).Y * (1 - scaleFactor);
            translateTransform.X -= deltaX;
            translateTransform.Y -= deltaY;
        }
        private void CircuitCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning && !isVoltmeterMode)
            {
                Point currentPoint = e.GetPosition(ZoomScrollViewer);
                if (currentPoint.X > CircuitCanvas.Width - 50) 
                {
                    CircuitCanvas.Width += 200;
                }
                if (currentPoint.Y > CircuitCanvas.Height - 50) 
                {
                    CircuitCanvas.Height += 200;
                }

                if (currentPoint.X < 50 && CircuitCanvas.Width > 200)
                {
                    CircuitCanvas.Width -= 200;
                }
                if (currentPoint.Y < 50 && CircuitCanvas.Height > 200)
                {
                    CircuitCanvas.Height -= 200;
                }
                double offsetX = currentPoint.X - panStartPoint.X;
                double offsetY = currentPoint.Y - panStartPoint.Y;

                // Di chuyển Canvas
                CanvasTranslateTransform.X += offsetX;
                CanvasTranslateTransform.Y += offsetY;

                panStartPoint = currentPoint; // Cập nhật lại vị trí kéo
            }
        }
        private void CircuitCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isVoltmeterMode)
            {
                isPanning = false;
                CircuitCanvas.ReleaseMouseCapture();
            }
        }

        private void CircuitCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isVoltmeterMode || isInteractingWithKey) // Chế độ vôn kế
            {
                Point mousePosition = e.GetPosition(CircuitCanvas);
                var hitTestResult = VisualTreeHelper.HitTest(CircuitCanvas, mousePosition);
                if (hitTestResult?.VisualHit is Ellipse dot && dot.Tag?.ToString() == "dot")
                {
                    dot.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, e.Timestamp, MouseButton.Left)
                    {
                        RoutedEvent = UIElement.MouseLeftButtonDownEvent,
                        Source = dot
                    });
                }
                e.Handled = true; 
            }
            else 
            {
                isPanning = true;
                panStartPoint = e.GetPosition(ZoomScrollViewer);
                CircuitCanvas.CaptureMouse();
            }
        }
    }
}
