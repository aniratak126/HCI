   M S B A M L   `   `   `  ????@  <MVVM1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MVVM1MVVM1  5   	   )clr-namespace:MVVM1.ViewsMVVM1.Views  5   	   1clr-namespace:MVVM1.ViewModelMVVM1.ViewModel  5   	       MVVM1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MVVM1     5   	   +viewsclr-namespace:MVVM1.Views     5   	   3	viewModelclr-namespace:MVVM1.ViewModel     5   	     ? Title$  
MainWindow??5
   	   $	??350??6   $	??525??6)    ? DataContext 5         MVVM1.MainWindowViewModel  5   
    ? 	Resources 5       ?? DataType#   MVVM1.ViewModel.HomeViewModel   MVVM1.Views.HomeView&    MVVM1.ViewModel.StudentViewModel   MVVM1.Views.StudentView??%?   (??       5      *, +)(?? 2     5      *, +)?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   .+?5    
   ]? $??0??6   .+?5!      o? $	??Top=?6   .@?5"      m? $
??Home??6    m? CommandParameter$
 home??6H    m? Command 6)   ?? *
NavCommand+6H   m? 5#      $??Students??6   $ student??6L    6-   ?? *
NavCommand+6L   5$      5%      ? 5'   
   $??1??6   .+?5(      ?? ??6   ?? *CurrentViewModel+5)      5+      5,      