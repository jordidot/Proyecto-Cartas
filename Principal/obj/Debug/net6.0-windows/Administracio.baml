   M S B A M L   `   `   `  ����D  @Principal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Principal	Principal  5   	       Principal.Administracio   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Principal     5   	   -   5          �Name$  windowsAdministracio��5   	    � Title$ Administracio��5   	   $	��450��6   $	��860��6,    � Icon$d ^https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/LoL_icon.svg/2048px-LoL_icon.svg.png��6_   ���	#FF292525.��5	      � .+�5   
   �� -   5         ��Name$ stckPanelMostrarUsuaris��5      $��	171,0,0,0q�66   $y�Hidden=�6I   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUsuaris��5         CanUserAddRows$ False��6{      CanUserDeleteRows$ False��6�      CanUserResizeRows$ False��6�   $	��284��6�   $	��638��6�   �� 5      6   �� 5      6   �� 5      -   5         ��Name$! btnAfegirNouUsuariPrincipal��5      $��Afegir nou usuari��6:   $	��317��6V   6b   �� 5      6   �� 5      6   �� 5      -   5        $ btnEliminarUsuari��5      $��Eliminar Usuari��60   $	��317��6J   6V   5      �� 5   
   -   5        $ stckPanelMostrarCartes��5      $��	171,0,0,0q�65   $y�Hidden=�6H   .+�5        -   5        $ dataGridCartes��5      $ False��6y   $ False��6�   $ False��6�   $	��284��6�   $	��638��6�   �� 5      6   �� 5      6   �� 5      -   5        $! btnAfegirNovaCartaPrincipal��5      $��Afegir nova Carta��6:   $	��317��6V   6b   �� 5      6   �� 5      6   �� 5      -	   5        $ btnEliminarCarta��5      $��Eliminar Carta��6/   $	��317��6H   6T   5      �� 5   
   -
   5        $  stckPanelMostrarHabilitats��5      $��	171,0,0,0q�69   $y�Hidden=�6L   .+�5         -   5        $ dataGridHabilitats��5       $ False��6�   $ False��6�   $ False��6�   $	��284��6�   $	��638��6�   �� 5!      6   �� 5"      6   �� 5#      -   5        $% btnAfegirNovaHabilitatPrincipal��5#      $��Afegir nova Habilitat��6>   $	��317��6^   6j   �� 5$      6   �� 5%      6   �� 5&      -   5        $ btnEliminarHabilitat��5&      $��Eliminar Habilitat��63   $	��317��6P   6\   5'      �� 5)   
   -   5        $ stckPanelMostrarPartides��5)      $��	171,0,0,0q�67   $y�Hidden=�6J   .+�5*        -   5        $ dataGridPartides��5*      $ False��6}   $ False��6�   $ False��6�   $	��284��6�   $	��638��6�   �� 5+      6   �� 5,      6   �� 5-      -   5        $ btnEliminarPartida��5-      $��Eliminar Partida��61   $	��317��6L   6X   5.      �� 50   
   -   5        $ stckPanelMenuBotons��50      $��	0,0,689,0q�62   .+�51      �� 6   �� 52      -   5        $ btnUsuarisMenu��52      $��Usuaris��6-   $	��142��6?   
�������	 J� Effect	 53      3  -System.Windows.Media.Effects.DropShadowEffect  54      56      �� 57      6   �� 58      -   5        $ btnCartesMenu��58      $��Cartes��6,   $	��142��6=   
�������	 59        5:      5<      �� 5=      6   �� 5>      -   5        $ btnHabilitatsMenu��5>      $��
Habilitats��60   $	��142��6E   
�������	 5?        5@      5B      �� 5C      6   �� 5D      -   5        $ btnPartidesMenu��5D      $��Partides��6.   $	��142��6A   
�������	 5E        5F      5H      5I      �� 5K   
   -   5        $ stckPanelAfegirNouUsuari��5K      $y�Hidden=�67   $��	176,0,0,0q�6K   .+�5L      �� �� 5M      $��
Nom usuari��6   
�������$��Center=�6<   �� 5N      -   5        
 ��Name$
 txtBoxNomUsuari��5N       �� TextWrapping$
 Wrap=�6/   $�� ��6C   $��Center=�6K   �� 5O      $��Contrasenya��6   
�������$��Center=�6=   G� 5P      -   5         G�Name$ pwdBoxContrasenyaUsuari��5P       G� Password$  ��6;   $��Center=�6G   �� 5Q      $��Alias��6   
�������$��Center=�67   �� 5R      -   5        $
 txtBoxAliasUsuari��5R      $
 Wrap=�61   $�� ��6E   $��Center=�6M   �� 5S      $��Imatge de perfil��6   
�������$��Center=�6B   �� 5T      -   5        $
 txtBoxImatgeUsuari��5T      $
 Wrap=�62   $�� ��6F   $��Center=�6N   �� 5U      �� 5V      �� 5W      �� 5X      -   5        $ btnAfegirNouUsuari��5X      $��Afegir nou usuari��61   6M   5Y      �� 5[   
   -   5        $ stckPanelAfegirNovaCarta��5[      $y�Hidden=�67   $��
207,0,46,0q�6K   .+�5\      �� $��	Nom carta��6   
�������$��Center=�6;   �� 5]      -   5        $
 txtBoxNomCarta��5]      $
 Wrap=�6.   $�� ��6B   $��Center=�6J   $	��354��6n   �� 5^      $��
Descripcio��6   
�������$��Center=�6<   �� 5_      -   5        $
 txtBoxDescripcioCarta��5_      $
 Wrap=�65   $�� ��6I   $��Center=�6Q   $��40��6u   $	��354��6�   �� 5`      $��Imatge de la carta��6   
�������$��Center=�6D   �� 5a      -   5        $
 txtBoxImatgeCarta��5a      $
 Wrap=�61   $�� ��6E   $��Center=�6M   $��33��6q   $	��354��6}   �� 5b      $��Habilitat 1 de la carta��6   
�������$��Center=�6I   �� 5c      -    5         ��Name$ comboBoxHabilitat1��5c      $	��354��63   6?   �� 5d      $��Habilitat 2 de la carta��6   
�������$��Center=�6I   �� 5e      -!   5        $ comboBoxHabilitat2��5e      $	��354��63   6?   �� 5f      $��Habilitat 3 de la carta��6   
�������$��Center=�6I   �� 5g      -"   5        $ comboBoxHabilitat3��5g      $	��354��63   6?   �� 5h      $��Habilitat 4 de la carta��6   
�������$��Center=�6I   �� 5i      -#   5        $ comboBoxHabilitat4��5i      $	��354��63   6?   �� 5j      �� 5k      �� 5l      �� 5m      -$   5        $ btnAfegirNovaCarta��5m      $��Afegir nova carta��61   $	��181��6M   6Y   5n      �� 5p   
   -%   5        $" stckPanelAfegirNovaHabilitat��5p      $y�Hidden=�6;   $��
207,0,46,0q�6O   .+�5q      �� $��Nom habilitat��6   
�������$��Center=�6?   �� 5r      -&   5        $
 txtBoxNomHabilitat��5r      $
 Wrap=�62   $�� ��6F   $��Center=�6N   $	��354��6r   �� 5s      $ ��Descripcio de la habilitat��6   
�������$��Center=�6L   �� 5t      -'   5        $
 txtBoxDescripcioHabilitat��5t      $
 Wrap=�69   $�� ��6M   $��Center=�6U   $��40��6y   $	��354��6�   �� 5u      $��Cooldown de la carta��6   
�������$��Center=�6F   �� 5v      -(   5        $
 txtBoxCooldownHabilitat��5v      $
 Wrap=�67   $�� ��6K   $��Center=�6S   $��33��6w   $	��354��6�   �� 5w      $��Dany de la carta��6   
�������$��Center=�6B   �� 5x      -)   5        $ comboBoxDanyHabilitat��5x      $	��354��66   6B   �� 5y      �� 5z      �� 5{      -*   5        $ btnAfegirNovaHabilitat��5{      $��Afegir nova carta��65   $	��181��6Q   6]   5|      5}      5~      