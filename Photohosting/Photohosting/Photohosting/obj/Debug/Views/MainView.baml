   M S B A M L   `   `   `  ����G  CPhotohosting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Photohosting.ViewsPhotohosting.Views  5      A%clr-namespace:Photohosting.ViewModelsPhotohosting.ViewModels  5      !    Photohosting.Views.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Photohosting.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      .vm%clr-namespace:Photohosting.ViewModels  5      $	��450��5   7   .��5      �   � RowDefinitions  5   
   �� 5      $
��0.2* �6   �� 5      $
��0.9* �6    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.5* �6   �� 5      $��0.05* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��0��6#   $��3��63      Mode$ 
PrimaryMid=�6G   $��50��6Y   $
��auto��6e   $	��700��6r   .��5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . $��0 10 0 0q�6d   .+�5        $��Center=�6/   $	��600��6L   $ Standard=�6X   $��8 4 8 4q�6h      CornerRadius$ 2��6z    K� ZIndex$ 1��6�   $��16 0 0 0q�6�   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�6�   .��5      � $��20��6    5      �� 5    "   $
��Auto �63   �� 5!   "   $��* �63   �� 5"   "   $
��Auto �63   .+�5$      ��    MaterialDesignToolButton#���   6%   $��0��6X   $��25��6h   $��25��6t   $��	-5 -3 0 0q�6   ��6�   �� *SearchCommand+��6�   ��  �� Path$	 Tag�	 �� ElementName$	 	TbxSearch��.��5%   "   '  !MaterialDesignThemes.Wpf.PackIcon  
 J� Opacity$	
 .56Q�6k   $��20��6y   $��20��6�      Kind 6;   �� $	 Tag�$	 	TbxSearch��6�   5&      �� 5'      -   5         ��Name$ 	TbxSearch��5(   K   $��1��5'   &   $��8 0 0 0q�66   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Build a search bar��6G   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�6{   $��0q�5(      $	��200��6!   $��Center=�60   ��5'   �   �� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5(   ^   ��5)   "   �� 5*   &    �� 
TargetType" ��6,    �� Triggers 5+   *   �� 5,   .    �� Binding 6:   �� $	 	TbxSearch��$ 	IsFocused� �� Value True6t   .a�5-   2   ��  �� Property �@�Tag �� Value$ WindowClose��6H   5.   /   �� 5/   .    6:   �� $	 	TbxSearch��$ 	IsFocused�	 False6t   .a�50   2   ��  �@�Tag$ Magnify��6H   51   /   53   '   .��54   1   55      56      58      �� 59       �� SelectedIndex$ 0��6   $��
20 -10 0 0q�61   $��0q�6E   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Standard=�6Y     MaterialDesignPaper   UnderlineBrush# �  6�    �� Text$ Тема��6�   #���  5:   	    �� SelectedItem 6=   �� *Topic+$ TwoWay=�$ PropertyChanged=�.@�5;      �� $��
Аниме��6'   �� 5=      $��Игры��6'   �� 5>      $
��ИТ��6'   �� 5?      $��Мемы��6'   �� 5@      $��Музыка��6'   �� 5A      $��Мультфильмы��6'   �� 5B      $��Обои��6'   �� 5C      $��Путешествия��6'   �� 5D      $��Рецепты��6'   �� 5E      $��
Спорт��6'   �� 5F      $��Тату��6'   �� 5G      $��Фильмы��6'   5H      5I      5J      5K      �� 5L   
   $��1��6e   $��0��6r   $��3��6�   ��6   �� *SelectedViewModel+$ PropertyChanged=�6�   �� 5M   
   $��20q�6   $��Center=�6    $	��Top=�6=    �� TextAlignment$ Center=�6U   
���  ��$	��500��6�      MaterialDesignBody2TextBlock#��[ 6�   $��35��6�   $��1��6�   $��0��6�   $��3��6  ��6l   �� *
ErrorMes+6  5N      5P      