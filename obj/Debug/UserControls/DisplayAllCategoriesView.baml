   M S B A M L   `   `   `  ����M  IBillingSystemInWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:BillingSystemInWPF.UserControlsBillingSystemInWPF.UserControls  5      >    8BillingSystemInWPF.UserControls.DisplayAllCategoriesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:BillingSystemInWPF.UserControls     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $	��250 �6   6.   �� 5      $��10 �6   6,   �� 5      6!   �� 5      $��10 �6   6,   .+�5   
   �� $��0��6   
���   �$��0,0,1,0q�65   ._�5      �  � RowDefinitions 5      �� 5      $	��130 �6$   63   �� 5      6&   .+�5      �� $��1��6   .+�5      �� $
��Auto=�6#   $	��600��6F   .��5      �� .+�5      �� $��40��6%   $��12q�61   ��6=   �� *GenerateBillButton+.��6e   Generate Bill6t   �� 5      $��40��6%   $��12q�61   ��6=   �� *AddProductButton+.��6c   Add Products6q   �� 5      $��40��6&   $��12q�62   ��6>   �� *DisplayAllProductsButton+.��6k   Display All Products6�   �� 5       $��40��6&   $��12q�62   ��6>   �� *DisplayAllCategoriesButton+.��6m   Display All Categories6�   �� 5!      $��40��6&   $��12q�62   ��6>   �� *AddCategoryButton+.��6d   Add Categories6t   �� 5"      $��40��6%   $��12q�61   .��6=   53Product quantity (have to implement in productview)6r   �� 5#      $��40��6%   $��12q�61   ��6=   �� *TotalBillsButton+.��6b   Total Bills6o   5$      5%      5&      5'      5(      �� 5+   
   $��2��6   $��0q�6!   
���   �._�5,      �  5-      �� 5.      $��50 �6$   62   �� 5/      $��50 �6$   62   �� 50      $��40 �6$   62   �� 51      6&   .+�54      �� $��0��55      $��Center=�56      $��Center=�57      $��Arial Black)�6,   $��20(�6E   .��58      General Store6!   �� 59      $��1��5:      .+�5;      ��  �� Orientation$ 
Horizontal=�6!   .+�5<      �� Display Categories68   5=      5>      �� 5?      $��2��5@      $��Center=�5A      $ 
Horizontal=�5B      .+�5D      �� $��13(�6   .��6*   Total Categories :-6?   �� 5E      6   �� 5F      $��13(�6   ��6*   �� *TotalProducts+6N   5G      � 5I      $��3��6   .+�5K      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid��5L      $	��Top=�5M         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     RowBackground
 �����   AlternatingRowBackground
 ��ح���5O      �� *_productsList2+	   Columns	 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Sr no��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6@      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *Srno+6e     5W      $
 Product Name��61   $	 150 6H    .  6T   �� *ProductName+6t     5X      $
 Product Price��61   $	 150 6H    .  6T   �� *ProductPrice+6u     5Y      $
 Category��61   $	 150 6C    .  6O   �� *CategoryName+6p     5Z      $
 Product In Stock��61    .  6K   �� *ProductInStore+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5[      $

 Edit��65   $ 70 6C      CellTemplate 5\   "   �� 5]   &   .R�5^   *   �� $
��Edit��62   ��6B   �� *
EditButton+��6a   �� 5_   '   5a        5b      $
 Delete��65   $ 70 6E    5c   "   �� 5d   &   .R�5e   *   �� $��Delete��61   ��6C   �� *DeleteButton+��6d   �� 5f   '   5h      5j      5n      5q      5r      5s      5t      