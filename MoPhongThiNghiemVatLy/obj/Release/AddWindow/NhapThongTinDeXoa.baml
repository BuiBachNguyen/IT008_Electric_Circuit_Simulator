   M S B A M L   `   `   `  ���� P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MoPhongThiNghiemVatLy.AddWindowMoPhongThiNghiemVatLy.AddWindow  7    1MoPhongThiNghiemVatLy.AddWindow.NhapThongTinDeXoa   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?local-clr-namespace:MoPhongThiNghiemVatLy.AddWindow     _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Xóa thành phần��$	��320��$	��370�� � 
ResizeMode$ NoResize=� � Icon$ Images/IconOfApp.png�� +� FocusedElement ��  �� ElementName$ PTextBox������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #D7B9FF�� � Offset$ 0Q�� $ #C2E8FF��$ 1Q�.��� 	 � RowDefinitions	 �� $��0.25* ��� $��0.15* ��� $��0.20* ��� $��0.20* ��� $��0.20* �.+�� $��0��$��2��.+�(� $��Center=�$��Center=�$��60��$��60��.��� .+�A� $��80��$��80��
����������#D7B9FF$��3���� $	��DEL��$��30(�$
��Bold"�
����p��$��Center=�$��Center=�� $��1��.+��� $#��Nhập thông tin cần xóa:��$��Center=�$��Bottom=�$��20(�$
��Bold"�
���   �� $��2��.+�� 
 � ColumnDefinitions
 �� $
��0.4* ��� $
��0.6* �.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ HelpCircleOutline=�$��25(�$��30��$��30��$��Right=�$��Center=�$��0,0,15,0q�
���   ��� -    ��Name$ ComponentTypeComboBox��$
��Left=�$	��103��$��30��$��16(�
�������
���   �$��Center=�$��Center=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Loại��$��1������ *ComponentTypes+� $��3��.+�� 
 �� $
��0.4* ��� $
��0.6* �.+�  $ FormatListNumbered=�$��25(�$��38��$��30��$��Right=�$	��Top=�$��0,0,15,0q�
���   ��� -   $ IndexComboBox��$
��Left=�$	��103��$��30��$��16(�
�������
���   �$	��Top=�$��Center=�$ 
Chỉ số��$��1��$��0,4,0,0q����� *LongIntegerList+��  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��4��.+��� -   $
��Save��$	��100��$��40��$��0,0,10,0q�
����p��
�������$��16(��� -   $��Cancel��$	��100��$��40��
�������
����p��$��16(�