   M S B A M L   `   `   `  ����D  @Peliculas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Peliculas	Peliculas  5   	        Peliculas.Cargar_Peliculas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Peliculas     5   	     � Title$  Cargar_Peliculas��5   	   $	��450��6"   $	��800��6/    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  '��       �� 5
   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 3��5      ._�5      �� $��Center=�6/   $��Center=�5   '   ��. 5   '   5       5      P� 5       �@J�IsMouseOver	 . . �5   "   ��  � ��
 �����6?   5      5      5       5!      5"      .��5#      � 
 � RowDefinitions
 5$   
   �� 5%      $	��72* �6   �� 5&      $
��145* �6   .+�5(   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	filmsGrid��5(         AutoGenerateColumns .  $��192,10,10,153q�6i      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��2��6�   ��6&   ��  �� Path$ 	listFilms�   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Títol��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Titulo+  5+      $
 Sala��6%    63   �� *Sala+  5,      $ Idioma��6%    65   �� *Idioma+  5-      $ Data inicial��6%    6;   �� *
diaInici+ �� StringFormat$ dd/MM/yy��  5.      $ 
Data final��6%    69   �� *
diaFinal+$ dd/MM/yy��  5/      $
 Hora��6%    63   �� *Hora+$ hh\:mm��  50      $ Duració��6%    66   �� *
Duracion+4  .System.Windows.Controls.DataGridComboBoxColumn  51      $ Gèneres��6)      ItemsSource 6:   �� *	Generos+53      �� 54   
   $��Genere��6   $
��Left=�6!   $��	10,10,0,0q�6<   $	��Top=�6O   �� 55   
   -   5         ��Name$ genreBox��55      $
��Left=�6M   $��30��6h   $��	10,41,0,0q�6t   $	��Top=�6�   $	��168��6�   ��6%   �� $ 
listGenres�6�   �� 56   
   $��Idioma��6   $
��Left=�6!   $��
14,139,0,0q�6<   $	��Top=�6P   $��2��6h   �� 57   
   -   5        $ langBox��57      $
��Left=�6O   $��30��6j   $��	10,26,0,0q�6v   $	��Top=�6�   $	��168��6�   $��1��6�   ��6$   �� $ listLanguages�6�   �� 58   
   $��Dia inicial��6   $
��Left=�6&   $��	12,60,0,0q�6A   $��26��6T   $	��Top=�6`   $��1��6x   (  "System.Windows.Controls.DatePicker  59   
   -   5          Name$ diaInBox��59      $
��Left=�6'   $��	12,94,0,0q�6B   $	��148��6U   $��30��6a   $	��Top=�6m   $��1��6�   �� 5:   
   $
��Hora��6   $
��Left=�6   $��
12,124,0,0q�6:   $	��Top=�6N   $��1��6f   �� 5;   
   -   5        $ hourBox��5;      $
��Left=�6K   $��30��6f   $��
12,155,0,0q�6r   $	��Top=�6�   $��50��6�   $��1��6�   ��6$   �� $ 	listHours�6�   �� 5<   
   -   5        $ 	minuteBox��5<      $
��Left=�6O   $��30��6j   $��
68,154,0,0q�6v   $	��Top=�6�   $��52��6�   $��1��6�   ��6&   �� $ listMinutes�6�   �� 5=   
   -   5         ��Name$ confirmarButton��5=      $��Añadir��6*   $
��Left=�6;   $��41��6V   $��
11,235,0,0q�6b   $	��Top=�6v   $��60��6�   $��1��6�   �� 5>   
   -   5        $ cleanButton��5>      $��Llimpiar��6&   $
��Left=�69   $��42��6T   $��
86,235,0,0q�6`   $	��Top=�6t   $��68��6�   $��1��6�   �� 5?   
   -	   5        $ añadir_Button��5?      $��Añadir género��6(   $
��Left=�6@   $��23��6[   $��
10,116,0,0q�6g   $	��Top=�6{   $��82��6�   6�   �� 5@   
   -
   5        $ limpiarGen_Button��5@      $��Llimpiar géneros��6,   $
��Left=�6G   $��23��6b   $��
94,116,0,0q�6n   $	��Top=�6�   $��94��6�   6�   �� 5A   
   -   5         ��Name$ genres_Label��5A      $
��Left=�6&   $��	11,76,0,0q�6A   $	��Top=�6T   $	��167��6l   $	��167��6{   $��38��6�   .��5B      �� -   5         ��Name$ Genres_TxtB��5B      $�� ��6-   $
��Wrap=�65   5C      �� 5D   
   $��Duración (m):��6   $
��Left=�6(   $��
14,195,0,0q�6C   $	��Top=�6W   $��40��6o   $��1��6{   �� 5E   
   -   5        $ durationBox��5E      $
��Left=�6M   $��30��6h   $��
94,195,0,0q�6t   $	��Top=�6�   $��52��6�   $��1��6�   ��6(   �� *listDuration+6�   �� 5F   
   $��Título:��6   $
��Left=�6"   $��192,0,0,105q�6=   $��30��6R   $��Bottom=�6^   $��1��6y   �� 5G   
   -   5         ��Name$ titulo_txtBox��5G      $
��Left=�6)   $��235,0,0,112q�6D    �� TextWrapping$
 Wrap=�6Y   $	��120��6m   $��18��6y   $��Bottom=�6�   $��1��6�   �� 5H   
   $��Sala:��6   $
��Left=�6    $��
192,0,0,75q�6;   $��23��6O   $��Bottom=�6[   $��1��6v   �� 5I   
   -   5        $ salaBox��5I      $
��Left=�6E   $��
226,0,0,75q�6`   $��52��6t   $��20��6   $��Bottom=�6�   $��1��6�   ��6$   �� *
listSala+6�   5J      5K      