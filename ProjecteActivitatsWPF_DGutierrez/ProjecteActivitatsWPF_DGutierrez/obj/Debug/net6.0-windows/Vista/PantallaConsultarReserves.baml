   M S B A M L   `   `   `  ����[  WProjecteActivitatsWPF_DGutierrez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ProjecteActivitatsWPF_DGutierrez.Vista&ProjecteActivitatsWPF_DGutierrez.Vista  5   	   F    @ProjecteActivitatsWPF_DGutierrez.Vista.PantallaConsultarReserves   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:ProjecteActivitatsWPF_DGutierrez.Vista     5   	     � Title$  PantallaConsultarReserves��5   	   $	��450��6+   $	��400��68    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency$
 True��5   	   .��5      � .+�5   
   �� ���	#FFC3C3C3$��0��6(    �� CornerRadius$ 
40 40 40 0��68   $��	0,10,10,0q�6R   ._�5      �� 
�������$��0��6-   $ 
40 40 40 0��6=   $��10,-9,-8,10q�6W   ._�5      � .+�5      �� -   5         ��Name$! listBoxActivitatsReservades��5      $��
0,40,10,10q�6C   ��6W   Z� ��6m   Z� ��5      �� 5      .R�5   "   �  � ColumnDefinitions 5   &   �� 5   *   $
��Auto �6;   �� 5   *   $��* �6;   .+�5   &   ��  ��Name$ image_ImatgeActivitat��6,   $	��100��6e   $	��100��6q   $��0��6~   ��6K   �� *Imatge+6~   �� 5   &   $��1��61   $��9 0 0 0q�6A   .+�5   *   �� $
��Bold"�6I   $��17(�6[   ���	#FF3AA9AD$	��250��6�   ��64   �� *Nom+6�   �� 5   *   $��0 5 0 0q�64   $��13(�6E   �� 5   .   $
��Bold"�62   .�6D   Data reserva:6S    �� 5   .   �62   �� *DataReserva+5    +   �� 5!   *   $��0 5 0 0q�64   $��13(�6E   �� 5"   .   $
��Bold"�62   .�6D   	Persones:6O    �� 5#   .   �62   �� *NumPersones+5$   +   �� 5%   *   $��0 5 0 0q�64   $��13(�6E   �� 5&   .   $
��Bold"�62   .�6D   Preu final:6Q    �� 5'   .   �62   �� *	PreuFinal+ �� 5(   .   .�62   €65   5)   +   5*   '   5+   #   5,      5.      �� 5/      -   5         ��Name$ button_CancelarReserva��5/      $��CANCEL·LAR��6=   $
��Left=�6R      botóIniciarSessio#��[  6m   $	��Top=�6�   $��46��6�   $	��113��6�   $��132,383,0,0q�6�   	 � Cursor$
	 Hand��6�   $��13(�6�   ��50      �� 51      
 �� Color$
 	#FF3AA9AD��6.    �� Opacity$
 0.95Q�6@   53      54      55      56      �� 57   
   $
��Left=�6   $��24��6/   $��	28,13,0,0q�6;   $	��Top=�6N   $	��300��6f   $��20(�6r   $
��Bold"�6�   ���#3aa9ad�� 6�    � Language$ es-es�6�   $�Activitats reservades:��6�   �� 6�   �� 6�   $ es-es�6�   $�:��6�   6
  �� 5:   
   -   5        $ buttonMinimitzar��5:      ���	#FFEAEAEA$��0q�5<      $��-��5=      
���   �$��284,17,72,0q�5?      $
	 Hand��5A      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�    � 	Resources 5C       �� 
TargetType �� Property �� Value��%^   '��       �� 5D      " ��6   .�5E      ��  �@��CornerRadius$ 9��65   5F      5G      5H      �� 5J   
   -   5        $ buttonSortir��5J      ���#3AA9AD$��0q�5L      $��X��5M      
�������$��334,17,20,0q�5O      $
	 Hand��5Q      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�    5S      ��%^   '��       �� 5T      " ��6   .�5U      ��  �@��CornerRadius$ 9��65   5V      5W      5X      5Y      5Z      