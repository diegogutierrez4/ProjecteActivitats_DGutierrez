   M S B A M L   `   `   `  ����$   ProjecteActivitatsWPF_DGutierrez7    1ProjecteActivitatsWPF_DGutierrez.Vista.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  GuiaMe��5   	   $	��500��6   $	��800��6%    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5	   	   
������  � AllowsTransparency$
 True��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   ��  �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #3AA9AD��6#   	 � Offset$	 0Q�63   � 5      $ #3AA9AD��6#   $	 1Q�63   5      ._�5      � .+�5      �� .+�5      � 
 � Points
 �    -1��� ;X�����#4EB1B66;   � 5      '
 �    �� �� ���� ��
�����#4EB1B6$��Center=�6N   $	��480��6k   
 �� Top$ 10��6x   $	��Top=�6�   A� 5      $��250 450 0 0q�6   ���#4EB1B6$��40��6B   $��40��6N   A� 5       $��
50 400 0 0q�6   ���#4EB1B6$��20��6A   $��20��6M   A� 5!      ���#4EB1B6$��68��6-   $��68��69   $
��Left=�6D    �� Left$ 81��6_   $	 -45��6p   $	��Top=�6�   A� 5"      ���#4EB1B6$��28��6-   $��28��69   $	 230��6D   $ 62��6V   $
��Left=�6f   $	��Top=�6�   5#      �� 5%      $��Center=�6   .+�5&      �� $��Registra't!��6       	titolText#��[  63   �� 5'      $Q��KEntra les teves dades per tenir accés a les millors activitats de la zona!��6      
textNormal#��[ 6r    J� Opacity$	 0.8Q�6�   $��20 30q�6�   �� 5(      -   5         ��Name$ buttonRegistre��5(      $��REGISTRE��65     botóRegistre#��[ 6H   6n   5)      5*      5+      �� 5-   
   
�������$��1��6$   $ 	0 10 10 0��64   ._�5.      �� $��Center=�6   .+�5/      �� $$��Inicia sessió a l'aplicació!��6   #��[  6@   ���#3AA9AD6c   �� 50       �� Orientation$ 
Horizontal=�6   $
��0 20q�66   $��Center=�6D   .+�51      �� -   5          botóIconesIniciSessió#��[ 51      .��52      �� $��/Imatges/google_logo.png��6    $��22��6B   $��22��6M    J� OpacityMask
 �   �$
 0.77Q�6m   53      �� 55      -   5        #��[ 55      .��56      �� $!��/Imatges/instagram_logo.png��6    $��22��6E   $��22��6P   
 �   �$
 0.77Q�6p   57      �� 59      -   5        #��[ 59      .��5:      �� $ ��/Imatges/facebook_logo.png��6    $��22��6D   $��22��6O   
 �   �$
 0.77Q�6o   5;      5<      �� 5>      $ ��o entra amb el teu compte:��6   #��[ 6>   ���#878787$��	0 10 0 15q�6w   �� 5@      $��1q�6   ���#acb0af$
��70 7q�6C   $ 5��6Q   ._�5A      � $	��7 9q�6    5B      �� 5C      $
��auto �6/   �� 5D      $��* �6/   .+�5G      �� $��/Imatges/usuari_logo.png��6    $��24��6B   $	 0.4Q�6N   �� 5H      -   5         ��Name$ textBox_NomUsuari��5H   "     textBox#��[ 6i   5I      5J      �� 5L      $��1q�6   ���#acb0af$
��70 7q�6C   $ 5��6Q   ._�5M      � $	��7 9q�6    5N      �� 5O      $
��auto �6/   �� 5P      $��* �6/   .+�5S      �� $��/Imatges/contra_logo.png��6    $��24��6B   $	 0.4Q�6N   G� 5T      -   5         G�Name$ passwordBox_Contrasenya��5T   &   #��[ 6}   5U      5V      �� 5X      -   5        $ buttonIniciarSessio��5X      $��ENTRA��66     botóIniciarSessio#��[ 6h   5Y      5Z      �� 5\   
   -   5        $ buttonMinimitzar��5\      ���	#FFEAEAEA$��0q�5^      $��-��5_      
���   �$��385,10,55,0q�5a       � Cursor$
 Hand��5c      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��21��6�   $��1��6�    � 	Resources 5e       �� 
TargetType �� Property �� Value��%^   '��       �� 5f      " ��6   .�5g      ��  �@��CornerRadius$ 9��65   5h      5i      5j      �� 5k   
   -	   5        $ buttonSortir��5k      ���#3AA9AD$��0q�5m      $��X��5n      
�������$��430,10,10,0q�5p      $
 Hand��5r      $��Light"�6   $��Center=�6.   $��Center=�6P   $	��Top=�6t   $��1��6�   $��21��6�    5t      ��%^   '��       �� 5u      " ��6   .�5v      ��  �@��CornerRadius$ 9��65   5w      5x      5y      5z      5|      