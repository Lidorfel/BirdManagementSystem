   M S B A M L   `   `   `  ����O  KBirdManagementSystem, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BirdManagementSystemBirdManagementSystem  5   	        BirdManagementSystem.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   .local"clr-namespace:BirdManagementSystem  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������   MaterialDesignFont#���  5   	    � Title$ Login��5   	   $	��450��6   $	��800��6%    � WindowStartupLocation$ CenterScreen=�61    � AllowsTransparency .  � WindowStyle$
 None=�6p    � 
ResizeMode$ NoResize=�6�   .��5      � $
��Auto��6   $
��Auto��6   ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$	 #dc4c3c��6   
 � Offset$
 1Q�6/   � 5      $	 	#FFFE8704��6   63   5      .+�5   
   �� $	��390��6   $	��800��6   $	��Top=�6*    �� CornerRadius$ 	0 0 180 0��6B   ���#0c0c4c5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $	��350��6   .+�5      �� $��Images/BirdLogin.png��6    J� RenderTransformOrigin$ 0.5,0.5&�66   $	��344��6V   $	��396��6b   z�5      V� 5       .~�5!      ��  �� ScaleX$ -1Q�6-   �� 5"      �� 5#      T� 5$      5%      5'      5(      �� 5)      $	��350��6   .+�5*      �� $��20 40q�6   .+�5+      �� $��
User Login��6    $��20q�62   
������� �� TextAlignment$ Center=�6Q   $��38(�6h   $��Eras ITC)�6v   6�   �� 5,      $ 
Horizontal=�6!   $��10q�6:   .+�5-      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�62   $��25��6>   $��25��6I   
�������6U   �� 5.      -   5         ��Name$ UserName��5.   K    �� 	MaxLength$ 8��6=   $
��10 0q�6]   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username��6k   
�������$	��250��6�   
������� �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#ffd944486�   5/      �� 50      $ 
Horizontal=�6!   $��10q�6:   .+�51        $ Password=�62   $��25��6B   $��25��6M   
�������6Y   G� 52      -   5         G�Name$ Password��52   E   $
��10 0q�6W   $ Enter Password��6e   
�������$	��250��6�   
������� G� 
CaretBrush �	#FFD94448 G� SelectionBrush �	#ffd944486�   53      �� 54      -   5         ��Name$ 
ErrorBlock��54       $��Eras ITC)�65   $�� ��6K   
���  ��$��40��6d   $��	0 0 -40 0q�6p   $	��260��6�   $
��Wrap=�6�   � 55      $��74��6   .+�56      �� -   5         ��Name$ LoginBtn��56     $	��100��6!   $��40��6-     MaterialDesignRaisedButton#��[ 69   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6m   $��2q�6�   ���#d94448���#d94448
�������$��Login��6�    � ToolTip$ Login��6�   $��
42,0,168,0q�66  �� 58      -   5        $ RegisterBtn��58     $	��100��6!   $��40��6-   #��[ 69   $ 10��6m   $��2q�6�   ���#d94448���#d94448
�������$��Register��6�   $ Register��6   $��
200,0,10,0q�6B  59      5<      5=      �� 5>      $	��100��6   .+�5?      �� -   5        $ ExitBtn��5?   �   ���#0c0c4c$��10 20q�60    & "MaterialDesignFloatingActionButton#��[ 6?   $ Close��6�   ���	#FF0C0C4C��6{   Z� .��5@        $ Close=�6.   
�������$��30��6N   6[   5A      5B      5D      5G      5H      