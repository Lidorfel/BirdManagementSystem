   M S B A M L   `   `   `  ����O  KBirdManagementSystem, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BirdManagementSystemBirdManagementSystem  5   	   %    BirdManagementSystem.CageWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   .local"clr-namespace:BirdManagementSystem  5   	    !  MaterialDesignLightForeground#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������   MaterialDesignFont#���  5   	    � Title$ 
CageWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � AllowsTransparency .  � WindowStyle$
 None=�6t    � 
ResizeMode$ NoResize=�6�   .��5      � ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$	 #dc4c3c��6   
 � Offset$
 1Q�6/   � 5      $	 	#FFFE8704��6   63   5      .+�5   
   �� $	��390��6   $	��800��6   $	��Top=�6*    �� CornerRadius$ 	0 0 180 0��6B   ���#0c0c4c6[   �� 5   
   $��Center=�6   $��Eras ITC)�61   $��0,27,0,0q�6G   $
��Wrap=�6Y   $��	Cage Page��6m   $	��Top=�6~   $��63��6�   $	��410��6�   ���	#FFCC6E06 �� TextAlignment$ Center=�6�   $��40(�6�   $��SemiBold"�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5!      �� 5"   
   $
��Wrap=�6   $��Cage Serial Number : ��6(   $��82,101,571,305q�6E   ���	#DDFFFFFF{�.  6t   �� 5#   
   �� 5$   
   $
��Wrap=�6   $��Dimensions : ��6(   $��314,101,339,305q�6=   ���	#DDFFFFFF{�.  6m   � 5%   
   ��5'      �� 5(      $ 0.1,0&�6&   $ 0.9,1&�69   .��5)      � $	 #dc4c3c��6#   $
 1Q�63   � 5*      $	 	#FFFE8704��6#   5+      .+�5.      �� $	��390��6   $	��800��6"   $	��Top=�6.   $ 	0 0 180 0��6F   ���#0c0c4c50      �� 53      $��Center=�6   $��Eras ITC)�65   $��0,27,0,0q�6K   $
��Wrap=�6]   $��	Cage Page��6q   $	��Top=�6�   $��63��6�   $	��410��6�   ���	#FFCC6E06$ Center=�6�   $��40(�6�   $��SemiBold"�6�    54        55      57      �� 58      $
��Wrap=�6   $��Cage Serial Number : ��6,   $��22,90,628,303q�6I   ���	#DDFFFFFF{�.  6w   �� 59      �� 5:      $
��Wrap=�6   $��Dimensions : ��6,   $��22,136,692,256q�6A   ���	#DDFFFFFF{�.  6p   �� 5;      $
��Wrap=�6   $��Material : ��6,   $��22,183,700,202q�6?   ���	#DDFFFFFF{�.  6n   �� 5<      -   5         ��Name$ CageSN��5<      $
��Wrap=�6(   $��172,90,548,303q�6<   ���	#DDBDBDBD{�.  6k   �� 5=      -   5        $ CageDimension��5=      $
��Wrap=�6/   $��108,136,565,251q�6C   ���	#DDBDBDBD{�.  6s   �� 5>      -   5        $ CageMaterial��5>      $
��Wrap=�6.   $��100,183,614,202q�6B   ���	#DDBDBDBD{�.  6r   5A      �� 5B   
   -   5         ��Name$ ShowBirdsBtn��5B      $��
Show Birds��6'   $��23,246,604,172q�6<   ���	#FFCC6E06���	#DDFFFFFF6�   �� 5C   
   -   5         ��Name$ CagePicture��5C      $y�Visible=�6%   $��Images/CageImage.png��6:    J� RenderTransformOrigin$ 0.5,0.5&�6X    J� Opacity$	 0.7Q�6x   $	��198��6�   $	��198��6�   $��540,109,62,143q�6�    5D        5E      z�5G      V� 5H      .~�5I      ��  �� ScaleX$ -1Q�6%   �� 5J      �� 5K      T� 5L      5M      5O      &   System.Windows.Controls.DataGrid  5Q   
   -   5          Name$ BirdsInCageGrid��5Q   A   $y�	Collapsed=�6      CanUserAddRows .  $��236,111,39,107q�6Z   $ 
0.51,0.963&�6r   ��5R      �� 5S      $ 0.5,4&�6&   $ 0.5,0&�67    � SpreadMethod$	 Pad=�6J   .��5T      � $	 	#FF0C0C4C��6#   $
 0.285Q�65   � 5U      $	 	#FFCC6E06��6#   $
 0.234Q�65   � 5V      $	 	#FF0C0C4C��6#   $

 0.25Q�65   5W      5Z      �� 5[   
   -   5        $ backToHomePage��5[      $��	Home Page��6)   $��23,293,604,125q�6=   ���	#FFCC6E06���	#DDFFFFFF6�   �� 5\   
   -   5        $ UpdateCageBtn��5\      $��Update Cage��6(   $��23,340,604,78q�6>   ���	#FFCC6E06���	#DDFFFFFF6�   � 5]   
   -	   5         �Name$ UpdateFieldsGrid��5]      $y�	Collapsed=�6)   .+�5^      �� -
   5         ��Name$ NewCageSerialNumber��5^      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Cage Serial Number��63   
�������
������� �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#ffd94448$��266,91,290,324q�6�   �� 5_      -   5        $ NewCageWidth��5_      $ Width��6,   
�������
������� �	#FFD94448 �	#ffd94448$��266,162,456,252q�6�   �� 5`      -   5        $ NewCageLength��5`      $ Length��6-   
�������
������� �	#FFD94448 �	#ffd94448$��350,162,372,252q�6�   �� 5a      -   5        $ NewCageHeight��5a      $ Height��6.   
�������
������� �	#FFD94448 �	#ffd94448$��434,162,290,252q�6�   �� 5b      -   5         ��Name$ NewCageMaterialSelect��5b      $
��Left=�66   $��266,236,0,0q�6Q   $	��Top=�6f   $	��244��6~   
�������$ Cage Material��6�   ���	#FFCC6E06.@�5c      �� $
��Iron��6   �� 5d      $
��Wood��6   �� 5e      $��Plastic��6   5f      �� 5g      -   5        $ NewCageSerialNumberError��5g      $��Eras ITC)�6:   $�� ��6P   
���  ��$��266,128,290,291q�6i   $
��Wrap=�6�   �� 5h      -   5        $ NewCageDimensionError��5h      $��Eras ITC)�67   $�� ��6M   
���  ��$��266,200,290,219q�6f   $
��Wrap=�6   �� 5i      -   5        $  NewCageMaterialSelectError��5i      $��Eras ITC)�6<   $�� ��6R   
���  ��$��266,262,290,168q�6k   $
��Wrap=�6�   �� 5j      -   5        $ UpdateDetails��5j      $��Update��6,   $��266,293,361,125q�6=   ���	#FFCC6E06���	#DDFFFFFF6�   5k      5m      5n      