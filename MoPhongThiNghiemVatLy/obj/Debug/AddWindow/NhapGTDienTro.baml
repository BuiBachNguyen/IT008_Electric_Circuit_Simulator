   M S B A M L   `   `   `  ����  MoPhongThiNghiemVatLy3    -MoPhongThiNghiemVatLy.AddWindow.NhapGTDienTro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Nhập thông tin��5   	   $	��300��5	   	   $	��300��5
   	    � 
ResizeMode$ NoResize=�5   	    � Icon$ Images/IconOfApp.png��5   	    +� FocusedElement 5   	   ��  �� ElementName$ QuantityTextBox����5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,0&�5      .��5      �  � Color$ #D7B9FF��6    � Offset$ 0Q�5      � 5      $ #C2E8FF��6   $ 1Q�5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��0.3* �6   �� 5       $
��0.2* �6   �� 5"      $��0.25* �6   �� 5$      $��0.25* �6   .+�5(   
   � $��0��6   $��2��5)      .+�5*      (� $��Center=�6   $��Bottom=�5+      $��70��5,      $��70��5-      .��5.      � .+�50      A� $��80��6   $��80��51      
����������#D7B9FF$��3��54      �� 56      $��R��6    $��30(�57       $
��Bold"�58       
����p��$��Center=�5:       $��Center=�5;       5<      5=      5>      � 5A   
   $��0,85,0,0q�6   $��2��5B      .+�5C      �� $+��%Nhập giá trị của điện trở��6   $��Center=�5D      $��Center=�5E      $��20(�5F      $
��Bold"�5G      
���   �5H      5I      � 5L   
   $��1��6   $��	0,57,0,85q�5M      $��3��5N      .+�5O      �� -   5        
 ��Name$
 QuantityTextBox��5O      $	��200��5P      $��40��5Q      $��18(�5R      
�������
���   �$��Center=�5U      $��Center=�5V      5X      5Y      � 5\   
   $��3��6   .+�5]      �� -   5        $
��Save��5]      $	��100��5^      $��40��5_      ���#1976D2
�������$��16(�5b      $��Center=�5c      $	��Top=�5d      5e      '  !MaterialDesignThemes.Wpf.Snackbar  5f      -   5          Name$ ErrorSnackbar��5f   &   $��Center=�5g   &   $��Bottom=�5h   &      MessageQueue 5i   &   �� *SnackbarMessageQueue+5j      5m      5n      