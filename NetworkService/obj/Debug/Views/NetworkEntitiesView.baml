   M S B A M L   `   `   `  ????I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetworkService.ViewsNetworkService.Views  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      ;"clr-namespace:NetworkService.ModelNetworkService.Model  5      .    (NetworkService.Views.NetworkEntitiesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NetworkService.Views     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      3data"clr-namespace:NetworkService.Model     5      .??5      ? .+?5   
   ??   ?? Orientation$  Vertical=?6   $	??450??6,   $??
0,0,0,-0.4q?69   $??Bottom=?6M   .+?5      ?? $  
Horizontal=?6   $
??Left=?62   $	??Top=?6M   $	??677??6e   .+?5      ?? $  Vertical=?6   $??Center=?64   .+?5      	? -   5         	?Name$ Lower??5   "   $
??Bold"?61    	? 	GroupName$ Search??6C   $??
Lower than??6r   $??5 0 5 0q?6?    ? ToolTip$% Manje od vrednosti koju unosite??6?   
??????? d? 	IsChecked 6V   ?? *Lower+ ^? 	IsEnabled 6?   ?? *FeedBackOnOffND+ ?? UpdateSourceTrigger$ PropertyChanged=?	? 5      -   5        $ Higher??5   "   $
??Bold"?62   $ Search??6D   $??Higher than??6t   $??5 0 5 0q?6?   $$ Vece od vrednosti koju unosite??6?   
??????? 6W   ?? *Higher+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=?5      ?? 5      $  Vertical=?6   .+?5      ?? -   5         ??Name$ 	TextBoxId??5      
 ? Tag$  Search??6O   $??51??6]   $??25??6h   $??	5 20 10 5q?6t   $ 
Unesite ID??6?   ??61   ?? *
SearchText+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=??? 5      
???  ??6!   5      ?? 5      ?? 5      -   5        	 ??Name$	 ComboBoxFilter??5      
 ?? Text$
 Select option??6?   $	??120??6?   $??25??6?   $ Odaberite tip iz liste??6?   ??64   ?? *TipoviComboBox+ ?? Mode$ TwoWay=?$ PropertyChanged=? ?? SelectedItem 6?   ?? *SelectedFilterTip+ 6  ?? *FeedBackOnOffND+$ PropertyChanged=??? 5      -   5         ??Name$ ButtonSearch??5      $??Filter??6Q   $
??Bold"?6c   $??82??6u   $??20??6?   $??5 5 0 5q?6?   $ Kliknite za filter??6?   ??6/   ?? *SearchCommand+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=??? 5      -   5        $ ButtonReset??5      $??Reset??6O   $
??Bold"?6_   $	??100??6q   $??20??6}   $??5 5 0 5q?6?   $( "Klik za ponistavanje opcije Filter??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   ??6.   ?? *ResetCommand+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=??? 5      $
 TrueY?6:   $??14(?6L   $??26??6Z   $??24??6f   ??6   ?? *	NDCommand+6f   ?? 5      -   5        $ 
HelpButton??5      $
??Help??6-   $??12(?6=   $??	ExtraBold"?6K   $??21??6b   $ 
1.34,0.379&?6n   $ Pomoc??6?   $??48??6?   ??6?   ?? *ShowHelpCommand+6?   5       &   System.Windows.Controls.DataGrid  5!      -   5          Name$ 
GridTabela??5!         
IsReadOnly .    SelectionMode$ Single=?6?      AutoGenerateColumns .  $
??Left=?5"      $	??233??6.   $	??Top=?6;   $	??764??6S   $??10,5,0,0q?6_   $??19(?6q   $??Kartika)?6   ??5!   +   ?? *ReactorSearch+ 6Q   ?? *SelectedReactor+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ?? *Id+6L     5%      $ Naziv??6)   $ * 6R    68   ?? *Naziv+6R     5&      $	 Tip??6)   $ * 6S    66   ?? *
Tip.Name+6S     5'      $ Vrednost??6)   $ * 6U    6;   ?? *Value+6U   5)      ?? 5*      $??10??6   ?? 5+      $  
Horizontal=?6   $??Bottom=?62   $??Center=?6M   $??
10,0,220,0q?6j   $??76??6~   $	??570??6?   .+?5,      ?? $  Vertical=?6   .+?5-      ?? $??ID??6    $??20(?6-   $
??Bold"?6;   $??80??6M   $??25??6X    ?? TextAlignment$ Center=?6d   
???????6{   ?? 5.      $??Naziv??6    $??20(?6-   $
??Bold"?6;   $??80??6M   $??25??6X   $ Center=?6d   
???????6{   ?? 5/      $	??Tip??6    $??20(?6,   $
??Bold"?6:   $??80??6L   $??25??6W   $ Center=?6c   
???????6z   50      ?? 51      $  Vertical=?6   .+?52      ?? $	??120??6C   $??25??6O   $ ID mora biti jedinstveno??6[   ??6   ?? *IdText+$ TwoWay=? 6~   ?? *FeedBackOnOffND+$ PropertyChanged=??? 53      $	??120??6F   $??25??6R   $ Unesite naziv??6^   ??6   ?? *	NazivText+$ TwoWay=? 6v   ?? *FeedBackOnOffND+$ PropertyChanged=??? 54      -	   5        $	 ComboBoxType??54      $
 Select option??6  $	??120??6#  $??25??6/  $ Odaberite tip iz liste??6;  ??66   ?? *TipoviComboBox+$ TwoWay=?$ PropertyChanged=? 6?   ?? *SelectedTip+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=?6;  55      ?? 56      $??10??6   ?? 57      -
   5         ??Name$ ImageSrc??57      $??83??6l   $??0,2,0,8q?6w   ??6*   ?? *	ImagePath+$ PropertyChanged=?6w   ?? 58      $??10??6   ?? 59      $  Vertical=?6   $??Center=?64   .+?5:      ?? -   5        $ 	ButtonAdd??5:      $	??Add??60   $??80??6>   $??30??6I   $
??Bold"?6U   $  Klik za dodavanje elementa??6?   ??6g   ?? *
AddCommand+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=?6?   ?? 5<      $??10??6    ?? 5>      -   5        $ ButtonDelete??5>      $??Delete??63   $??80??6D   $??30??6O   $
??Bold"?6[   $ Klik za brisanje elementa??6?   ??6m   ?? *DeleteCommand+ 6?   ?? *FeedBackOnOffND+$ PropertyChanged=?5?      5A      5D      5E      5F      