   M S B A M L   `   `   `  ����L  HSquareProgressBar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SquareProgressBarSquareProgressBar  5   	   "    SquareProgressBar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SquareProgressBar     5   	   $��20q�5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5         
HatchBrush j� TileMode j� Viewport j� ViewportUnits j� Viewbox j� ViewboxUnits !� Visual  SquaredProgressBar �� 
TargetType	 �� Property
 �� Value#   SquareProgressBar.SquareShape   MaxValue �� RelativeSource   Value �� StringFormat��%<  &	        &	 E    7   !� 5   
   $
 Tile=�6+   $ 	0,0,10,10�6;   $ Absolute=�6Q   $ 	0,0,10,10�6j   $ Absolute=�6~    5      �� 5      .+�5      �� 
�������$��10��6-   $��10��68   F� 5      
���� ������        р�� ��� 	6+   F� 5      
���� ������    ��� р��     	6+   5      5      �� 5   
   " �6+   .�5      �� 	 � ��
 5      �� 5      .R�5      � .+�5        $��2��61   8��   5   1   �� *	Maximum+ �� *TemplatedParent+ 5   1   �� *Value+ �� *TemplatedParent+5      �� 5       #��z��5!      $��Center=�5"      $��Center=�5#      $��72(�5$      $
��Bold"�5%      ��5    (   �� *Value+ �� *TemplatedParent+$ {0:0}��5%      5&      5'      5)      5*      5+      .��5-      �  � RowDefinitions 5.   
   �� 5/      $	��100 �6   6+   �� 50      6   �� 51      $	��100 �6   6+   .+�54   
   �� $��5q�6   $��0��6   #��[  6)   $	��100��6R   $	��100��6_   6m   � 56   
   -   5        $��progress��56      $��1��6&   $	��200��57      $	��200��58       � Maximum$	 100Q�59      #��[  5:      #��[ 5;      6D   �� 5=   
   $��5q�6   $��2��6   #��[  6)   $	��100��6R   $	��100��6_   6m   5>       � Triggers 5@      :� 5A   
    :� RoutedEvent$ Window.Loaded��6   .[�5B      �� .��5C      ��  g� RepeatBehavior$ Forever��6   .��5D      W�  W� From$ 0X�6&   	 W� To$	 100X�5E   &    �� 
TargetName$ progress��5F   &    �� TargetProperty$ Value�5G   &    g� Duration$ 0:0:10D�5H   &   5I      5J      5K      5L      5O      