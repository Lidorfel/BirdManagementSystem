   M S B A M L   `   `   `  ����O  KBirdManagementSystem, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BirdManagementSystemBirdManagementSystem  5   	   %    BirdManagementSystem.BirdWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   .local"clr-namespace:BirdManagementSystem  5   	    !  MaterialDesignLightForeground#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������   MaterialDesignFont#���  5   	    � Title$ 
BirdWindow��5   	   $	��600��6   $	��900��6)    � WindowStartupLocation$ CenterScreen=�65    � AllowsTransparency .  � WindowStyle$
 None=�6t    � 
ResizeMode$ NoResize=�6�   .��5      � ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$	 #dc4c3c��6   
 � Offset$
 1Q�6/   � 5      $	 	#FFFE8704��6   63   5      .+�5   
   �� $	��390��6   $	��800��6   $	��Top=�6*    �� CornerRadius$ 	0 0 180 0��6B   ���#0c0c4c6[   �� 5   
   $��Center=�6   $��Eras ITC)�61   $��0,27,0,0q�6G   $
��Wrap=�6Y   $��	Cage Page��6m   $	��Top=�6~   $��63��6�   $	��410��6�   ���	#FFCC6E06 �� TextAlignment$ Center=�6�   $��40(�6�   $��SemiBold"�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   $
��Wrap=�6   $��Cage Serial Number : ��6(   $��82,101,571,305q�6E   ���	#DDFFFFFF{�.  6t   �� 5    
   �� 5!   
   $
��Wrap=�6   $��Dimensions : ��6(   $��314,101,339,305q�6=   ���	#DDFFFFFF{�.  6m   � 5"   
   ��5#      �� 5$      $ 0.1,0&�6&   $ 0.9,1&�69   .��5%      � $	 #dc4c3c��6#   $
 1Q�63   � 5&      $	 	#FFFE8704��6#   5'      .+�5)      �� $	��530��6   $	��900��6"   $	��Top=�6.   $ 	0 0 180 0��6F   ���#0c0c4c$��0,-1,0,0q�6t   5+      �� 5,      $��Center=�6   $��Eras ITC)�65   $��0,27,0,0q�6K   $
��Wrap=�6]   $��	Bird Page��6q   $	��Top=�6�   $��63��6�   $	��410��6�   ���	#FFCC6E06$ Center=�6�   $��40(�6�   $��SemiBold"�6�    5-        5.      50      �� 51      $
��Wrap=�6   $��Bird Serial Number : ��6,   $��22,99,717,451q�6I   ���	#DDFFFFFF{�.  6w   �� 52      �� 53      $
��Wrap=�6   $��	Gender : ��6,   $��22,255,717,292q�6=   ���	#DDFFFFFF{�.  6l   �� 54      $
��Wrap=�6   $��Cage Serial Number :��6,   $��22,294,717,249q�6H   ���	#DDFFFFFF{�.  6w   �� 55      -   5         ��Name$ CurrentBirdSN��55      $
��Wrap=�6/   $��183,99,574,451q�6C   ���	#DDBDBDBD{�.  $�� ��6�   �� 56      -   5        $ CurrentGender��56      $
��Wrap=�6/   $��183,254,574,291q�6C   ���	#DDBDBDBD{�.  $�� ��6�   �� 57      -   5        $ CurrentCageSN��57      $
��Wrap=�6/   $��183,294,574,249q�6C   ���	#DDBDBDBD{�.  $�� ��6�   �� 58      $
��Wrap=�6   $��
Species : ��6,   $��22,138,717,412q�6>   ���	#DDFFFFFF{�.  6m   �� 59      -   5        $ CurrentSpecies��59      $
��Wrap=�60   $��183,138,574,412q�6D   ���	#DDBDBDBD{�.  $�� ��6�   �� 5:      $
��Wrap=�6   $��Hatch Date :��6,   $��22,216,717,334q�6@   ���	#DDFFFFFF{�.  6o   �� 5;      -   5        $ CurrentHatchDate��5;      $
��Wrap=�62   $��183,214,555,331q�6F   ���	#DDBDBDBD{�.  $�� ��6�   �� 5<      $
��Wrap=�6   $��Sub Species : ��6,   $��22,177,717,373q�6B   ���	#DDFFFFFF{�.  6q   �� 5=      -   5        $ CurrentSubSpecies��5=      $
��Wrap=�63   $��183,177,574,373q�6G   ���	#DDBDBDBD{�.  $�� ��6�   �� 5>      -   5        $ addNewChickSuccess��5>      $
��Wrap=�64   $��432,465,262,71q�6H   ���	#FF209B0A$ Center=�6w   $��16(�6�   �� 5?      -   5         ��Name$ BirdSerialUpdate��5?   -   $y�	Collapsed=�6   $��153,94,574,482q�6G   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ New Bird Serial Number��6_   
�������
������� �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#ffd944486�   �� 5@      -	   5        $ BirdSerialUpdateError��5@      $
��Wrap=�67   $�� ��6K   $��153,121,531,456q�6S   ���	#FFEF17176l   �� 5A      -
   5        $ CageSerialUpdate��5A   -   $y�	Collapsed=�6   $��153,290,574,286q�6G   $ Bird's new cage SN��6`   
�������
������� �	#FFD94448 �	#ffd944486�   �� 5B      -   5        $ CageSerialUpdateError��5B      $
��Wrap=�67   $�� ��6K   $��153,319,555,249q�6S   ���	#FFEF17176l   5C      �� 5D   
   -   5         ��Name$ AddChickBtn��5D      $��	Add Chick��6&   $��21,332,763,220q�6:   ���	#FFCC6E06���	#DDFFFFFF 5E        5F      5H      �� 5I   
   -   5        $ BackToHomePage��5I      $��	Home Page��6)   $��21,390,763,162q�6=   ���	#FFCC6E06���	#DDFFFFFF 5J        5K      5M      �� 5N   
   -   5        $ UpdateBirdBtn��5N      $��Update Bird��6(   $��21,454,763,114q�6>   ���	#FFCC6E06���	#DDFFFFFF 5O        5P      5R      �� 5S   
   -   5        $ UpdateDetails��5S   (   $y�	Collapsed=�6   $��Update��6?   $��176,340,608,228q�6P   ���	#FFCC6E06���	#DDFFFFFF 5T        5U      5W      �� 5X   
   -   5        $ 
deleteBird��5X   (   $y�	Collapsed=�6   $��Remove��6<   $��176,398,608,170q�6M   ���	#FFCC6E06���	#DDFFFFFF 5Y        5Z      5\      �� 5]   
   $y�Visible=�6   $��Images/BirdLogin.png��6%    J� RenderTransformOrigin$ 0.5,0.5&�6C   $	��344��6c   $	��396��6o   $��556,69,0,135q�6|   z�5^      V� 5_      .~�5`      ��  �� ScaleX$ -1Q�6%   �� 5a      �� 5b      T� 5c      5d      5f      � 5g   
   -   5         �Name$ ChickFields��5g      $y�	Collapsed=�6$   .+�5h      �� -   5        $ FatherSerial��5h   -   $y�	Collapsed=�6   $��325,101,325,451q�6C   $  Enter Father Serial Number��6\   
�������$	��250��6�   
������� �	#FFD94448 �	#ffd944486�   �� 5i      -   5        $ MotherSerial��5i   -   $y�	Collapsed=�6   $��325,101,325,451q�6C   $  Enter Mother Serial Number��6\   
�������$	��250��6�   
������� �	#FFD94448 �	#ffd944486�   �� 5j      -   5        $ ParentError��5j      $
��Wrap=�6-   $�� ��6A   $��325,152,325,404q�6I   ���	#FFEF17176b   (  "System.Windows.Controls.DatePicker  5k      -   5          Name$ 	HatchDate��5k      $��325,188,325,0q�6,   ���	#FFFE8704$ Enter Hatch Date��6Z   $	��250��6�   $��37��6�   
�������$	��Top=�6�   5m      �� 5n      -   5        $ BirdSerialNumber��5n      $��325,284,325,265q�60   $ Enter Serial Number��6I   
�������$	��250��6�   
������� �	#FFD94448 �	#ffd944486�   �� 5o      -   5        $ SerialError��5o      $
��Wrap=�6-   $�� ��6A   $��325,335,325,215q�6I   ���	#FFEF17176b   �� 5p      -   5        $ HatchDateError��5p      $
��Wrap=�60   $�� ��6D   $��325,227,325,316q�6L   ���	#FFEF17176e   �� 5q      -   5         ��Name$ 
BirdGender��5q      $
��Left=�6+   $��325,387,325,0q�6F   $	��Top=�6]   $	��250��6u   
�������$ Enter Gender��6�   ���	#FFFF8600.@�5r      �� .��6   Male6%   �� 5s      .��6   Female6'   5t      �� 5u      -   5        $ GenderError��5u      $
��Wrap=�6-   $�� ��6A   $��325,417,325,126q�6I   ���	#FFEF17176b   �� 5v      -   5        $ addNewChickBtn��5v      $��Add   +��6-   $��325,485,481,83q�6?   ���	#FFCC6E06���	#DDFFFFFF 5w        5x      5z      5{      5|      5}      