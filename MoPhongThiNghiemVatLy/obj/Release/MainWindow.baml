   M S B A M L   `   `   `  ���� P  LMoPhongThiNghiemVatLy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MoPhongThiNghiemVatLyMoPhongThiNghiemVatLy  &     MoPhongThiNghiemVatLy.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:MoPhongThiNghiemVatLy       � WindowState$  	Maximized=� � Title$/ )Phần Mềm Thí Nghiệm Mạch Điện��$	��500��$
��1500�� � Icon$ Images/IconOfApp.png�� � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation	 K� IsItemsHost��%�   'o�       'c� =     �� " o�.���  � ��
 �   ���  � ��
 ������� " c�.���  � �� �� " c�.R��� #��z��#��z��#��z��._��� $ 
Horizontal=�	 . .��� 
 � RowDefinitions
 �� $
��Auto ��� $��* �.+�]� 
���   �$��0��.+�o� $	��Top=�$��25��.@�m� -   $	��New��$��30��$��80��m� -   $
��Open��$��30��$��90��m� -   $
��Save��$��30��$��80��m� -   $��Save As��$��30��$	��120��m� -   $��Export��$��30��$	��100��m� $
��Edit��$��30��$��80��.@�m� -   $
��Undo��
���   �m� -   $
��Redo��
���   �m� -   $
��Help��$��30��$��82���� $	��Top=�$��9q����#333333 �� CornerRadius$ 15��._�`�  `� 
Background
 ���� .�c� -	   $��ComponentToolBar��
������ $	��Top=�.@��� -
   $��	MNTButton��$	��124��$	��100��
���   �$	��MNT������ *SelectComponentCommand+���� " ��.R��  �Name$ 
ButtonGrid��'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  CommonStates��   States.    System.Windows.VisualState  
Normal��   
Storyboard. ��   	MouseOver��. �� .����  g� Duration$ 0D�	 �� To$
 GrayX� �� 
TargetName$ ButtonBackground�� �� TargetProperty$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+���  ��Name$ ButtonBackground�����#333333���#333333$ 	15,0,0,15��._��� $��Center=�.+��� $��Images/noitiep.png��$	��100��$��50��$��	-4,13,0,0q�$��UniformToFill=��� $��Mạch nối tiếp��$��16(�$��Center=�$��0,8,0,0q�
��������� -   $��	MSSButton��$	��124��$	��100��
���   �$	��MSS������ *SelectComponentCommand+���� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/songsong.png��$	��118��$��64��$��-4,8,0,0q�$��UniformToFill=��� $��Mạch song song��$��16(�$��Center=�$��0,-1,0,0q�
��������� -   $
��Ampe��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/Ampe.png��$��90��$��60��$��
-3,11,-5,0q�$��Uniform=��� $��	Ampe kế��$��16(�$��Center=�$��0,0,0,0q�
��������� -   $	��Von��$	��124��$	��100��
���   �$
��volt������ *SelectComponentCommand+���� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/Vôn.png��$��95��$��60��$��
-3,11,-3,0q�$��Uniform=��� $��	Vôn kế��$��16(�$��Center=�$��0,0,0,0q�
��������� -   $��	SourceBtn��$	��124��$	��100��
���   �$��Đèn������ *SelectComponentCommand+���� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/source.png��$	��110��$��60��$��
-3,11,-1,0q�$��Uniform=��� $��Nguồn��$��16(�$��Center=�$��0,0,0,0q�
��������� -   $��Đèn��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/Den.png��$	��110��$��58��$��
-3,11,-2,0q�$��Uniform=��� $��Đèn��$��16(�$��Center=�$��0,4,0,0q�
��������� -   $��Khóa��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/khoa.png��$	��110��$��65��$��
-3,11,-8,0q�$��Uniform=��� $��Khóa K��$��16(�$��Center=�$��0,-4,0,0q�
��������� $
��10,0q�$��1��
��������� -   $
��Calc��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/calc.png��$	��110��$��60��$��
-3,11,-6,0q�$��Uniform=��� $��Tính toán��$��16(�$��Center=�$��0,0,0,0q�
��������� -   $
��Undo��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/UndoIcon.png��$	��110��$��60��$��
-3,11,-1,0q�$��Uniform=��� $
��Undo��$��16(�$��Center=�$��0,1,0,0q�
��������� -   $
��Redo��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/RedoIcon.png��$	��110��$��60��$��
-3,11,-1,0q�$��Uniform=��� $
��Redo��$��16(�$��Center=�$��0,1,0,0q�
��������� -   $��Check��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333._��� $��Center=�.+��� $��Images/CheckIcon.png��$	��110��$��70��$��	-3,6,-1,0q�$��Uniform=��� $��Kiểm tra đèn��$��16(�$��Center=�$��0,-4,0,0q�
��������� -   $
��Xóa��$	��124��$	��100��
���   ����� " ��.R�� $ 
ButtonGrid��$	��141��   CommonStates��.   
Normal��. ��   	MouseOver��. �� .���� $ 0D�$
 GrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�  Pressed��. �� .���� $ 0D�$ DarkGrayX�$ ButtonBackground��$0 *(Panel.Background).(SolidColorBrush.Color)�.+��� $ ButtonBackground�����#333333���#333333$��0,0,23,0q�$ 	0,15,15,0��._��� $��Center=�.+��� $��Images/Delete.png��$	��110��$��60��$��
-3,11,-1,0q�$��Uniform=��� $
��Xóa��$��16(�$��Center=�$��0,0,0,0q�
�������� $��1�� � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0�����#f3f4f6���#d1d5db$��1q�._��� $
��Auto=�$��Disabled=�.���� -   $��Sidebar��$��10q�.+��� $��Giá trị R��$��16(�$
��Bold"����#374151$��0 0 0 10q��� -   $��ZoomScrollViewer��$��1��$
��Auto=�$
��Auto=�.��� -   $��ZoomableContent��.+��� -   $��CircuitCanvas��
�������z�V� .~��� -   CanvasScaleTransform�� �� ScaleX$ 1Q� �� ScaleY$ 1Q�T� -   CanvasTranslateTransform�� T� X$ 0Q� T� Y$ 0Q�.+��� 
������ $
��3000��$
��3000��