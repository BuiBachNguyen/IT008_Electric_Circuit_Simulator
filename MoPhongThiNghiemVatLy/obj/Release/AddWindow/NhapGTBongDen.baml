   M S B A M L   `   `   `  ���� P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MoPhongThiNghiemVatLy.AddWindowMoPhongThiNghiemVatLy.AddWindow  3    -MoPhongThiNghiemVatLy.AddWindow.NhapGTBongDen   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?local-clr-namespace:MoPhongThiNghiemVatLy.AddWindow     _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Thêm bóng đèn��$	��300��$	��350�� � 
ResizeMode$ NoResize=� � Icon$ Images/IconOfApp.png�� +� FocusedElement ��  �� ElementName$ PTextBox������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #D7B9FF�� � Offset$ 0Q�� $ #C2E8FF��$ 1Q�.��� 	 � RowDefinitions	 �� $��0.20* ��� $��0.15* ��� $��0.20* ��� $��0.20* ��� $��0.25* �.+�� $��0��$��2��.+�(� $��Center=�$��Bottom=�$��50��$��50��.��� .+�A� $��82��$��80��
�������
����p��$��5��F� 
����p��$��5��������� ��� �@���,	$��2,0,-2,0q�F� 
����p��$��5������@����� ���� �,	� $��1��.+��� $%��Nhập thông số bóng đèn:��$��Center=�$��Bottom=�$��20(�$
��Bold"�
���   �� $��2��.+�� 
 � ColumnDefinitions
 �� $��0.35* ��� $
��0.6* �.+��� $��P��$��22(�$
��Bold"�$��Center=�$��Right=�$��0,0,15,0q��� -    ��Name$ PTextBox��$	��100��$��30��$��18(�
�������
���   �$
��Left=�$��Center=�$��Center=�$��1��$��Center=�� $��3��.+�� 
 �� $��0.35* ��� $
��0.6* �.+��� $��R��$��22(�$
��Bold"�$	��Top=�$��Right=�$��0,0,15,0q��� -   $ RTextBox��$	��100��$��30��$��18(�
�������
���   �$
��Left=�$	��Top=�$��Center=�$��Center=�$��1��� $��4��.+��� -   $
��Save��$	��100��$��40�����#1976D2
�������$��16(�$��Center=�$	��Top=�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ ErrorSnackbar��$��Center=�$��Bottom=�   MessageQueue �� *SnackbarMessageQueue+