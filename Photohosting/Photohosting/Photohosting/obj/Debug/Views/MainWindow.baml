   M S B A M L   `   `   `  ����G  CPhotohosting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Photohosting.ViewsPhotohosting.Views  5   	   A%clr-namespace:Photohosting.ViewModelsPhotohosting.ViewModels  5   	   #    Photohosting.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Photohosting.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   .vm%clr-namespace:Photohosting.ViewModels  5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1024��6)    � WindowStyle$
 None=�66   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $ 50Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ HomeMenuItem��6�   .\�5        $ 0��6'   $
 -250Q�63     5      $ 0:0:0.5��6'   $
 -250Q�69     5       $ 0:0:0.7��6'   $ 0Q�69   5!      U� 5"      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ button��6�   .\�5#        $ 0��6'   $ 0Q�63     5$      $ 0:0:0.5��6'   $ 0Q�69     5%      $ 0:0:1.5��6'   $ 1Q�69   5&      U� 5'      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ button��6�   .\�5(        $ 0��6'   $ 0Q�63     5)      $ 0:0:0.5��6'   $ 0Q�69     5*      $ 0:0:1.5��6'   $ 1Q�69   5+      5,      �� 5-   
   .��5.      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5/        $ 0��6'   $	 250Q�63     50      $ 0:0:0.5��6'   $ 0Q�69   51      U� 52      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�53        $ 0��6'   $ 50Q�63     54      $ 0:0:0.5��6'   $ 0Q�69   55      U� 56      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�57        $ 0��6'   $	 250Q�63     58      $ 0:0:0.5��6'   $ 0Q�69   59      5:      5;      	 � Triggers	 5<      :� 5=   
   
 :� RoutedEvent$
 ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5>      �� #��[  6   5?      :� 5@   
   $
 ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5A      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5A      #��[ 6A   5B      .��5D      � ���	#FFC2AEE7.+�5E   
   �� -   5         ��Name$ StackPanelMenu��5E      $	��250��6-   $
��Left=�69   $��
-250 0 0 0q�6T    J� RenderTransformOrigin$ 0.5,0.5&�6h   z�5F      V� 5G      .~�5H      �� �� 5I      �� 5J      T� 5K      5L      .+�5N      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $	��100��6J   $��Center=�6W   .+�5O      �� -   5         ��Name$ button��5O       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6)   $��0q�6�   $��80��6�   $��80��6�   $��10q�6�   $ 0.5,0.5&�6�   ��6o   Z� z�5P      V� 5Q      .~�5R      �� �� 5S      �� 5T      T� 5U      5V      ��5X      �� 5Y       j� Stretch$ UniformToFill=�6K    �� ImageSource 6%   ��  �� Path$ BinImage�6K   5[      5\      �� 5]      -   5         ��Name$
 Menu��5]   0    � UseLayoutRounding . .@�5_      �� -   5         ��Name$ HomeMenuItem��5_   #   $��60��69   $ 0.5,0.5&�6E   z�5`      V� 5a      .~�5b      �� �� 5c      �� 5d      T� 5e      5f      .��5h      ��  �� CommandParameter$
 Home��6H    �� TextDecorations$
 None{�6`    �� Command 6    �� *SelectedMenuCommand+.�6w   .�5i      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5j      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�66   $��30��6B   $��30��6M   $��Center=�6Y   $��5q�6t   
�������6   �� 5k      $)��#Доомашняя страница��6(   $��10q�6B   $��Center=�6N   
�������6i   5l      5m      5n      �� 5q      -   5        $ AccountMenuItem��5q      $��60��68   $ 0.5,0.5&�6D   z�5r      V� 5s      .~�5t      �� �� 5u      �� 5v      T� 5w      5x      .��5z      �� $ Account��6H   $
 None{�6c    6    �� *SelectedMenuCommand+.�6z   .�5{      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5|        $	 Cog=�66   $��30��6A   $��30��6L   $��Center=�6X   $��5q�6s   
�������6~   �� 5}      $)��#Настройки аккаунта��6(   $��10q�6B   $��Center=�6N   
�������6i   5~      5      5�      �� 5�      -   5        $ AddMenuItem��5�      $��60��64   $ 0.5,0.5&�6@   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      .��5�      �� $	 Add��6H   $
 None{�6_    6    �� *SelectedMenuCommand+.�6v   .�5�      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5�        $ PhotoLibrary=�66   $��30��6J   $��30��6U   $��Center=�6a   $��5q�6|   
�������6�   �� 5�      $-��'Добавить изображение��6(   $��10q�6D   $��Center=�6P   
�������6k   5�      5�      5�      �� 5�      -   5        $ AboutUsMenuItem��5�   #   $��60��6<   $ 0.5,0.5&�6H   y�6h   �� *NoAdminVisibility+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      .��5�      �� $ Contacts��6H   $
 None{�6d    6    �� *SelectedMenuCommand+.�6{   .�5�      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5�        $ Information=�66   $��30��6I   $��30��6T   $��Center=�6`   $��5q�6{   
�������6�   �� 5�      $��Контакты��6(   $��10q�68   $��Center=�6D   
�������6_   5�      5�      5�      �� 5�      -	   5        $ Errors��5�      $��60��6/   $ 0.5,0.5&�6;   y�6[   �� *AdminVisibility+$ TwoWay=�$ PropertyChanged=�z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .��5�      �� $ Errors��6H   $
 None{�6b    6    �� *SelectedMenuCommand+.�6y   .�5�      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5�        $ Error=�66   $��30��6C   $��30��6N   $��Center=�6Z   $��5q�6u   
�������6�   �� 5�      $��Ошибки��6(   $��10q�66   $��Center=�6B   
�������6]   5�      5�      5�      �� 5�      -
   5        $ Profiles��5�      $��60��61   $ 0.5,0.5&�6=   y�6]   �� *AdminVisibility+$ TwoWay=�$ PropertyChanged=�z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .��5�      �� $ Profiles��6H   $
 None{�6d    6    �� *SelectedMenuCommand+.�6{   .�5�      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5�        $ AccountGroup=�66   $��30��6J   $��30��6U   $��Center=�6a   $��5q�6|   
�������6�   �� 5�      $/��)Профили пользователей��6(   $��10q�6E   $��Center=�6Q   
�������6l   5�      5�      5�      �� 5�      -   5        $ LogOutMenuItem��5�      $��60��67   $ 0.5,0.5&�6C   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      .��5�      �� $
 None{�6�    6    �� *LogOutCommand+ 6B   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �.�6�   .�5�      �� $ 
Horizontal=�6%   $
��10 0q�6>   .+�5�        $ LogoutVariant=�66   $��30��6K   $��30��6V   $��Center=�6b   $��5q�6}   
�������6�   �� 5�      $��
Выход��6(   $��10q�65   $��Center=�6A   
�������6\   5�      5�      5�      5�      5�      � 5�   
   -   5         �Name$ GridMain��5�      ���	#FFFBFBFB$
��1024��68   $ 0.5,0.5&�6E   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�        � RowDefinitions  5�      �� 5�      $
��0.1* �6    �� 5�      $��* �6    .+�5�      �� -   5        $ ButtonCloseMenu��5�      #��[ 6.   $��0��6t   $��20��6�   $��20��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��	15 20 0 0q�6  ��6�   Z� ��6�   Z� ��6  �� *CloseMenuCommand+y�6<  �� *CloseMenuVisibility+$ PropertyChanged=�.��5�        $
 Menu=�6*   ���	#FF15131866   5�      �� 5�      -   5        $ ButtonOpenMenu��5�      #��[ 6-   $��0��6s   $��20��6�   $��20��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��	15 20 0 0q�6  ��6�   Z� ��6�   Z� ��6  �� *OpenMenuCommand+y�6:  �� *OpenMenuVisibility+$ PropertyChanged=�.��5�        $
 Menu=�6*   ���	#FF15131866   5�      �� 5�      $��1��6i   ��6   �� *SelectedViewModel+$ PropertyChanged=�6i   5�      �� 5�   
   $ 
Horizontal=�6   $	��Top=�6.   $��40��6F   $��Right=�6R   $��10q�6n   .+�5�      ��   MaterialDesignDarkSeparator#��[ 6   $��0 0 0 0q�6O   $��30��6`   $	��Top=�6l   ! � LayoutTransform! 5�      �� 5�      " �� Angle$" 90Q�6&   5�      �� 5�      $
��auto��6   $
��auto��6%     MaterialDesignFlatButton#��[ 62   ��6d   �� *MinimizeCommand+.��5�        $ WindowMinimize=�6*   ���	#FF1513186@   5�      �� 5�      $
��auto��6   $
��auto��6#   #��[ 60   ��6b   �� *MaximizeCommand+.��5�        $ WindowMaximize=�6*   ���	#FF1513186@   5�      �� 5�      $
��auto��6   $
��auto��6%   #��[ 62   ��6d   �� *CloseCommand+.��5�        $ Close=�6*   ���	#FF15131867   5�      5�      5�      5�      