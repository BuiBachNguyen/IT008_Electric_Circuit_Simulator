using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoPhongThiNghiemVatLy.AddWindow
{
    public partial class NhapThongTinDeXoa : Window
    {
        public int[] Result { get; private set; }
        private readonly List<string> _componentTypes = new List<string>
        {
            "Điện trở", "Đèn", "Ampe", "Khóa", "Vôn kế"
        };

        public NhapThongTinDeXoa()
        {
            InitializeComponent();
            ComponentTypeComboBox.ItemsSource = _componentTypes;
            ComponentTypeComboBox.SelectedIndex = 0;

            UpdateIndexComboBox(); // Cập nhật danh sách chỉ số

            ComponentTypeComboBox.SelectionChanged += OnComponentTypeChanged;
            this.KeyDown += OnWindowKeyDown;
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessInput();
            }
        }

        private void OnComponentTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateIndexComboBox();
        }

        private void UpdateIndexComboBox()
        {
            int count = 0;
            switch (ComponentTypeComboBox.SelectedIndex)
            {
                case 0: count = IndexForShowResult.indexOfRes; break;
                case 1: count = IndexForShowResult.indexOfLight; break;
                case 2: count = IndexForShowResult.indexOfAmpe; break;
                case 3: count = MainWindow.Instance.isLightOn.Count; break;
                case 4: count = IndexForShowResult.indexOfVol; break;
            }

            var indices = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                indices.Add(i);
            }

            IndexComboBox.ItemsSource = indices;
            if (indices.Count > 0)
                IndexComboBox.SelectedIndex = 0;
        }

        private void ProcessInput()
        {
            try
            {
                int componentType = 0;
                switch (ComponentTypeComboBox.SelectedIndex)
                {
                    case 0: componentType = DEFINE.TYPE_Res; break;
                    case 1: componentType = DEFINE.TYPE_Light; break;
                    case 2: componentType = DEFINE.TYPE_Ampe; break;
                    case 3: componentType = DEFINE.TYPE_Switch; break;
                    case 4: componentType = DEFINE.TYPE_Vol; break;
                }

                if (IndexComboBox.SelectedItem is int index && index > 0)
                {
                    Result = new int[] { componentType, index };
                    this.DialogResult = true;
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.");
            }
        }

    }
}
