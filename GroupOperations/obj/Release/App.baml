   M S B A M L   `   `   `  ���� G  CAddExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AddExtensionAddExtension      AddExtension.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ,localclr-namespace:AddExtension       �� 	Resources   �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value	 �� 
TargetName   ComboBoxNormalBorderBrush
 �� Color ! ComboBoxNormalBackgroundBrush # ComboBoxDisabledForegroundBrush # ComboBoxDisabledBackgroundBrush  ComboBoxDisabledBorderBrush   ComboBoxToggleButtonTemplate � ColumnDefinitions �� CornerRadius �� 	ClickMode d� 	IsChecked �� Path �� RelativeSource �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate �� 
IsReadOnly �� 
IsReadOnly � AllowsTransparency �� IsDropDownOpen � ActualWidth �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation  CheckRadioFocusVisual �� StrokeDashArray � 	Resources  Key �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame  O� KeyTime! O� Value" �� 
Background# �� Bullet$ ��Name% J� RenderTransformOrigin& J� Effect3  -System.Windows.Media.Effects.DropShadowEffect'   ShadowDepth(   	Direction) N� EnterActions* ��Name  StoryboardIsChecked+ �� BeginStoryboardName 	 StoryboardIsCheckedOff, �� Padding- �Name. ��Name��%�  '��       &	  �    &	 �    &	 �    &	     &	     &	 "    7   7  7  7  7  7  7  '�� �    7  7   7  &	 �
    '��     7  7  7 	 '�     �� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#ffffff��  � �� �#cccccc��  � ��$ 1q���  � �� �#333333��  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R��� $��Chrome��#��z��#��z��#��z�� . ._��� $��	Presenter��#��z��#��z��#��z����. # z  P�  � {� .  . ���  � ��
 �������  � ��
 �����P�  �@J�IsMouseOver . . ���  � �� �#dddddd��  � �� �#cccccc��  � �� �#333333P�  � �� . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP�  �@J�	IsFocused . . ��� $	 Chrome�� � �� �#1ba1e2�� $
 #cccccc���� $

 #fff���� $

 #888���� $

 #eee���� $

 #888���� " d�.R��  �� �� $��20 �.+��� $��Border��$��2��8��  $ 0��$��
1, 1, 1, 1q�8�� �� $��ButtonBorder��$��1��$��
1, 1, 1, 1q����#444$ 
0, 0, 0, 0��$��
0, 0, 0, 0q�8�� F� $��Arrow��$��1��=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=����#444$��Center=� P�  �@J�IsMouseOver . . ��� $	 ButtonBorder�� � ��
 �����P�  �@d�	IsChecked$
 TrueY�. ��� $	 ButtonBorder�� � ��
 ������� $	 Arrow�� � �� �	#FF8D979EP�  � {� .  . ��� $	 Border��8   � ���� $	 ButtonBorder��8   � ���� $	 ButtonBorder��8   � ���� 8   � ���� $	 Arrow�� � �� �#999�� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��
 �   ���  �@�FocusVisualStyle Z� ��  � �� �� " ��.R�� .+�d� $��ToggleButton��$��2��$ Press=�|�.  8��   �� $ IsDropDownOpen� �� *TemplatedParent+$ TwoWay=��� $��ContentSite��$��5, 3, 23, 3q� .  $
��Left=�$��Center=�#��z #��z #��z���� $��PART_EditableTextBox��$��3, 3, 23, 3q�# z $y�Hidden=�
������ $
��Left=�$��Center=�|�. .������ " ��.R��� $��PART_ContentHost��|�.  .��� $��Popup��$��Bottom=�|�.   . #��z $��Slide=�.��� $��DropDown�� . #��z #��z .+��� $��DropDownBorder��
�������$��
0, 1, 0, 0q�$ 0��$��1,1,1,1q�8�� �� $��4q� . .���� $ 	Contained=� P�  �@��HasItems .  . ��� $	 DropDownBorder�� � ��$ 95��P�  � {� .  . ��� 8   � ��P�  �@��
IsGrouping . . ���  � �� .  P�  �@��
IsEditable . . ���  �@ 	IsTabStop .  �� $	 PART_EditableTextBox�� � y�$ Visible=��� $	 ContentSite�� � y�$ Hidden=��� .���  � �� �� .R��� $��14,0,0,0q� . #��� ��$��1��$	 1 2R��� " ��.���  � ��# � ����  � ��$ 1q���  �@�Cursor$
 Hand����  � �� �� " �� ���� StoryboardIsChecked .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	CheckFlag��.\�  $  0��$! 0Q�  $  0:0:0.2��$! 14Q��� StoryboardIsCheckedOff .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	CheckFlag��.\�  $  0��$! 14Q�  $  0:0:0.2��$! 0Q�.R��� 
" ����  . # �� $$ ForegroundPanel��$��1q�$��35��$��20��$ 10��._��� .+��� $$ 	CheckFlag��
�������$ 10��$��Center=�$��1q�$��19��$��18��$% 0.5,0.5&�z�V� .~��� �� �� T� &   $' 1Q�$	( 180Q�._��� #��z��#��z����. # z $��Center=� P�  � �� . . ��� 8    �@�FocusVisualStyle��  � ��$ 4,0,0,0q�P�  � {� .  . ��� # � �� � ��P�  �@d�	IsChecked$
 TrueY�. ��� $	 ForegroundPanel�� � �� �	#FF49A3E1) �� $ * BeginStoryboardCheckedTrue��8�� �� $!+ BeginStoryboardCheckedFalse��P�  �@d�	IsChecked$ FalseY�. ��� $	 ForegroundPanel�� � �� �#9D0002) �� $!* BeginStoryboardCheckedFalse��8�� �� $ + BeginStoryboardCheckedTrue���� " �.���  � �� �#cccccc��  � ��$ 1q���  �@J�SnapsToDevicePixels . ��  � �� �� " �.R��� ���#D9DCE1$��1q����#E8E8E8$ 0��$, 0q�._�� $- 
PART_Track��.+��� $. PART_Indicator��$
��Left=�#��z��