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
    /// Interaction logic for Instruction.xaml
    /// </summary>
    public partial class Instruction : Window
    {
        public Instruction()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AgreementCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            OkButton.IsEnabled = true;
        }

        private void AgreementCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            OkButton.IsEnabled = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // Kéo cửa sổ
                this.DragMove();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
