   M S B A M L   `   `   `  ����>  :OMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OMS.Views	OMS.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          OMS.Views.ProductsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:OMS.Views     5      Z VPrism.Unity.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5
      0sys&clr-namespace:System;assembly=mscorlib 	 5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Auto��62   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Standard=�5       $	��300��5!      $��8 4 8 4q�5"         CornerRadius$ 2��5#       K� ZIndex$ 1��5$      $��30 0 0 0q�5%      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5&      $��Center=�5'      $��Stretch=�5(      .��5)      � 	 � ColumnDefinitions	 5*      �� 5+      $
��Auto �6/   �� 5,      $��* �6/   .+�5.      ��   MaterialDesignToolButton#���  6!   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Search=�66    J� Opacity$	 .56Q�6D   50      �� 51      $��1��52      $��8 0 0 0q�53      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
ID or Name��54      .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�55      $��0q�56      $	��200��57      $��Center=�58      $��15(�59      ��5:      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��6^   * 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5;      +	 	 %Microsoft.Xaml.Behaviors.EventTrigger	  5<   "    	  	EventName$ TextChanged��61   *
 	 $Microsoft.Xaml.Behaviors.TriggerBase 
  Actions. 5=   &   -  'Prism.Interactivity.InvokeCommandAction     Command 6@   �� *SearchProductCommand+5>   #   .��5?   6   5@      5A      5B      5C      �� 5E       & "MaterialDesignFloatingActionButton#��[ 5F       � ToolTip$ Add new��5G      $��50��5H      $��50��6   $��Right=�6(   $��10 10 20 10q�6D   {�5I      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL���5J      �� *AddProductCommand+.��5K        $
 	PlusThick=�6*   $��20��6;   $��20��6G   5L      5M      � 5O   
   $��1��6   .+�5P      �� 6   5Q      � 5S   
   $��2��6   $��5q�6   .+�5T      �� $��Center=�6C   ��6   �� *ProductsListInAPage+��5U      �� 5V       �� 
TargetType" ��6   .�5W      ��  �� Property � �� �� Value$ 15(�65   �� 5X       � ��$ Center=�6E   �� 5Y       � ��$
 Left=�6G   �� 5Z       � ��$ Center=�6>   �� 5[       � ��$ Stretch=�6@    �� Triggers 5\      �� 5]       �� Binding 5^   "   �� 5_   &    �� Path$ Discontinued�6.    �� Value 5a   "   ��5b   &   true��68   .a�5d   "   ��  � ��
 � E��6?   5e      5g       �� View 5j      �� 5k      .P�5l      �� $��INDEX��6)     HeaderStyle �� HeaderContainerStyle# [ 68    �� DisplayMemberBinding 5m   )   �� $ Index��� 5n      $��
PRODUCT ID��6)   # [ 6=    5o   )   �� $ 	ProductID��� 5p      $��PRODUCT NAME��6)   # [ 6?    5q   )   �� $ ProductName��� 5r      $��CATEGORY��6)   # [ 6;    5s   )   �� $ Category��� 5t      $��
UNIT PRICE��6)   # [ 6=    5u   )   �� $ 	UnitPrice��� 5v      $��UNITS IN STOCK��6)   # [ 6A    5w   )   �� $ UnitsInStock��� 5x      $��UNITS ON ORDER��6)   # [ 6A    5y   )   �� $ UnitsOnOrder�5z      5|      5}      � 5   
   $��3��6   .+�5�      �� $ 
Horizontal=�6   $��Right=�62   $
��Auto��6N   $��
0 10 30 10q�6[   .+�5�      �� $��Total: ��6   $��15(�6*   $
��Bold"�68   $��Center=�6J   �� 5�      $��Center=�6;     �� TextAlignment$  Center=�5�      $��15(�63   $
��Bold"�6A   ��5�      �� *ProductsTotal+5�   A   5�      �� 5�      $ 
Horizontal=�6   $��Center=�62   $
��Auto��6O   $��	0 10 0 10q�6\   .+�5�      ��   MaterialDesignIconButton#��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowFirstPageCommand+.��5�        $
 ChevronDoubleLeft=�6.   5�      �� 5�      #��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowPreviousPageCommand+.��5�        $
 ChevronLeft=�6.   5�      �� 5�      $ 
Horizontal=�6   $��	10 0 10 0q�66   .+�5�      �� $
��Auto��5�      $��Center=�6+   $��0 2 0 0q�6F   ! �� TextAlignment$! Center=�5�      $��15(�65   $
��Bold"�6C   ��5�      �� *	IndexPage+" �� Mode$" TwoWay=�$ PropertyChanged=�.��5�   U   # J� InputBindings# 5�      �� 5�      
$ �� Key$$ Enter��6)   % �� Command% 65   �� *#!CollectProductsInEnterPageCommand+.��5�   1   5�      �� 5�      $��OF��6    $��	10 0 10 0q�6*   $��Center=�6=   $  Center=�5�       $��15(�67   $
��Bold"�6E   �� 5�      $
��Auto��6>   $��Center=�6K   $  Center=�5�       $��15(�67   $
��Bold"�6E   ��5�       �� *NumberPages+5�   E   �� 5�      $��PAGES��6    $��10 0 0 0q�6-   $��Center=�6?   $  Center=�5�       $��15(�67   $
��Bold"�6E   5�      �� 5�      #��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowNextPageCommand+.��5�        $
 ChevronRight=�6.   5�      �� 5�      #��[ 5�      $ MaterialDesignIconButton��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL���5�      �� *ShowLastPageCommand+.��5�        $
 ChevronDoubleRight=�6.   5�      5�      5�      5�      5�      