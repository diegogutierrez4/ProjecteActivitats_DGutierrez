   M S B A M L   `   `   `  ����[  WProjecteActivitatsWPF_DGutierrez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ProjecteActivitatsWPF_DGutierrez.Vista&ProjecteActivitatsWPF_DGutierrez.Vista  5   	   C    =ProjecteActivitatsWPF_DGutierrez.Vista.PantallaCrearActivitat   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:ProjecteActivitatsWPF_DGutierrez.Vista     5   	     � Title$  PantallaCrearlActivitat��5   	   $	��600��6)   $	��450��66    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency$
 True��5   	   .��5      � .+�5   
   �� 
������� �� CornerRadius$ 10��6$   ._�5      �� -   5         ��Name$% textBlock_MissatgeCrarActivitat��5      $
��Left=�6A   $��33��6\   $��	10,10,0,0q�6h   $	��Top=�6{   $	��300��6�   $��23(�6�   $
��Bold"�6�   ���#3aa9ad�� 6�    � Language$ es-es�6�   $�Crear activitat:��6�   �� 6  �� 6  $ es-es�6  $�:��6%  61  5      �� 5   
   $��	0,69,0,50q�6   .+�5      � $	��0 7q�6   .+�5      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5      � $	��7 9q�6    � ColumnDefinitions 5      �� 5      $
��auto �6/   �� 5      $��* �6/   .+�5      �� $��/Imatges/nom_icone.png��6    $��24��6@    J� Opacity$	 0.4Q�6L   �� 5      -   5        	 ��Name$	 textBox_Nom��5   "      textBox#��[  6]   $��Nom Activitat��6~   $	 0.4Q�6�   5      5      5       � 5!      $	��0 7q�6   .+�5"      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5#      � $	��7 9q�6    5$      �� 5%      $
��auto �6/   �� 5&      $��* �6/   .+�5)      �� $!��/Imatges/ubicacio_icone.png��6    $��24��6E   $	 0.4Q�6Q   �� 5*      -   5        $	 textBox_Ubicacio��5*   "   #��[  6g   $��	Ubicació��6�   $	 0.4Q�6�   5+      5,      5-      � 5.      $	��0 7q�6   .+�5/      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�50      � $	��7 9q�6    51      �� 52      $
��auto �6/   �� 53      $��* �6/   .+�56      �� $"��/Imatges/categoria_icone.png��6    $��24��6F   $	 0.4Q�6R   �� 57      -   5        
 ��Name$
 comboBox_Categories��57   #   #��[  6@    �� Text$ 	Categoria��6a   $	 0.4Q�6r   6�   58      59      5:      � 5;      $	��0 7q�6   .+�5<      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5=      � $	��7 9q�6    5>      �� 5?      $
��auto �6/   �� 5@      $��* �6/   .+�5C      �� $#��/Imatges/descripcio_icone.png��6    $��24��6G   $	 0.4Q�6S   �� 5D      -   5        $	 textBox_Descripcio��5D   "   #��[  6k   $��Descripció��6�   $	 0.4Q�6�   5E      5F      5G      � 5H      $	��0 7q�6   .+�5I      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5J      � $	��7 9q�6    5K      �� 5L      $
��auto �6/   �� 5M      $��* �6/   .+�5P      �� $��/Imatges/durada_icone.png��6    $��24��6C   $	 0.4Q�6O   �� 5Q      -   5        $	 textBox_Durada��5Q   "   #��[  6c   $��Durada��6�   $	 0.4Q�6�   5R      5S      5T      � 5U      $	��0 7q�6   .+�5V      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5W      � $	��7 9q�6    5X      �� 5Y      $
��auto �6/   �� 5Z      $��* �6/   .+�5]      �� $��/Imatges/preu_icone.png��6    $��24��6A   $	 0.4Q�6M   �� 5^      -   5        $	 textBox_Preu��5^   "   #��[  6_   $
��Preu��6�   $	 0.4Q�6�   5_      5`      5a      � 5b      $	��0 7q�6   .+�5c      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5d      � $	��7 9q�6    5e      �� 5f      $
��auto �6/   �� 5g      $
��auto �6/   �� 5h      $��* �6/   .+�5k      �� $��/Imatges/imatge_icone.png��6    $��24��6C   $	 0.4Q�6O   �� 5l      -   5         ��Name$ button_Imatge��5l   !   $��1��68   $��5,0,0,0q�6H   6Y   �� 5m      #��[  6    $��Imatge��6A   $	 0.4Q�6R   $��1��6`   $��
10,0,113,0q�6p   5n      5o      5p      5q      �� 5t   
   -	   5        $ buttonMinimitzar��5t      ���	#FFEAEAEA$��0q�5v      $��-��5w      
���   �$��347,16,59,0q�5y       � Cursor$
 Hand��5{      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�    � 	Resources 5}       �� 
TargetType �� Property �� Value��%^   '��       �� 5~      " ��6   .�5      ��  �@��CornerRadius$ 9��65   5�      5�      z�5�      V� 5�      .~�5�      ��  �� ScaleX$ -1Q�6%   �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -
   5        $ buttonSortir��5�      ���#3AA9AD$��0q�5�      $��X��5�      
�������$��396,16,10,0q�5�      $
 Hand��5�      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�   $ 0.5,0.5&�6�    5�      ��%^   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 9��65   5�      5�      z�5�      V� 5�      .~�5�      �� $ -1Q�6%   �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5        $% button_TornarPantallaActivitats��5�        botóNoSeleccionable#��[ 6:   $��40��6g   $��40��6s   $
��Left=�6~   $	��Top=�6�    �� Left$ 54��6�   
 �� Top$	 496��6�   $
 Hand��6D  $��
10,550,0,0q�6R  ��6  Z� ��6  Z� ��6-  Z� ��5�      �� 5�       �� 
TargetType" ��6"   .R�5�      �� #��z��6'   5�      .��5�      �� $��/Imatges/returnBlue.png��6   $��40��65   $��40��6@    J� OpacityMask
 �   �$
 0.77Q�6`   5�      �� 5�   
   -   5        $ buttonCrearActivitat��5�      $��CREAR��6/     botóIniciarSessio#��[ 6b   $��125,499,125,50q�6�   5�      5�      