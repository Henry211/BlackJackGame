   M S B A M L   `   `   `  ����D  @BlackJack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BlackJack	BlackJack  5   	       BlackJack.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BlackJack     5   	     � Title$  
MainWindow��5   	   $��680.556��6   $��1096.007��6-   ���	#FF307430.��5	      � $��0,0,2,8q�6    � RowDefinitions 5
   
   �� 5      $	��67* �6   �� 5      $	��40* �6   .+�5   
   �� -   5         ��Name$ pedirBtn��5      $��Pedir��6#   $
��Left=�63   $��182,95.078,0,0q�6N   $	��Top=�6f   $��82��6~   $��48��6�    J� RenderTransformOrigin$ -0.337,0.545&�6�   ���	#FFE6E6E6$��20(�6�   $��
Sitka Text)�6�   $��1��6  $��0q�6  ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ 	#FF369CB9��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ quedarse��5      $��Quedarse��6#   $
��Left=�66   $��
765,95,0,0q�6Q   $	��Top=�6e   $��94��6}   $��48��6�   $ -0.337,0.545&�6�   ���	#FFE6E6E6$��20(�6�   $��
Sitka Text)�6   $��1��6  ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ 	#FFD42626��6#   $ 1Q�65   5      5      �� 5   
   $��Jugador��6   $
��Left=�6"   $��968,126.078,0,0q�6=   $	��Top=�6V   $��87��6n   $��44��6y   ���	#FFE6E6E6$��18(�6�   $��1��6�   $��
Sitka Text)�6�   �� 5   
   $��Dinero apostado:��6   $
��Left=�6+   $��276,199.078,0,0q�6F   $	��Top=�6_   $	��148��6w   $��31��6�   ���	#FFE6E6E6$��16(�6�   $��1��6�   $��
Sitka Text)�6�   �� 5    
   $��Dinero total:��6   $
��Left=�6(   $��584,198,0,0q�6C   $	��Top=�6X   $	��105��6p   $��31��6|   ���	#FFE6E6E6$��16(�6�   $��1��6�   $��
Sitka Text)�6�   $ 
-0.152,0.5&�6�   �� 5!   
   -   5         ��Name$ dineroApostado��5!      $��0
0
��6(   $
��Left=�6I   $��429,199,0,0q�6d   $	��Top=�6y   $��85��6�   ���	#FFE6E6E6$��16(�6�   $��1��6�   $��
Sitka Text)�6�   $��31��6�   �� 5"   
   -   5        $ dineroTotal��5"      $	��0
��6%   $
��Left=�6;   $��694,199,0,0q�6V   $	��Top=�6k   $��68��6�   ���	#FFE6E6E6$��16(�6�   $��1��6�   $��
Sitka Text)�6�   �� 5#   
   -   5        $ SalirBtn��5#      $��Salir��6#   $
��Left=�63   $��	29,30,0,0q�6N   $	��Top=�6a   $��76��6y   ���	#FFE6E6E6$��27��6�   $��16(�6�   $��
Sitka Text)�6�   ��5$      �� 5%      $ 0.5,1&�6&   $ 0.5,0&�67   .��5&      � $ Black��6#   $ 0Q�61   � 5'      $ 	#FFDE4646��6#   $ 1Q�65   5(      5*      �� 5+   
   -   5        	 ��Name$	 imgCard2��5+      $
��Left=�6"   $	��133��6=   $��369,301,0,0q�6J   $	��Top=�6_   $	��101��6w   $��2��6�   �� 5,   
   $��Sumatoria de mano:��6   $
��Left=�6-   $��407,155,0,0q�6H   $	��Top=�6]   $	��230��6u   $��55��6�   ���	#FFE6E6E6$��20(�6�   $��Script MT Bold)�6�   $��1��6�   �� 5-   
   -   5        $
 mano��5-      $��0��6   $
��Left=�6*   $��572,158,0,0q�6E   $	��Top=�6Z   $��48��6r   ���	#FFE6E6E6$��20(�6�   $��Script MT Bold)�6�   $��1��6�   $��52��6�   $ 0.208,0.654&�6�   �� 5.   
   -   5        $	 imgCard3��5.      $
��Left=�6"   $	��133��6=   $��487,260,0,0q�6J   $	��Top=�6_   $	��101��6w   �� 5/   
   -	   5        $	 imgCard1��5/      $
��Left=�6"   $	��133��6=   $��607,301,0,0q�6J   $	��Top=�6_   $	��101��6w   $��2��6�   �� 50   
   -
   5        $	 imgCard4��50      $
��Left=�6"   $��94��6=   $��
54,181,0,0q�6I   $	��Top=�6]   $��72��6u   �� 51   
   -   5        $	 imgCard5��51      $
��Left=�6"   $��93��6=   $��138,153,0,0q�6I   $	��Top=�6^   $��72��6v   �� 52   
   -   5        $	 imgCard6��52      $
��Left=�6"   $��94��6=   $��223,181,0,0q�6I   $	��Top=�6^   $��72��6v   �� 53   
   -   5        $	 imgCard7��53      $
��Left=�6"   $��94��6=   $��
419,63,0,0q�6I   $	��Top=�6]   $��72��6u   �� 54   
   -   5        $	 imgCard9��54      $
��Left=�6"   $��93��6=   $��
503,35,0,0q�6I   $	��Top=�6]   $��71��6u   �� 55   
   -   5        $	 imgCard8��55      $
��Left=�6"   $��94��6=   $��
588,63,0,0q�6I   $	��Top=�6]   $��72��6u   �� 56   
   -   5        $	 	imgCard12��56      $
��Left=�6#   $��94��6>   $��787,181,0,0q�6J   $	��Top=�6_   $��72��6w   �� 57   
   -   5        $	 	imgCard11��57      $
��Left=�6#   $��93��6>   $��871,153,0,0q�6J   $	��Top=�6_   $��72��6w   �� 58   
   -   5        $	 	imgCard10��58      $
��Left=�6#   $��94��6>   $��956,181,0,0q�6J   $	��Top=�6_   $��72��6w   �� 59   
   -   5        $ _10btn��59      $�� ��6!   $
��Left=�6,   $��311,128,0,0q�6G   $��1��6\   $	��Top=�6i   $��77��6�   $ 1.351,0.125&�6�   $��46��6�   $��0q�6�   |�.  ��5:      �� 5;      
 �� ImageSource$
 10.png��6   5=      �� 5>   
   -   5        $ _25btn��5>      $�� ��6!   $
��Left=�6,   $��
407,95,0,0q�6G   $��1��6[   $	��Top=�6h   $��75��6�   $ -0.08,1.475&�6�   $��48��6�   $��0q�6�   |�.  ��5?      �� 5@      $
 25.png��6   5B      �� 5C   
   -   5        $ _50btn��5C      $�� ��6!   $
��Left=�6,   $��
513,93,0,0q�6G   $��1��6[   $	��Top=�6h   $��75��6�   $��46��6�   $��0q�6�   |�.  ��5D      �� 5E      $
 50.png��6   5G      �� 5H   
   -   5        $ _100btn��5H      $�� ��6"   $
��Left=�6-   $��614,128,0,0q�6H   $��1��6]   $	��Top=�6j   $��75��6�   $��46��6�   $��0q�6�   |�.  ��5I      �� 5J      $
 100.png��6   5L      5N      5O      