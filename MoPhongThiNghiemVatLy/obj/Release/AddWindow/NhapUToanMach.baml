   M S B A M L   `   `   `  ���� P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MoPhongThiNghiemVatLy.AddWindowMoPhongThiNghiemVatLy.AddWindow  3    -MoPhongThiNghiemVatLy.AddWindow.NhapUToanMach   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9local-clr-namespace:MoPhongThiNghiemVatLy.AddWindow    � Title$  Nhập thông tin mạch��$	��300��$	��300�� � 
ResizeMode$ NoResize=� � Icon$ Images/IconOfApp.png�� +� FocusedElement ��  �� ElementName$ QuantityTextBox������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #D7B9FF�� � Offset$ 0Q�� $ #C2E8FF��$ 1Q�.��� 	 � RowDefinitions	 �� $
��0.3* ��� $
��0.2* ��� $��0.25* ��� $��0.25* �.+�� $��0��$��2��.+�(� $��Center=�$��Bottom=�$��70��$��70��.��� .+�A� $��80��$��80��
����������#D7B9FF$��3���� $��U��$��30(�$
��Bold"�
����p��$��Center=�$��Center=�� $��0,85,0,0q�$��2��.+��� $/��)Nhập hiệu điện thế toàn mạch:��$��Center=�$��Center=�$��19(�$
��Bold"�
���   �� $��1��$��	0,57,0,85q�$��3��.+��� -   
 ��Name$
 QuantityTextBox��$	��200��$��40��$��18(�
�������
���   �$��Center=�$��Center=�$��24��� $��3��.+��� -   $
��Save��$	��100��$��40�����#1976D2
�������$��16(�$��Center=�$	��Top=�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ ErrorSnackbar��$��Center=�$��Bottom=�   MessageQueue �� *SnackbarMessageQueue+