using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for NhapGTBongDen.xaml
    /// </summary>
    public partial class NhapGTBongDen : Window
    {
        public NhapGTBongDen()
        {
            InitializeComponent();
            ErrorSnackbar.MessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }
        public double R { get; private set; }
        public double P { get; private set; }
        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnSaveButtonClick(sender, e);
            }
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            bool check = true;

            // Khôi phục màu sắc TextBox trước khi kiểm tra
            ResetTextBoxStyle(PTextBox);
            ResetTextBoxStyle(RTextBox);

            // Kiểm tra giá trị P
            if (!double.TryParse(PTextBox.Text, out double p) || p <= 0)
            {
                ShowErrorForTextBox(PTextBox);
                check = false;
            }

            // Kiểm tra giá trị R
            if (!double.TryParse(RTextBox.Text, out double r) || r <= 0)
            {
                ShowErrorForTextBox(RTextBox);
                check = false;
            }

            if (check)
            {
                P = p;
                R = r;
                DialogResult = true;
            }
            else
            {
                ErrorSnackbar.MessageQueue.Enqueue("Vui lòng nhập số thực lớn hơn 0!");
            }
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            // Khôi phục lại màu sắc của TextBox khi người dùng nhập
            if (sender is TextBox textBox)
            {
                ResetTextBoxStyle(textBox);
            }
        }

        private void ShowErrorForTextBox(TextBox textBox)
        {
            textBox.BorderBrush = Brushes.Red;
            textBox.Background = Brushes.LightPink;
            textBox.Focus();
        }

        private void ResetTextBoxStyle(TextBox textBox)
        {
            textBox.BorderBrush = Brushes.Transparent;
            textBox.Background = Brushes.White; // Hoặc màu mặc định
        }

    }
}
