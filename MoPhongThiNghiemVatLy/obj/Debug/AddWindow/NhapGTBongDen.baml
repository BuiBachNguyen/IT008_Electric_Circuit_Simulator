   M S B A M L   `   `   `  ����P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:MoPhongThiNghiemVatLy.AddWindowMoPhongThiNghiemVatLy.AddWindow  5   	   3    -MoPhongThiNghiemVatLy.AddWindow.NhapGTBongDen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:MoPhongThiNghiemVatLy.AddWindow     5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Thêm bóng đèn��5	   	   $	��300��5
   	   $	��350��5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$ Images/IconOfApp.png��5   	    +� FocusedElement 5   	   ��  �� ElementName$ PTextBox����5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,0&�5      .��5      �  � Color$ #D7B9FF��6    � Offset$ 0Q�5      � 5      $ #C2E8FF��6   $ 1Q�5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $��0.20* �6   �� 5!      $��0.15* �6   �� 5#      $��0.20* �6   �� 5%      $��0.20* �6   �� 5'      $��0.25* �6   .+�5+   
   � $��0��6   $��2��5,      .+�5-      (� $��Center=�6   $��Bottom=�5.      $��50��5/      $��50��50      .��51      � .+�53      A� $��82��6   $��80��54      
�������
����p��$��5��57      F� 59      
����p��$��5��61   ������� ��� �@���,	$��2,0,-2,0q�5:      F� 5;      
����p��$��5��5<      ����@����� ���� �,	5=      5>      5?      5@      � 5C   
   $��1��6   .+�5D      �� $%��Nhập thông số bóng đèn:��6   $��Center=�5E      $��Bottom=�5F      $��20(�5G      $
��Bold"�5H      
���   �5I      5J      � 5M   
   $��2��6   .+�5N      � 
 � ColumnDefinitions
 5P      �� 5Q      $��0.35* �6'   �� 5R      $
��0.6* �6'   .+�5V      �� $��P��6   $��22(�5W      $
��Bold"�5X      $��Center=�5Y      $��Right=�5Z      $��0,0,15,0q�5[      �� 5^      -   5         ��Name$ PTextBox��5^      $	��100��5_      $��30��5`      $��18(�5a      
�������
���   �$
��Left=�5d      $��Center=�5e      $��Center=�5f      $��1��5g      $��Center=�5i      5j      5k      5l      � 5o   
   $��3��6   .+�5p      � 
 5r      �� 5s      $��0.35* �6'   �� 5t      $
��0.6* �6'   .+�5x      �� $��R��6   $��22(�5y      $
��Bold"�5z      $	��Top=�5{      $��Right=�5|      $��0,0,15,0q�5}      �� 5�      -   5        $ RTextBox��5�      $	��100��5�      $��30��5�      $��18(�5�      
�������
���   �$
��Left=�5�      $	��Top=�5�      $��Center=�5�      $��Center=�5�      $��1��5�      5�      5�      5�      � 5�   
   $��4��6   .+�5�      �� -   5        $
��Save��5�      $	��100��5�      $��40��5�      ���#1976D2
�������$��16(�5�      $��Center=�5�      $	��Top=�5�      5�      '  !MaterialDesignThemes.Wpf.Snackbar  5�      -   5          Name$ ErrorSnackbar��5�   &   $��Center=�5�   &   $��Bottom=�5�   &      MessageQueue 5�   &   �� *SnackbarMessageQueue+5�      5�      5�      