   M S B A M L   `   `   `  ����G  CPhotohosting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Photohosting.ViewsPhotohosting.Views  5      A%clr-namespace:Photohosting.ViewModelsPhotohosting.ViewModels  5      +    %Photohosting.Views.PictureControlView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Photohosting.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .vm%clr-namespace:Photohosting.ViewModels  5      .��5      � 
�������.+�5   
   �� .��5      �   � ColumnDefinitions  5      �� 5      $
��0.3* �6   �� 5      $
��0.7* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   .+�5      �� $��0��6    �� Left$ 55��6)   
 �� Top$ 30��6:   $	��200��6J   $
��auto��6V   $	��200��6d   $��	12,12,8,0q�6t   $	��Top=�6�   $��.5q�6�    �� CornerRadius$ 18��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6+      Opacity$ .5Q�6:      ShadowDepth$ 3Q�6G   ._�5      �� $��6q�6   $ 15��62   ._�5      � .+�5      �� -   5        $
��Mask��5   %   
�������$��.5q�6D   $ 13��6Y   �� 5      .+�5   "   �� $
��auto��6)   $	��200��66   ��6D   �� *
BinImage+	 J� OpacityMask	 5    "   !� 5!   &   
 !� Visual
 62   ��  �� ElementName$
 Mask��5#      5$      5%      5&      �� 5'      $��1��6   .+�5(      �� $��0��6!    �� Orientation$ Vertical=�61   $��40 0 0 0q�6H   .+�5)      �� $ 
Horizontal=�6%   .+�5*      �� $��Имя: ��6(   
���   �$��17(�6H   $��Nirmala UI Semilight)�6V   $	��Top=�6y   �� 5+      
���   �$��17(�6�   $��Nirmala UI Semilight)�6�   $	��Top=�6�   ��6(   �� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5,      �� 5-      $ 
Horizontal=�6%   .+�5.      �� $��	Тема:��6(   
���   �$��17(�6H   $��Nirmala UI Semilight)�6V   $	��Top=�6y   �� 5/      
���   �$��17(�6�   $��Nirmala UI Semilight)�6�   $	��Top=�6�   ��6(   �� *Topic+$ TwoWay=�$ PropertyChanged=�6�   50      �� 51      $ 
Horizontal=�6%   .+�52      �� $��Описание: ��6(   
���   �$��17(�6M   $��Nirmala UI Semilight)�6[   $	��Top=�6~   �� 53      
���   �$��17(�6�   $��Nirmala UI Semilight)�6�   $	��Top=�6�   ��6(   �� *Description+$ TwoWay=�$ PropertyChanged=�6�   54      �� 55      $ 
Horizontal=�6%   $
��Left=�6>   .+�56      d� $��30��6+   $��30��66    )  %MaterialDesignFlatPrimaryToggleButton#��[  6z    � ToolTip$+ %MaterialDesignFlatPrimaryToggleButton��57      $
��Left=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Сохранить��6�   ��56   B   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Heart=�   Size$ 16X� d� 	IsChecked 57   3   �� *SavePicture+$ TwoWay=�$ PropertyChanged=���6�   �� *SavePictureCommand+6�   �� 58      $��Center=�6%   $1��+Посмотреть комментарии��6B      MaterialDesignOutlinedButton#��[ 6d   ��6�   �� *CommentsCommand+y�6�   �� *CommentsVisibility+$ TwoWay=�$ PropertyChanged=��� 59      $��Center=�6%   $��Рекомендации��6B   #��[ 6Z   ��6�   �� *CommentsCommand+y�6�   �� *NoCommentsVisibility+$ TwoWay=�$ PropertyChanged=�5:      5;      5<      �� 5=      $��0��6   $��0��6)   $��2��69   $��Комментарии:��6M   $��Center=�6a   $��Bottom=�6~   
���   �$��27(�6�   y�6�   �� *NoCommentsVisibility+$ TwoWay=�$ PropertyChanged=��� 5>      $��1��6!   $��0��6.   $��2��6>   ��6R   �� *SelectedViewModel+$ PropertyChanged=��� 5?      $��0��6   $��0��6)   $��2��69   $'��!Так же на эту тему:��6M   $��Center=�6h   $��Bottom=�6�   
���   �$��27(�6�   y�6�   �� *CommentsVisibility+$ TwoWay=�$ PropertyChanged=�5A      5B      5C      5D      