   M S B A M L   `   `   `  ����D  @Peliculas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Peliculas	Peliculas  5   	        Peliculas.Cargar_Peliculas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Peliculas     5   	     � Title$  Cargar_Peliculas��5   	   $	��450��6"   $	��800��6/    � 	Resources 5	       �� 
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
 	filmsGrid��5$         AutoGenerateColumns .  $
��Left=�6i   $	��271��6�   $��
192,10,0,0q�6�   $	��Top=�6�   $	��598��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   ��6&   ��  �� Path$ 	listFilms�   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Títol��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Titulo+  5'      $
 Sala��6%    63   �� *Sala+  5(      $ Idioma��6%    65   �� *Idioma+  5)      $ Data inicial��6%    6;   �� *
diaInici+ �� StringFormat$ dd/MM/yy��  5*      $ 
Data final��6%    69   �� *
diaFinal+$ dd/MM/yy��  5+      $
 Hora��6%    63   �� *Hora+$ hh\:mm��  5,      $ Duració��6%    66   �� *
Duracion+4  .System.Windows.Controls.DataGridComboBoxColumn  5-      $ Gèneres��6)      ItemsSource 6:   �� *	Generos+5/      �� 50   
   $��Genere��6   $
��Left=�6!   $��	10,10,0,0q�6<   $	��Top=�6O   �� 51   
   -   5         ��Name$ genreBox��51      $
��Left=�6M   $��30��6h   $��	10,41,0,0q�6t   $	��Top=�6�   $	��168��6�   ��6%   �� $ 
listGenres�6�   �� 52   
   $��Idioma��6   $
��Left=�6!   $��
14,139,0,0q�6<   $	��Top=�6P   �� 53   
   -   5        $ langBox��53      $
��Left=�6O   $��30��6j   $��
10,170,0,0q�6v   $	��Top=�6�   $	��168��6�   ��6$   �� $ listLanguages�6�   �� 54   
   $��Dia inicial��6   $
��Left=�6&   $��12,0,0,0q�6A   $��Center=�6S   (  "System.Windows.Controls.DatePicker  55   
   -   5          Name$ diaInBox��55      $
��Left=�6'   $��
12,238,0,0q�6B   $	��148��6V   $��30��6b   $	��Top=�6n   �� 56   
   $
��Hora��6   $
��Left=�6   $��
12,268,0,0q�6:   $	��Top=�6N   �� 57   
   -   5        $ hourBox��57      $
��Left=�6K   $��30��6f   $��
12,299,0,0q�6r   $	��Top=�6�   $��50��6�   ��6$   �� $ 	listHours�6�   �� 58   
   -   5        $ 	minuteBox��58      $
��Left=�6O   $��30��6j   $��
68,298,0,0q�6v   $	��Top=�6�   $��52��6�   ��6&   �� $ listMinutes�6�   �� 59   
   -   5         ��Name$ confirmarButton��59      $��Añadir��6*   $
��Left=�6;   $��41��6V   $��
11,379,0,0q�6b   $	��Top=�6v   $��60��6�   6�   �� 5:   
   -   5        $ cleanButton��5:      $��Llimpiar��6&   $
��Left=�69   $��42��6T   $��
86,379,0,0q�6`   $	��Top=�6t   $��68��6�   6�   �� 5;   
   -	   5        $ añadir_Button��5;      $��Añadir género��6(   $
��Left=�6@   $��23��6[   $��
10,116,0,0q�6g   $	��Top=�6{   $��82��6�   6�   �� 5<   
   -
   5        $ limpiarGen_Button��5<      $��Llimpiar géneros��6,   $
��Left=�6G   $��23��6b   $��
94,116,0,0q�6n   $	��Top=�6�   $��94��6�   6�   �� 5=   
   -   5         ��Name$ genres_Label��5=      $
��Left=�6&   $��	11,76,0,0q�6A   $	��Top=�6T   $	��167��6l   $	��167��6{   $��38��6�   .��5>      �� -   5         ��Name$ Genres_TxtB��5>      $�� ��6-   $
��Wrap=�65   5?      �� 5@   
   $��Duración (m):��6   $
��Left=�6(   $��
14,339,0,0q�6C   $	��Top=�6W   $��40��6o   �� 5A   
   -   5        $ durationBox��5A      $
��Left=�6M   $��30��6h   $��
94,339,0,0q�6t   $	��Top=�6�   $��52��6�   ��6(   �� *listDuration+6�   �� 5B   
   $��Título:��6   $
��Left=�6"   $��192,299,0,0q�6=   $	��Top=�6R   $��30��6j   �� 5C   
   -   5         ��Name$ titulo_txtBox��5C      $
��Left=�6)   $��235,304,0,0q�6D    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   �� 5D   
   $��Sala:��6   $
��Left=�6    $��192,336,0,0q�6;   $	��Top=�6P   $��23��6h   �� 5E   
   -   5        $ salaBox��5E      $
��Left=�6E   $��226,339,0,0q�6`   $��52��6u   $��20��6�   $	��Top=�6�   ��6$   �� *
listSala+6�   5F      5G      