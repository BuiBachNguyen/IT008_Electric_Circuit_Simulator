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
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace MoPhongThiNghiemVatLy.AddWindow
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
            StartLoadingAnimation();
            string gifFilePath = "pack://application:,,,/Images/nyan.gif.gif"; // Đảm bảo tệp GIF của bạn nằm trong thư mục Images và đã được đặt Build Action = Resource

            // Tạo URI cho GIF
            Uri gifUri = new Uri(gifFilePath);

            // Tạo BitmapImage từ URI và sử dụng ImageBehavior để phát GIF
            BitmapImage bitmapImage = new BitmapImage(gifUri);
            ImageBehavior.SetAnimatedSource(GifImage, bitmapImage);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(6);
            timer.Tick += (sender, e) =>
            {
                timer.Stop(); // Dừng timer sau khi cửa sổ đã đóng
                this.Close(); // Đóng cửa sổ giới thiệu
            };
            timer.Start();
        }
        private async void StartLoadingAnimation()
        {
            string baseText = "Loading to Electrical Circuit Simulation";
            int dotCount = 0;

            while (true)
            {
                // Tạo chuỗi dấu chấm dựa trên dotCount
                LoadingText.Text = baseText + new string('.', dotCount);

                // Cập nhật số dấu chấm (1 -> 2 -> 3 -> 0)
                dotCount = (dotCount + 1) % 4;

                // Tạm dừng 500ms trước khi cập nhật lại
                await Task.Delay(500);
            }
        }
    }
}
