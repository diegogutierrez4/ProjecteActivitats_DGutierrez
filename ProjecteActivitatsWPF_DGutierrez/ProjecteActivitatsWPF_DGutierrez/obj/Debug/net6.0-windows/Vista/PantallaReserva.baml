   M S B A M L   `   `   `  ����[  WProjecteActivitatsWPF_DGutierrez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ProjecteActivitatsWPF_DGutierrez.Vista&ProjecteActivitatsWPF_DGutierrez.Vista  5   	   <    6ProjecteActivitatsWPF_DGutierrez.Vista.PantallaReserva   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:ProjecteActivitatsWPF_DGutierrez.Vista     5   	     � Title$  PantallaReserva��5   	   $	��600��6!   $	��450��6.    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency$
 True��5   	   .��5      � .+�5   
   �� 
������� �� CornerRadius$ 10��6$   ._�5      �� -   5         ��Name$! textBlock_ActivitatReservar��5      $
��Left=�6=   $��33��6X   $��	10,10,0,0q�6d   $	��Top=�6w   $	��324��6�   $��22(�6�   $
��Bold"�6�   ���#3aa9ad$��Reservar activitat:��6�   5      � 5   
   -   5         �Name$ gridResumReserva��5      $��Center=�6)   $	��220��6F   $��	0,254,0,0q�6S   $	��Top=�6f   $	��356��6~   .+�5      �� $��RESUM DE LA RESERVA��6    �� TextAlignment$ Center=�63   $��Center=�6J   $��0,10,0,0q�6g   $	��Top=�6y   $	��184��6�   $��15(�6�   $��
UltraLight"�6�   
���   �6�   �� 5      $��
Activitat:��6   $
��Left=�6)   $��	48,46,0,0q�6D   $	��Top=�6W   $
��Bold"�6o   $��13(�6�   �� 5      $��Data de reserva:��6   $
��Left=�6/   $��	48,77,0,0q�6J   $	��Top=�6]   $
��Bold"�6u   $��13(�6�   �� 5      $��	Persones:��6   $
��Left=�6(   $��
48,108,0,0q�6C   $	��Top=�6W   $
��Bold"�6o   $��13(�6�   �� 5      $��Preu unitari:��6   $
��Left=�6,   $��
48,139,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   $��13(�6�   �� 5      $��Preu final:��6   $
��Left=�6*   $��
48,170,0,0q�6E   $	��Top=�6Y   $
��Bold"�6q   $��13(�6�   �� 5      -   5        $! textBlock_ResumNomActivitat��5      $
��Left=�6=   $��
119,52,0,0q�6X   $
��Wrap=�6l   $�� ��6�   $	��Top=�6�   $��Italic$�6�   �� 5      -   5        $ textBlock_ResumData��5      $
��Left=�65   $��
162,83,0,0q�6P   $
��Wrap=�6d   $�� ��6x   $	��Top=�6�   $��Italic$�6�   �� 5      -   5        $  textBlock_ResumNumPersones��5      $
��Left=�6<   $��121,114,0,0q�6W   $
��Wrap=�6l   $�� ��6�   $	��Top=�6�   $��Italic$�6�   �� 5      -   5        $" textBlock_ResumPreuActivitat��5      $
��Left=�6>   $��139,145,0,0q�6Y   $
��Wrap=�6n   $�� ��6�   $	��Top=�6�   $��Italic$�6�   �� 5      -   5        $ textBlock_ResumPreuFinal��5      $
��Left=�6:   $��125,176,0,0q�6U   $
��Wrap=�6j   $�� ��6~   $	��Top=�6�   $��Italic$�6�   5       �� 5"   
   $��	0,69,0,50q�6   .+�5#      � $	��0 7q�6   � 5$      $	��0 7q�6   � 5%      $	��0 7q�6   .+�5&      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�5'      � $	��7 9q�6    � ColumnDefinitions 5(      �� 5)      $
��auto �6/   �� 5*      $��* �6/   .+�5,      (  "System.Windows.Controls.DatePicker  -   5        	  Name$	 datePicker_DataReserva��5,   %      textBox#��[  6E   
 J� Opacity$	
 0.4Q�6f      Text$ Selecciona una data��6t   5-      5.      5/      � 50      $	��0 7q�6   � 51      $	��0 7q�6   .+�52      �� $��1q�6   ���#acb0af$ 5��6C   $	��222��6T   $��Center=�6`   ._�53      � $	��7 9q�6    54      �� 55      $
��auto �6/   �� 56      $��* �6/   .+�59      �� $��/Imatges/durada_icone.png��6    $��24��6C   $	
 0.4Q�6O   �� 5:      -	   5         ��Name$ textBox_NumPersones��5:   "   #��[  6h   $��Persones��6�   $	
 0.4Q�6�   5;      5<      5=      � 5>      $	��0 7q�6   � 5?      $	��0 7q�6   5@      �� 5C   
   -
   5         ��Name$ buttonMinimitzar��5C      ���	#FFEAEAEA$��0q�5E      $��-��5F      
���   �$��347,16,59,0q�5H       � Cursor$
 Hand��5J      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�    � 	Resources 5L       �� 
TargetType �� Property �� Value��%^   '��       �� 5M      " ��6   .�5N      ��  �@��CornerRadius$ 9��65   5O      5P      z�5Q      V� 5R      .~�5S      ��  �� ScaleX$ -1Q�6%   �� 5T      �� 5U      T� 5V      5W      5Y      �� 5[   
   -   5        $ buttonSortir��5[      ���#3AA9AD$��0q�5]      $��X��5^      
�������$��396,16,10,0q�5`      $
 Hand��5b      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�   $ 0.5,0.5&�6�    5c      ��%^   '��       �� 5d      " ��6   .�5e      ��  �@��CornerRadius$ 9��65   5f      5g      z�5h      V� 5i      .~�5j      �� $ -1Q�6%   �� 5k      �� 5l      T� 5m      5n      5p      �� 5r   
   -   5        $% button_TornarPantallaActivitats��5r        botóNoSeleccionable#��[ 6:   $��40��6g   $��40��6s   $
��Left=�6~   $	��Top=�6�    �� Left$ 54��6�   
 �� Top$	 496��6�   $
 Hand��6D  $��
10,550,0,0q�6R  ��6  Z� ��6  Z� ��6-  Z� ��5s      �� 5t       �� 
TargetType" ��6"   .R�5u      �� #��z��6'   5v      .��5x      �� $��/Imatges/returnBlue.png��6   $��40��65   $��40��6@    J� OpacityMask
 �   �$

 0.77Q�6`   $	��Top=�6o   5y      �� 5z   
   -   5        $ button_ReservarActivitat��5z      $��RESERVAR��63     botóIniciarSessio#��[ 6m   $��125,499,125,50q�6�   5{      5|      