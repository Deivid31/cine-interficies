   M S B A M L   `   `   `  ����D  @Peliculas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Peliculas	Peliculas  5   	   !    Peliculas.CarteleraFiltrada   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Peliculas     5   	     � Title$  PelisFiltradas��5   	   $	��450��6    $	��800��6-    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  '��       �� 5
   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 3��5      ._�5      �� $��Center=�6/   $��Center=�5   '   ��. 5   '   5       5      P� 5       �@J�IsMouseOver	 . . �5   "   ��  � ��
 �����6?   5      5      5       5!      5"      .��5#      � .+�5$   
   &   System.Windows.Controls.DataGrid  -   5        
  Name$
 	filmsGrid��5$         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6{   $	��353��6�   $��
192,10,0,0q�6�   $	��Top=�6�   $	��598��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   ��6&   ��  �� Path$ 	filtFilms�   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Títol��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Titulo+  5'      $
 Sala��6%    63   �� *Sala+  5(      $ Idioma��6%    65   �� *Idioma+  5)      $ Data inicial��6%    6;   �� *
diaInici+ �� StringFormat$ dd/MM/yy��  5*      $ 
Data final��6%    69   �� *
diaFinal+$ dd/MM/yy��  5+      $
 Hora��6%    63   �� *Hora+$ hh\:mm��  5,      $ Duració��6%    66   �� *
Duracion+4  .System.Windows.Controls.DataGridComboBoxColumn  5-      $ Gèneres��6)      ItemsSource 6:   �� *GenerosFormatted+5/      �� 50   
   -   5         ��Name$ butCancelar��50      $��Retornar��6&   $
��Left=�69   $��
89,186,0,0q�6T   $	��Top=�6h   $��42��6�   $��55��6�   6�   �� 51   
   -   5         ��Name$ filmBox��51      $
��Left=�6K   $��41��6f   $��
10,107,0,0q�6r   $	��Top=�6�   $	��158��6�   ��6$   �� $ 	filtFilms�6�   �� 52   
   -   5        $ butReservar��52      $��Reservar��6&   $
��Left=�69   $��
10,186,0,0q�6T   $	��Top=�6h   $��42��6�   $��55��6�   6�   �� 53   
   $��Pelicula escollida:��6   $
��Left=�6.   $��23��6I   $��	10,79,0,0q�6U   $	��Top=�6h   $	��108��6�   �� 54   
   $��Dia de la pelicula:��6   $
��Left=�6.   $��25��6I   $��	10,10,0,0q�6U   $	��Top=�6h   $	��108��6�   �� 55   
   -   5         ��Name$ diaLbl��55      $
��Left=�6    $��39��6;   $��	10,35,0,0q�6G   $	��Top=�6Z   $	��108��6r   56      57      