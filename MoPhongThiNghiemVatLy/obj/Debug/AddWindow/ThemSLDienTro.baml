   M S B A M L   `   `   `  ����P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MoPhongThiNghiemVatLy.AddWindowMoPhongThiNghiemVatLy.AddWindow  5   	   3    -MoPhongThiNghiemVatLy.AddWindow.ThemSLDienTro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   9m1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   9local-clr-namespace:MoPhongThiNghiemVatLy.AddWindow  5   	     � Title$/  )Nhập thông tin điện trở song song��5
   	   $	��300��5   	   $	��300��5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$ Images/IconOfApp.png��5   	    +� FocusedElement 5   	   ��  �� ElementName$ QuantityTextBox����5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,0&�5      .��5      �  � Color$ #D7B9FF��6    � Offset$ 0Q�5      � 5      $ #C2E8FF��6   $ 1Q�5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5       $
��0.3* �6   �� 5"      $
��0.2* �6   �� 5$      $��0.25* �6   �� 5&      $��0.25* �6   .+�5*   
   � $��0��6   $��2��5+      .+�5,      (� $��Center=�6   $��Bottom=�5-      $��70��5.      $��70��5/      .��50      � .+�52      A� $��80��6   $��80��53      
����������#D7B9FF$��3��56      �� 58      $��||��6    $��30(�59       $
��Bold"�5:       
����p��$��Center=�5<       $��Center=�5=       
 J� RenderTransformOrigin$
 1.777,-0.015&�5>       5?      5@      5A      � 5D   
   $��0,85,0,0q�6   $��2��5E      .+�5F      �� $)��#Nhập số lượng điện trở:��6   $��Center=�5G      $��Center=�5H      $��20(�5I      $
��Bold"�5J      
���   �5K      5L      � 5O   
   $��1��6   $��	0,57,0,85q�5P      $��3��5Q      .+�5R      �� -   5         ��Name$ QuantityTextBox��5R      $	��200��5S      $��40��5T      $��18(�5U      
�������
���   �$��Center=�5X      $��Center=�5Y      5[      5\      � 5_   
   $��3��6   .+�5`      �� -   5        $
��Save��5`      $	��100��5a      $��40��5b      ���#1976D2
�������$��16(�5e      $��Center=�5f      $	��Top=�5g      5h      '  !MaterialDesignThemes.Wpf.Snackbar  5i      -   5          Name$ ErrorSnackbar��5i   &   $��Center=�5j   &   $��Bottom=�5k   &      MessageQueue 5l   &   �� *SnackbarMessageQueue+5m      5p      5q      