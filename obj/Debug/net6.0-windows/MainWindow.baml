   M S B A M L   `   `   `  ????E  ATextEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TextEditor
TextEditor  5   	       TextEditor.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TextEditor     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)    ? WindowStyle$
 None=?5	   	    ? 
ResizeMode$ CanResizeWithGrip=?5
   	   
??????  ? AllowsTransparency$
 True??5   	    ? 	Resources 5         SaveCommand  
NewCommand??%:   &	        &	      ?? 5   
   6   ?? 5   
   6   5       J? InputBindings 5      ?? 5   
   
 ?? Key$ S??6    ?? 	Modifiers$ Controlf?6    ?? Command# [  61   ?? 5   
   $ N??6   $ Controlf?6   # [ 61   	 J? CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
   Command#
 [  5      6@     5   
   -   5        #
 [ 5      6?   .??5      ?? -   5         ??Name$ Border??5   	   
??????? ?? CornerRadius$ 10??5   	   ._?5!   
   ?  ? ColumnDefinitions 5"      ?? 5#      $??15 ?6#   ?? 5$      ?? 5%      $??15 ?6#    ? RowDefinitions 5(      ?? 5)      $??35 ?6    ?? 5*      .+?5-      ]? -   5        $??0??5-      $??1??6%   
?????? $??False??6g   $	??800??6~   $
??Left=?6?   ]? 5.      -   5        $??1??5.      $??2??6%   
?????? $??False??6g   $	??800??6~   $
??Left=?6?   ]? 5/      -   5        $??1??5/      $??0??6%   
?????? $??False??6g   $	??800??6~   $
??Left=?6?   ?? 50      $??0??6   $??1??6&    ?? Orientation$ 
Horizontal=?66   .+?51      ?? -   5         ??Name$
 Load??52      $??25??53      $??25??6    $
??Left=?54      ??56      ?? 57      $??Images/download-file.png??6    $
??Fill=?6B   59      ?? 5:      -   5        $
 Save??5;      $??25??5<      $??25??6    $
??Left=?5=      ??5?      ?? 5@      $??Images/floppy-disk.png??6    5B      ?? 5C      -	   5        $	 New??5D      $??25??5E      $??25??6    $
??Left=?5F      ??5H      ?? 5I      $??Images/new-document.png??6    5K      5N      ?? 5R      $??2q?6   $??0??6$   $??1??61   $??Right=?6A   $ 
Horizontal=?6]   .+?5S      ?? -
   5        $ Minimize??5T      $??25??5U      $??25??6    $??Right=?5V      ??5X      ?? 5Y      $??Images/minus.png??6    5[      ?? 5\      -   5        $ 	WindowRes??5]      $??25??5^      $??25??6    $??Right=?5_      ??5a      ?? 5b      $!??Images/exit-full-screen.png??6    5d      ?? 5f      -   5        $ CloseButton??5h      $??25??5i      $??25??6    $??Right=?5j      ??5l      ?? 5m      $??Images/cancel.png??6    5o      5q      ?? 5r      -   5         ??Name$ TextB??5t      " ?? VerticalScrollBarVisibility$ Visible=?5s      $??1??5u      $??1??6!    ?? 
AcceptsTab$
 True??5w      5|      5}      5~      