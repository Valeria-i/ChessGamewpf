   M S B A M L   `   `   `  ????E  AChessBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChessBoard
ChessBoard  5   	   9!clr-namespace:ChessBoard.ControlsChessBoard.Controls  5   	       ChessBoard.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChessBoard     5   	   6controls!clr-namespace:ChessBoard.Controls     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.7.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	      MaterialDesignBody#???   5
   	   $??13(?5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	    ? Title$ Chess??5   	    ? SizeToContent$ WidthAndHeight=?6    ? 
ResizeMode$ CanMinimize=?66    J? SnapsToDevicePixels$
 True??5   	    ? 	Resources 5      #   ChessBoard.CellColorConverter  CellColorConverter??%   &	         5   
   6#   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6    ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5       $
??Auto ?6   .+?5"   
   ?? 	 ?? Orientation$	 
Horizontal=?6   $??1??6.   $
??-5,0q?6>   .+?5#      ?? $??New Game??6   $??5q?6(   $
??10,5q?63   ??6B   ?? *NewGameCommand+?? 5$      $??Clear??6   $??5q?6%   $
??10,5q?60   ??6?   ?? *ClearCommand+?? 5&      $??	Step back??6   $??5q?6)   $
??10,5q?64   ??6C   ?? *BackstepCommand+?? 5'      $??	Save game??6   $??5q?6)   $
??10,5q?64   ??6C   ?? *SavegameCommand+?? 5(      $??Return game??6   $??5q?6+   $
??10,5q?66   ??6E   ?? *ReturngameCommand+5)      ?? 5*   
   $??2??6   $??21??6D   ??6$   ?? *	Numbers+??5+      ?? 5,      .R?5-      ? $??60??6   .+?5.      ?? 
 ?? Padding$	
 5,0q?6$   $??Center=?6C    ?? TextAlignment$ Center=?6^   $??16(?6u   ??62   ?? 6u   5/      50      52      ?? 53   
   $??1??6   $??1??6$   $??21??6T   ??64   ?? *	Letters+??54      ?? 55      .R?56      ? $??60??6   .+?57      ?? $??Center=?65   $ Center=?6P   $??16(?6g   ??6$   ?? 6g   58      59      ??5;      ?? 5<      .R?5=      ?? $	 
Horizontal=?6!   5>      5@      ?? 5A   
   $??2??6   $??1??6$    ?? AlternationCount$ 64??6R   ??64   ?? *Board+??5B      ?? 5C      .R?5D      ?? $??60??6   $??60??6(   ??64   ?? *DataContext.CellCommand+ ?? RelativeSource ??  ?? AncestorType
 Window??6?   ?? ??5E      ?? 5F       ?? 
TargetType" ??6$   .?5G   "   ??  ?? Property ?@?OverridesDefaultStyle ?? Value$
 True??6J   ?? 5H   "    ? ??
 ?????6?   ?? 5I   "    ? ?? 6@   Z? ?? 5J   "    ? ??$ 2q?6D   ?? 5K   "    ? ?? 5L   &   ?? 5M   *   .R?5N   .   ?? #??z??65   ._?5O   2   ?? #??z??69   #??z??6m   ._?5P   6   $   ChessBoard.Controls.ChessPiece     Piece 6J   ?? *State+5Q   3   5R   /   5S   +   5U   #    ?? Triggers 5V   "   ?? 5W   &    ?? Binding 62   ?? *!(ItemsControl.AlternationIndex)+ ??  ContentPresenter ?? 	Converter# [  ?? Value True6?   .a?5X   *   ??  ? ??
 ?`???6G   5Y   '   ?? 5Z   &    62   ?? *Active+ True6M   .a?5[   *   ??  ? ??
 ?  ??6H   5\   '   5^      5`      5a      ??5c      ?? 5d      .R?5e      A?  A? Columns$ 8??6"    A? Rows$ 8??6.   5f      5h      ?? 5i   
   $??3??6   $??1??6$   $??21??6T   ??64   ?? *	Letters+??5j      ?? 5k      .R?5l      ? $??60??6   .+?5m      ?? $??Center=?65   $ Center=?6P   $??16(?6g   ??6$   ?? 6g   5n      5o      ??5q      ?? 5r      .R?5s      ?? $	 
Horizontal=?6!   5t      5v      ?? 5w   
   $??2??6   $??2??6$   $??21??6T   ??64   ?? *	Numbers+??5x      ?? 5y      .R?5z      ? $??60??6   .+?5{      ?? $	
 5,0q?6$   $??Center=?6C   $ Center=?6^   $??16(?6u   ??62   ?? 6u   5|      5}      5      5?      5?      