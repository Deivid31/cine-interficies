   M S B A M L   `   `   `  ����D  @Peliculas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Peliculas	Peliculas  5   	       Peliculas.Cartelera   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Peliculas     5   	     � Title$  	Cartelera��5   	   $	��450��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value*  $System.Windows.Controls.DataGridCell��%`  '��       '  �    �� 5
   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 3��5      ._�5      �� $��Center=�6/   $��Center=�5   +   ��. 5   +   5       5      P� 5      	 �@J�IsMouseOver
 . . �5   "   ��  � ��
 �����6?   5      5      5       5!      �� 5"   
   "  6   .�5#      ��  �@��TextAlignment$ Right=�68   5$      5%      .��5&      � .+�5'   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	filmsGrid��5'         
IsReadOnly .    AutoGenerateColumns .  $��200,10,19,0q�6{      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $	��369��6�   $	��Top=�6�   ��6&   ��  �� Path$ 	listFilms�   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Título��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Titulo+  5*      $
 Sala��6%    63   �� *Sala+  5+      $ Idioma��6%    65   �� *Idioma+  5,      $ Fecha inicial��6%    6<   �� *
diaInici+ �� StringFormat$ dd/MM/yy��  5-      $ Fecha final��6%    6:   �� *
diaFinal+$ dd/MM/yy��  5.      $
 Hora��6%    63   �� *Hora+$ hh\:mm��  5/      $ 	Duración��6%    67   �� *
Duracion+  50      $ Géneros��6%      Width$
 Auto 6[    66   �� *GenerosFormatted+6[   52      �� 53   
   $��Genero��6   $
��Left=�6!   $��	10,10,0,0q�6<   $	��Top=�6O   �� 54   
   -   5         ��Name$ genreBox��54      $
��Left=�6M   $��30��6h   $��	10,41,0,0q�6t   $	��Top=�6�   $	��168��6�   ��6%   �� $ 
listGenres�6�   �� 55   
   $��Idioma��6   $
��Left=�6!   $��	11,92,0,0q�6<   $	��Top=�6O   �� 56   
   -   5        $ langBox��56      $
��Left=�6O   $��30��6j   $��
10,118,0,0q�6v   $	��Top=�6�   $	��169��6�   ��6$   �� $ listLanguages�6�   �� 57   
   $��Dia inicial��6   $
��Left=�6&   $��
10,170,0,0q�6A   $	��Top=�6U   (  "System.Windows.Controls.DatePicker  58   
   -   5          Name$ diaInBox��58      $
��Left=�6'   $��
11,202,0,0q�6B   $	��148��6V   $��30��6b   $	��Top=�6n   �� 59   
   $
��Hora��6   $
��Left=�6   $��
10,237,0,0q�6:   $	��Top=�6N   �� 5:   
   -   5        $ hourBox��5:      $
��Left=�6K   $��30��6f   $��
11,268,0,0q�6r   $	��Top=�6�   $��51��6�   ��6$   �� $ 	listHours�6�   �� 5;   
   -   5        $ 	minuteBox��5;      $
��Left=�6O   $��30��6j   $��
69,268,0,0q�6v   $	��Top=�6�   $��51��6�   ��6&   �� $ listMinutes�6�   �� 5<   
   -   5         ��Name$ 
filtButton��5<      $��Filtrar��6%   $
��Left=�67   $��41��6R   $��
11,338,0,0q�6^   $	��Top=�6r   $��68��6�   6�   �� 5=   
   -   5        $ cleanButton��5=      $��Limpiar��6&   $
��Left=�68   $��42��6S   $��
91,337,0,0q�6_   $	��Top=�6s   $��68��6�   6�   �� 5>   
   -	   5        $ closeButton��5>      $��Volver��6&   $
��Left=�67   $��
60,384,0,8q�6R   $��50��6f   6q   5?      5@      