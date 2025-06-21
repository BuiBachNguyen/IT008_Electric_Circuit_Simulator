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

namespace MoPhongThiNghiemVatLy.AddWindow
{
    /// <summary>
    /// Interaction logic for CustomizeMessageBox.xaml
    /// </summary>
    public partial class CustomizeMessageBox : Window
    {
        public CustomizeMessageBox(string message) 
        { 
            InitializeComponent();
            MessageText.Text = message; // Set the message
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
