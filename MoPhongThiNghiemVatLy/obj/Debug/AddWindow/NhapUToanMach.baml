   M S B A M L   `   `   `  ����P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MoPhongThiNghiemVatLy.AddWindowMoPhongThiNghiemVatLy.AddWindow  5   	   3    -MoPhongThiNghiemVatLy.AddWindow.NhapUToanMach   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   9local-clr-namespace:MoPhongThiNghiemVatLy.AddWindow  5   	     � Title$  Nhập thông tin mạch��5	   	   $	��300��5
   	   $	��300��5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$ Images/IconOfApp.png��5   	    +� FocusedElement 5   	   ��  �� ElementName$ QuantityTextBox����5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,0&�5      .��5      �  � Color$ #D7B9FF��6    � Offset$ 0Q�5      � 5      $ #C2E8FF��6   $ 1Q�5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��0.3* �6   �� 5!      $
��0.2* �6   �� 5#      $��0.25* �6   �� 5%      $��0.25* �6   .+�5)   
   � $��0��6   $��2��5*      .+�5+      (� $��Center=�6   $��Bottom=�5,      $��70��5-      $��70��5.      .��5/      � .+�51      A� $��80��6   $��80��52      
����������#D7B9FF$��3��55      �� 57      $��U��6    $��30(�58       $
��Bold"�59       
����p��$��Center=�5;       $��Center=�5<       5=      5>      5?      � 5B   
   $��0,85,0,0q�6   $��2��5C      .+�5D      �� $/��)Nhập hiệu điện thế toàn mạch:��6   $��Center=�5E      $��Center=�5F      $��19(�5G      $
��Bold"�5H      
���   �5I      5J      � 5M   
   $��1��6   $��	0,57,0,85q�5N      $��3��5O      .+�5P      �� -   5        
 ��Name$
 QuantityTextBox��5P      $	��200��5Q      $��40��5R      $��18(�5S      
�������
���   �$��Center=�5V      $��Center=�5W      $��24��5Y      5Z      5[      � 5^   
   $��3��6   .+�5_      �� -   5        $
��Save��5_      $	��100��5`      $��40��5a      ���#1976D2
�������$��16(�5d      $��Center=�5e      $	��Top=�5f      5g      '  !MaterialDesignThemes.Wpf.Snackbar  5h      -   5          Name$ ErrorSnackbar��5h   &   $��Center=�5i   &   $��Bottom=�5j   &      MessageQueue 5k   &   �� *SnackbarMessageQueue+5l      5n      5o      