   M S B A M L   `   `   `  ����P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MoPhongThiNghiemVatLyMoPhongThiNghiemVatLy  5   	   &     MoPhongThiNghiemVatLy.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MoPhongThiNghiemVatLy     5   	     � WindowState$  	Maximized=�5   	    � Title$/ )Phần Mềm Thí Nghiệm Mạch Điện��5	   	   $	��500��6/   $
��1500��6<    � Icon$ Images/IconOfApp.png��5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation	 K� IsItemsHost��%f  'o�       'c� p     �� 5   
   " o�6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   5      �� 5   
   " c�6   .�5      ��  � �� 5      �� 5      " c�6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   ._�5      �� $ 
Horizontal=�6)   	 . 6B   5      5      5      5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5       $��* �6   .+�5$   
   ]� 
���   �$��0��6'   .+�5&      o� $	��Top=�6   $��25��6(   .@�5'      m� -   5        $	��New��5'      $��30��6:   $��80��6F   m� 5(      -   5        $
��Open��5(      $��30��6F   $��90��6R   m� 5)      -   5        $
��Save��5)      $��30��6@   $��80��6L   m� 5*      -   5        $��Save As��5*      $��30��6E   $	��120��6Q   m� 5+      -   5        $��Export��5+      $��30��5-      $	��100��5.      m� 5/      $
��Edit��6   $��30��6)   $��80��65   .@�50      m� -   5        $
��Undo��50      
���   �6@   m� 51      -   5        $
��Redo��51      
���   �6@   52      m� 53      -   5        $
��Help��53      $��30��6<   $��82��6H   54      �� 57      $	��Top=�6   $��9q�6*   ���#333333 �� CornerRadius$ 15��6J   ._�58      `�  `� 
Background
 ���� .�59      c� -	   5        $��ComponentToolBar��59      
������ $	��Top=�6O   .@�5<      �� -
   5        $��	MNTButton��5<   !   $	��124��62   $	��100��6>   
���   �$	��MNT��6�   ��6^   �� *SelectComponentCommand+��5=      �� 5>   "   " ��62   .R�5?   &   �  �Name$ 
ButtonGrid��6+   '  !System.Windows.VisualStateManager   VisualStateGroups 5@   *   %  System.Windows.VisualStateGroup  5A   .   CommonStates��   States. 5D   2      System.Windows.VisualState  
Normal��   
Storyboard. 5E   6   �� 5F   7   5G   3     5H   2   	MouseOver��. 5I   6   �� .��5J   :   ��  g� Duration$ 0D�6I   	 �� To$
 GrayX�6V    �� 
TargetName$ ButtonBackground��6`    �� TargetProperty$0 *(Panel.Background).(SolidColorBrush.Color)�6�   5K   7   5L   3     5O   2   Pressed��. 5P   6   �� .��5Q   :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5R   7   5S   3   5T   /   .+�5W   *   ��  ��Name$ ButtonBackground��61   ���#333333���#333333$ 	15,0,0,15��6v   ._�5X   .   �� $��Center=�69   .+�5Y   2   �� $��Images/noitiep.png��68   $	��100��6T   $��50��6`   $��	-4,13,0,0q�6l   $��UniformToFill=�6   �� 5Z   2   $��Mạch nối tiếp��6<   $��16(�6Q   $��Center=�6_   $��0,8,0,0q�6|   
�������6�   5[   /   5\   +   5]   '   5^   #   5`      �� 5d      -   5        $��	MSSButton��5d   !   $	��124��62   $	��100��6>   
���   �$	��MSS��6�   ��6^   �� *SelectComponentCommand+��5e      �� 5f   "   " ��62   .R�5g   &   � $ 
ButtonGrid��6+    5h   *     5i   .   CommonStates��. 5j   2     
Normal��. 5k   6   �� 5l   7   5m   3     5n   2   	MouseOver��. 5o   6   �� .��5p   :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5q   7   5r   3     5s   2   Pressed��. 5t   6   �� .��5u   :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5v   7   5w   3   5x   /   .+�5z   *   �� $ ButtonBackground��61   ���#333333���#333333._�5{   .   �� $��Center=�69   .+�5|   2   �� $��Images/songsong.png��68   $	��118��6U   $��64��6a   $��-4,8,0,0q�6m   $��UniformToFill=�6   �� 5}   2   $��Mạch song song��6<   $��16(�6R   $��Center=�6`   $��0,-1,0,0q�6}   
�������6�   5~   /   5   +   5�   '   5�   #   5�      �� 5�      -   5        $
��Ampe��5�   !   $	��124��6-   $	��100��69   
���   ���5�      �� 5�   "   " ��62   .R�5�   &   � $ 
ButtonGrid��6+    5�   *     5�   .   CommonStates��. 5�   2     
Normal��. 5�   6   �� 5�   7   5�   3     5�   2   	MouseOver��. 5�   6   �� .��5�   :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3     5�   2   Pressed��. 5�   6   �� .��5�   :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3   5�   /   .+�5�   *   �� $ ButtonBackground��61   ���#333333���#333333._�5�   .   �� $��Center=�69   .+�5�   2   �� $��Images/Ampe.png��68   $��90��6Q   $��60��6\   $��
-3,11,-5,0q�6h   $��Uniform=�6|   �� 5�   2   $��	Ampe kế��6<   $��16(�6K   $��Center=�6Y   $��0,0,0,0q�6v   
�������6�   5�   /   5�   +   5�   '   5�   #   5�      �� 5�      -   5        $	��Von��5�   !   $	��124��6,   $	��100��68   
���   �$
��volt��6�   ��6X   �� *SelectComponentCommand+��5�      �� 5�   "   " ��62   .R�5�   &   � $ 
ButtonGrid��6+    5�   *     5�   .   CommonStates��. 5�   2     
Normal��. 5�   6   �� 5�   7   5�   3     5�   2   	MouseOver��. 5�   6   �� .��5�   :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3     5�   2   Pressed��. 5�   6   �� .��5�   :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3   5�   /   .+�5�   *   �� $ ButtonBackground��61   ���#333333���#333333._�5�   .   �� $��Center=�69   .+�5�   2   �� $��Images/Vôn.png��68   $��95��6P   $��60��6[   $��
-3,11,-3,0q�6g   $��Uniform=�6{   �� 5�   2   $��	Vôn kế��6<   $��16(�6J   $��Center=�6X   $��0,0,0,0q�6u   
�������6�   5�   /   5�   +   5�   '   5�   #   5�      �� 5�      -   5        $��	SourceBtn��5�   !   $	��124��62   $	��100��6>   
���   �$��Đèn��6�   ��6^   �� *SelectComponentCommand+��5�      �� 5�   "   " ��62   .R�5�   &   � $ 
ButtonGrid��6+    5�   *     5�   .   CommonStates��. 5�   2     
Normal��. 5�   6   �� 5�   7   5�   3     5�   2   	MouseOver��. 5�   6   �� .��5�   :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3     5�   2   Pressed��. 5�   6   �� .��5�   :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3   5�   /   .+�5�   *   �� $ ButtonBackground��61   ���#333333���#333333._�5�   .   �� $��Center=�69   .+�5�   2   �� $��Images/source.png��68   $	��110��6S   $��60��6_   $��
-3,11,-1,0q�6k   $��Uniform=�6   �� 5�   2   $��Nguồn��6<   $��16(�6I   $��Center=�6W   $��0,0,0,0q�6t   
�������6�   5�   /   5�   +   5�   '   5�   #   5�      �� 5�      -   5        $��Đèn��5�   !   $	��124��6,   $	��100��68   
���   ���5�      �� 5�   "   " ��62   .R�5�   &   � $ 
ButtonGrid��6+    5�   *     5�   .   CommonStates��. 5�   2     
Normal��. 5�   6   �� 5�   7   5�   3     5�   2   	MouseOver��. 5�   6   �� .��5�   :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3     5�   2   Pressed��. 5�   6   �� .��5�   :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�   7   5�   3   5   /   .+�5  *   �� $ ButtonBackground��61   ���#333333���#333333._�5  .   �� $��Center=�69   .+�5  2   �� $��Images/Den.png��68   $	��110��6P   $��58��6\   $��
-3,11,-2,0q�6h   $��Uniform=�6|   �� 5  2   $��Đèn��6<   $��16(�6G   $��Center=�6U   $��0,4,0,0q�6r   
�������6�   5  /   5  +   5  '   5	  #   5     �� 5     -   5        $��Khóa��5  !   $	��124��6-   $	��100��69   
���   ���5     �� 5  "   " ��62   .R�5  &   � $ 
ButtonGrid��6+    5  *     5  .   CommonStates��. 5  2     
Normal��. 5  6   �� 5  7   5  3     5  2   	MouseOver��. 5  6   �� .��5  :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5  7   5  3     5  2   Pressed��. 5  6   �� .��5  :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5   7   5!  3   5"  /   .+�5$  *   �� $ ButtonBackground��61   ���#333333���#333333._�5%  .   �� $��Center=�69   .+�5&  2   �� $��Images/khoa.png��68   $	��110��6Q   $��65��6]   $��
-3,11,-8,0q�6i   $��Uniform=�6}   �� 5'  2   $��Khóa K��6<   $��16(�6J   $��Center=�6X   $��0,-4,0,0q�6u   
�������6�   5(  /   5)  +   5*  '   5+  #   5-     �� 50     $
��10,0q�6$   $��1��62   
�������6<   �� 53     -   5        $
��Calc��53  !   $	��124��6-   $	��100��69   
���   ���54     �� 55  "   " ��62   .R�56  &   � $ 
ButtonGrid��6+    57  *     58  .   CommonStates��. 59  2     
Normal��. 5:  6   �� 5;  7   5<  3     5=  2   	MouseOver��. 5>  6   �� .��5?  :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5@  7   5A  3     5B  2   Pressed��. 5C  6   �� .��5D  :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5E  7   5F  3   5G  /   .+�5I  *   �� $ ButtonBackground��61   ���#333333���#333333._�5J  .   �� $��Center=�69   .+�5K  2   �� $��Images/calc.png��68   $	��110��6Q   $��60��6]   $��
-3,11,-6,0q�6i   $��Uniform=�6}   �� 5L  2   $��Tính toán��6<   $��16(�6M   $��Center=�6[   $��0,0,0,0q�6x   
�������6�   5M  /   5N  +   5O  '   5P  #   5R     �� 5U     -   5        $
��Undo��5U  !   $	��124��6-   $	��100��69   
���   ���5V     �� 5W  "   " ��62   .R�5X  &   � $ 
ButtonGrid��6+    5Y  *     5Z  .   CommonStates��. 5[  2     
Normal��. 5\  6   �� 5]  7   5^  3     5_  2   	MouseOver��. 5`  6   �� .��5a  :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5b  7   5c  3     5d  2   Pressed��. 5e  6   �� .��5f  :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5g  7   5h  3   5i  /   .+�5k  *   �� $ ButtonBackground��61   ���#333333���#333333._�5l  .   �� $��Center=�69   .+�5m  2   �� $��Images/UndoIcon.png��68   $	��110��6U   $��60��6a   $��
-3,11,-1,0q�6m   $��Uniform=�6�   �� 5n  2   $
��Undo��6<   $��16(�6H   $��Center=�6V   $��0,1,0,0q�6s   
�������6�   5o  /   5p  +   5q  '   5r  #   5t     �� 5w     -   5        $
��Redo��5w  !   $	��124��6-   $	��100��69   
���   ���5x     �� 5y  "   " ��62   .R�5z  &   � $ 
ButtonGrid��6+    5{  *     5|  .   CommonStates��. 5}  2     
Normal��. 5~  6   �� 5  7   5�  3     5�  2   	MouseOver��. 5�  6   �� .��5�  :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�  7   5�  3     5�  2   Pressed��. 5�  6   �� .��5�  :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�  7   5�  3   5�  /   .+�5�  *   �� $ ButtonBackground��61   ���#333333���#333333._�5�  .   �� $��Center=�69   .+�5�  2   �� $��Images/RedoIcon.png��68   $	��110��6U   $��60��6a   $��
-3,11,-1,0q�6m   $��Uniform=�6�   �� 5�  2   $
��Redo��6<   $��16(�6H   $��Center=�6V   $��0,1,0,0q�6s   
�������6�   5�  /   5�  +   5�  '   5�  #   5�     �� 5�     -   5        $��Check��5�  !   $	��124��6.   $	��100��6:   
���   ���5�     �� 5�  "   " ��62   .R�5�  &   � $ 
ButtonGrid��6+    5�  *     5�  .   CommonStates��. 5�  2     
Normal��. 5�  6   �� 5�  7   5�  3     5�  2   	MouseOver��. 5�  6   �� .��5�  :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�  7   5�  3     5�  2   Pressed��. 5�  6   �� .��5�  :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�  7   5�  3   5�  /   .+�5�  *   �� $ ButtonBackground��61   ���#333333���#333333._�5�  .   �� $��Center=�69   .+�5�  2   �� $��Images/CheckIcon.png��68   $	��110��6V   $��70��6b   $��	-3,6,-1,0q�6n   $��Uniform=�6�   �� 5�  2   $��Kiểm tra đèn��6<   $��16(�6P   $��Center=�6^   $��0,-4,0,0q�6{   
�������6�   5�  /   5�  +   5�  '   5�  #   5�     �� 5�     -   5        $
��Xóa��5�  !   $	��124��6,   $	��100��68   
���   ���5�     �� 5�  "   " ��62   .R�5�  &   � $ 
ButtonGrid��6+   $	��141��6?    5�  *     5�  .   CommonStates��. 5�  2     
Normal��. 5�  6   �� 5�  7   5�  3     5�  2   	MouseOver��. 5�  6   �� .��5�  :   �� $ 0D�6I   $
 GrayX�6V   $ ButtonBackground��6`   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�  7   5�  3     5�  2   Pressed��. 5�  6   �� .��5�  :   �� $ 0D�6I   $ DarkGrayX�6V   $ ButtonBackground��6d   $0 *(Panel.Background).(SolidColorBrush.Color)�6�   5�  7   5�  3   5�  /   .+�5�  *   �� $ ButtonBackground��61   ���#333333���#333333$��0,0,23,0q�6v   $ 	0,15,15,0��6�   ._�5�  .   �� $��Center=�69   .+�5�  2   �� $��Images/Delete.png��68   $	��110��6S   $��60��6_   $��
-3,11,-1,0q�6k   $��Uniform=�6   �� 5�  2   $
��Xóa��6<   $��16(�6G   $��Center=�6U   $��0,0,0,0q�6r   
�������6�   5�  /   5�  +   5�  '   5�  #   5�     5�     5�     5�     5�     � 5�  
   $��1��6    � ColumnDefinitions 5�     �� 5�     $	��250 �6#   �� 5�     $��* �6#   .+�5�     �� $��0��6   ���#f3f4f6���#d1d5db$��1q�6P   ._�5�     �� $
��Auto=�6   $��Disabled=�6B   .��5�     �� -   5        $��Sidebar��5�  !   $��10q�60   .+�5�     �� $��Giá trị R��6$   $��16(�65   $
��Bold"�6C   ���#374151$��0 0 0 10q�6j   5�     5�     5�     �� 5�     -   5        $��ZoomScrollViewer��5�  +   $��1��6   $
��Auto=�6C   $
��Auto=�6h   .��5�     � -   5        $��ZoomableContent��5�     .+�5�     �� -   5        $��CircuitCanvas��5�     
�������z�5�     V� 5�     .~�5�  "   �� -   5        CanvasScaleTransform�� �� ScaleX$ 1Q�5�  O    �� ScaleY$ 1Q�6Z   T� 5�  "   -   5        CanvasTranslateTransform�� T� X$ 0Q�5�  W    T� Y$ 0Q�6]   5�     .+�5�     �� 
������ $
��3000��67   $
��3000��6D   5�     5�     5      5     5     5     