   M S B A M L   `   `   `  ????G  CKomedijaFilm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:KomedijaFilmKomedijaFilm  5   	       KomedijaFilm.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:KomedijaFilm     5   	   -   5          ? Title$  
MainWindow??5   	    ? SizeToContent$ WidthAndHeight=?6    ? WindowStyle$
 None=?6l    ? AllowsTransparency . 
??????  ? 	Resources 5
         ButtonStyle ?? 
TargetType ?? Property ?? Value??%?   &	        ?? 5   
   " ??6$   .?5      ??  ? ??
 ?????6+   ?? 5       ? ??
 ??p??6+   ?? 5       ? ??
 ?????6,   ?? 5       ? ??$
 0.75q?60   5      5      .??5      ?? $	??750??6   $	??500??6   .+?5   
   F? 
????i??$??3??6     J? Opacity$	 100Q?64   ??5      ?? 5      .??5      ? 	 ? Color$	 HotPink??6#   
 ? Offset$	
 0.0Q?63   ? 5      $	 DarkTurquoise??6#   $

 0.25Q?69   ? 5      $	 HotPink??6#   $

 0.50Q?63   ? 5      $	 DarkTurquoise??6#   $

 0.75Q?69   ? 5      $	 HotPink??6#   $	
 1.0Q?63   5      ??5      B? 5      .??5       E?  E? 
StartPoint$
 50,0&?6!   .??5!      ??  ?? Point$
 0,50&?6&   ?? 5"      $ 0,100&?6&   ?? 5#      $ 10,100&?6&   ?? 5$      $ 10,400&?6&   ?? 5%      $ 0,400&?6&   ?? 5&      $ 0,450&?6&   ?? 5'      $ 50,500&?6&   ?? 5(      $ 700,500&?6&   ?? 5)      $ 750,450&?6&   ?? 5*      $ 750,400&?6&   ?? 5+      $ 740,400&?6&   ?? 5,      $ 740,100&?6&   ?? 5-      $ 750,100&?6&   ?? 5.      $ 750,50&?6&   ?? 5/      $ 700,0&?6&   ?? 50      $
 50,0&?6&   51      52      56      ?? 59   
   -   5         ??Name$ ExitBtn??59      #??[  6"   $??Izlaz??6G    ?? Left$	 599??6X   
 ?? Top$ 20??6j   $??75??6z    ? Cursor$
 Hand??6?   6?   ?? 5:   
   -   5        $ DodajBtn??5:      #??[  6$   $??
Dodaj film??6I   $	 599??6_   $ 71??6q   $??75??6?   $
 Hand??6?   6?   &   System.Windows.Controls.DataGrid  5<   
   -   5          Name$ dataGridKomedija??5<         
IsReadOnly .    SelectionMode$ Single=?6g      AutoGenerateColumns .  $
??Left=?6?   $	??Top=?6?   $	??350??6?   $??
64,119,0,0q?6?   $	??620??6?      HorizontalGridLinesBrush
 ??p??   VerticalGridLinesBrush
 ??p????6-   ?? *BindingKomedija+ 5=      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn??%?   '        7 ?? 5>      8   "  6Q   .?5?      ??  ? ??
 ??p??63   ?? 5@       ? ??$ Center=?6C   ?? 5A       ? ??$
 Bold"?63   5B      5C         Columns 5E      4  .System.Windows.Controls.DataGridTemplateColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6)      CellTemplate 5G      ?? 5H      .R?5I      ?? $??UniformToFill=?6D   ??6$   ?? *PutanjaSlike+6D   5J      5L        5O         Header$ Naziv filma??6)   $	 105 6>    5P      ?? 5Q      .R?5R      ?? $
??Wrap=?6?   $??Center=?6S   $??Center=?6p   ??6(   ?? *Naziv+6p   5S      5U        5W      $ 
Produkcija??6)   $	 100 6=    5X      ?? 5Y      .R?5Z      ?? $
??Wrap=?6J   $??Center=?6^   $??Center=?6{   ??6(   ?? *ProdukcijskaKuca+6{   5[      5]        5a      $ Trajanje filma??6)   $	 105 6A    5b      ?? 5c      .R?5d      ??  ?? Orientation$ 
Horizontal=?6)   $??Center=?6B   $??Center=?6_   .+?5e   "   ?? ??6,   ?? *TrajanjeMin+5f      5g      5i        5m      $ 	Premijera??6)   $	 105 6<    5n      ?? 5o      .R?5p      ?? $
??Wrap=?6g   $??Center=?6{   $??Center=?6?   ??6(   ?? *DatumPremijere+ ?? StringFormat$ {0:dd/MM/yyyy}??6?   5q      5s        5u      $ * 6)    5v      ?? 5w      .R?5x      ?? $ Vertical=?6)   $??63??6@   $??70??6L   $??Stretch=?6W   $??Center=?6u   .+?5y   "   ?? $ 	PrikazBtn??6)   -   5        #??[  5y   <   $??Prikaz??6a   $??20??6r   $??1,0,1,0q?6~   $
 Hand??6?   ?? 5z   "   $ 	IzmeniBtn??6)   -   5        #??[  5z   <   $??Izmeni??6a   $??20??6r   $??1,1,1,0q?6~   $
 Hand??6?   ?? 5{   "   $ 	ObrisiBtn??6)   -   5        #??[  5{   <   $??Obriši??6a   $??20??6s   $??1,1,1,0q?6   $
 Hand??6?   5|      5}      5      5?      5?      5?      