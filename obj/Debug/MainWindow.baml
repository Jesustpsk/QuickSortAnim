   M S B A M L   `   `   `  ����H  DQuickSortAnim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuickSortAnimQuickSortAnim  5   	       QuickSortAnim.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuickSortAnim     5   	     � Title$  
Quick Sort��5   	   $	��600��6   $	��800��6)   .��5	      �  � ShowGridLines .   � ColumnDefinitions 5
   
   �� 5      $��0.05* �6   �� 5      $��* �6   �� 5      $��0.05* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5        $��canvas��5   .   $��1��6   $��1��6!   
�������}�. $	��410��5   %   $	��710��62   5      �� 5   
   -   5        $��TbArray��5      $��1��5      $��2��6"   $	��300��6/   $	��130��6;   $��	0 0 410 0q�5       �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�5   $   $ �� HorizontalScrollBarVisibility$
 Auto=�5      5   #   �� 5!   
   -   5        $��TbArray2��5%      $��1��5!      $��2��6"   $	��300��6/   $	��130��6;   $��	250 0 0 0q�5"       . $
 Wrap=�5#   $   $
 Auto=�5$      5%   $   �� 5'   
   -   5        $��btnSort��5(   &   $��1��5'      $��2��6!   $��50��6.   $��30��69   $��640 0 0 100q�5(      .��5)   '   Start6.   �� 5+   
   -   5        $��
btnRefresh��5,   &   $��1��5+      $��2��6!   $��50��6.   $��30��69   $��640 100 0 0q�5,      .��5-   *   	Refresh63   �� 5/   
   $��1��6   $��2��6    $��75��6-   $��25��68   $��
640 0 0 20q�50      .��6$   Swap Count:61   �� 52   
   -   5        $��lSwap��54      $��1��52      $��2��6    $��75��6-   $��25��68   $��640 30 0 20q�53      .��54      06    55      56      