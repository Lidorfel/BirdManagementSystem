   M S B A M L   `   `   `  ����O  KBirdManagementSystem, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BirdManagementSystemBirdManagementSystem  5   	   #    BirdManagementSystem.Register   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   .local"clr-namespace:BirdManagementSystem  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������   MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�6H    � 
ResizeMode$ NoResize=�6[    � Title$ Register��6q   $	��450��6�   $	��800��6�   .��5      � $
��Auto��6   $
��Auto��6   ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$	 #dc4c3c��6   
 � Offset$
 1Q�6/   � 5      $	 	#FFFE8704��6   63   5      .+�5   
   �� $	��390��6   $	��800��6   $	��Top=�6*    �� CornerRadius$ 	0 0 180 0��6B   ���#0c0c4c6[   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $	��350��6   .+�5      �� $��Images/BirdLogin.png��6    J� RenderTransformOrigin$ 0.5,0.5&�66   $	��344��6V   $	��396��6b   z�5      V� 5      .~�5       ��  �� ScaleX$ -1Q�6-   �� 5!      �� 5"      T� 5#      5$      5&      5'      �� 5(      $	��350��6   .+�5)      �� $��20 40q�6   .+�5*      �� $��Registration��6    $��20q�64   
������� �� TextAlignment$ Center=�6S   $��38(�6j   $��Eras ITC)�6x   6�   �� 5+      $ 
Horizontal=�6!   $��10q�6:   .+�5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�62   $��25��6>   $��25��6I   
�������6U   �� 5-      -   5         ��Name$ UserName��5-   b   $��Eras ITC)�6#    �� 	MaxLength$ 8��6T   $
��10 0q�6t   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username��6�   
�������$	��250��6�   
������� �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#ffd944486�   5.      �� 5/      $ 
Horizontal=�6!   $��10q�6:   .+�50        $ Password=�62   $��25��6B   $��25��6M   
�������6Y   �� 51      -   5        $ Password��51   S   $��Eras ITC)�6"   $
��10 0q�6e   $ Enter Password��6s   
�������$	��250��6�   
������� �	#FFD94448 �	#ffd944486�   52      �� 53      $ 
Horizontal=�6!   $��10q�6:   .+�54        $ IdCard=�62   $��25��6@   $��25��6K   
�������6W   �� 55      -   5        $ ID��55   T   $��Eras ITC)�6>   $
��10 0q�6`   $ ID��6n   
�������$	��250��6�   
������� �	#FFD94448 �	#ffd944486�   56      � 57      $��64��6   .+�58      �� -   5         ��Name$ 
ErrorBlock��58   2   $��14(�6$   $��Eras ITC)�6G   $�� ��6]   
���  ��$��40��6v   $��	0 0 -40 0q�6�   $	��260��6�   $
��Wrap=�6�   �� 59      -   5         ��Name$ RegisterBtn��59     $��40��6!     MaterialDesignRaisedButton#��[ 6-   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6a   $��2q�6�   ���#d94448���#d94448
�������$��Register��6�    � ToolTip$ Register��6�   $��42,68,46,-44q�66  5:      5=      5>      �� 5?      $	��100��6   .+�5@      �� -   5        $ ExitBtn��5@   �   ���#0c0c4c$��10 20q�6/    & "MaterialDesignFloatingActionButton#��[ 6>   $ Close��6�   ��6z   Z� .��5A        $ Close=�6.   
�������$��30��6N   6[   5B      5C      5E      5H      5I      