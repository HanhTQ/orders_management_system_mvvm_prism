   M S B A M L   `   `   `  ����>  :OMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OMS.Views	OMS.Views  5          OMS.Views.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:OMS.Views     5      Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Auto��62   .+�5      �� $
��From��6   $��Center=�6'   $
��Bold"�6B   $��	20 0 10 0q�6T   $��15(�6g   (  "System.Windows.Controls.DatePicker  5      $	��120��6   $��15(�6)      SelectedDateFormat$ Short=�67      SelectedDate 5       �� *
FromDate+ �� Mode$ TwoWay=�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5!      +  %Microsoft.Xaml.Behaviors.EventTrigger  5"      	   	EventName$	 SelectedDateChanged��6)   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5#      -  'Prism.Interactivity.InvokeCommandAction     TriggerParameterPath$ 
AddedItems��6`      Command 68   �� *SelectedDateCommand+6`   5$      5&      �� 5(      $��To��6   $��Center=�6%   $
��Bold"�6@   $��	20 0 10 0q�6R   $��15(�6e     5)      -   5        $��ToDateCalendar��5)      $	��120��5*      $��15(�6)   $ Short=�67    5+      �� *ToDate+$ TwoWay=� 5,        5-      $	 SelectedDateChanged��6)   .
 5.        $ 
AddedItems��6`    68   �� *SelectedDateCommand+6`   5/      51      (  "MaterialDesignThemes.Wpf.ColorZone  53         Mode$ Standard=�54      $	��300��55      $��8 4 8 4q�56         CornerRadius$ 2��57       K� ZIndex$ 1��58      $��50 0 0 0q�59      +	  %MaterialDesignThemes.Wpf.ShadowAssist 	  ShadowDepth$ Depth1=�5:      $��Center=�5;      $��Stretch=�5<      .��5=      �  � ColumnDefinitions 5>      �� 5?      $
��Auto �6/   �� 5@      $��* �6/   .+�5B      ��   MaterialDesignToolButton#���  6!   .��5C      '
  !MaterialDesignThemes.Wpf.PackIcon
   
  Kind$ Search=�66    J� Opacity$	 .56Q�6D   5D      �� 5E      $��1��5F      $��8 0 0 0q�5G      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID or States (N, P, C, R)��5H      .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5I      $��0q�5J      $	��200��5K      $��Center=�5L      $��15(�5M      ��5N      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��6^    5O        5P   "   $	 TextChanged��61   .
 5Q   &      6@   �� *SearchOrderCommand+5R   #   .��5S   6   5T      5U      5V      5W      �� 5Y       & "MaterialDesignFloatingActionButton#��[ 5Z       � ToolTip$ Add new��5[      $��50��5\      $��50��6   $��Right=�6(   $��10 10 20 10q�6D   {�5]      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL���5^      �� *AddOrderCommand+.��5_      
  $ 	PlusThick=�6*   $��20��6;   $��20��6G   5`      5a      � 5c   
   $��1��6   .+�5d      �� 6   5e      � 5g   
   $��2��6   $��5q�6   .+�5h      �� $��Center=�6A   ��6   �� *OrdersListInAPage+��5i      �� 5j       �� 
TargetType" ��6   .�5k      ��  �� Property � �� �� Value$ 15(�65   �� 5l       � ��$ Center=�6E   �� 5m       � ��$ Center=�6G   �� 5n       � ��$ Center=�6>   �� 5o       � ��$ Stretch=�6@   5p       �� View 5s      �� 5t      .P�5u      �� $��INDEX��6)     HeaderStyle �� HeaderContainerStyle# [ 68    �� DisplayMemberBinding 5v   )   ��   �� Path$  Index��� 5w      $��ORDER ID��6)   # [ 6;    5x   )   �� $  OrderID��� 5y      $��
ORDER DATE��6)   # [ 6=    5z   )   �� $  	OrderDate�! �� StringFormat$! {0:dd/MM/yyyy HH:mm:ss}���� 5{      $��ITEMS��6)   # [ 68    5|   )   �� $  
ItemsTotal��� 5}      $��TOTAL��6)   # [ 68    5~   )   �� $  
PriceTotal��� 5      $��STATE��6)   # [ 68    5�   )   �� $  State��� 5�      $��DETAILS��6)   # [ 6:   " �� CellTemplate" 5�      �� 5�   "   .R�5�   &   �� $��Details��6-   $	��100��6?   $��10q�6K   $��Center=�5�   -   $��Center=�6O   ��5�   -   �� $-  'DataContext.ShowDetailsOrderViewCommand� �� *FindAncestor+" ����5�   -   �� 5�   #   5�      5�      5�      5�      � 5�   
   $��3��6   .+�5�      �� $ 
Horizontal=�6   $��Right=�62   $
��Auto��6N   $��
0 10 30 10q�6[   .+�5�      �� $��Total: ��6   $��15(�6*   $
��Bold"�68   $��Center=�6J   �� 5�      $��Center=�69   # �� TextAlignment$# Center=�5�      $��15(�63   $
��Bold"�6A   ��5�      �� *OrdersTotal+5�   A   5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   $
��Auto��6O   $��	0 10 0 10q�6\   .+�5�      ��   MaterialDesignIconButton#��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowFirstPageCommand+.��5�      
  $ ChevronDoubleLeft=�6.   5�      �� 5�      #��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowPreviousPageCommand+.��5�      
  $ ChevronLeft=�6.   5�      �� 5�      $ 
Horizontal=�6   $��	10 0 10 0q�66   .+�5�      �� $
��Auto��5�      $��Center=�6+   $��0 2 0 0q�6F   $ �� TextAlignment$$ Center=�5�      $��15(�65   $
��Bold"�6C   ��5�      �� *	IndexPage+$ TwoWay=�$ PropertyChanged=�.��5�   U   % J� InputBindings% 5�      �� 5�      
& �� Key$& Enter��6)   ' �� Command' 65   �� *!CollectOrdersInEnterPageCommand+.��5�   1   5�      �� 5�      $��OF��6    $��	10 0 10 0q�6*   $��Center=�6=   $# Center=�5�       $��15(�67   $
��Bold"�6E   �� 5�      $
��Auto��6>   $��Center=�6K   $# Center=�5�       $��15(�67   $
��Bold"�6E   ��5�       �� *NumberPages+5�   E   �� 5�      $��PAGES��6    $��10 0 0 0q�6-   $��Center=�6?   $# Center=�5�       $��15(�67   $
��Bold"�6E   5�      �� 5�      #��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowNextPageCommand+.��5�      
  $ ChevronRight=�6.   5�      �� 5�      #��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowLastPageCommand+.��5�      
  $ ChevronDoubleRight=�6.   5�      5�      5�      5�      5�      