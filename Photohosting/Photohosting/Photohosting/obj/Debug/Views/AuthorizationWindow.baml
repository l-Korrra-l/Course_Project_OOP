   M S B A M L   `   `   `  ����G  CPhotohosting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Photohosting.ViewsPhotohosting.Views  5   	   A%clr-namespace:Photohosting.ViewModelsPhotohosting.ViewModels  5   	   ,    &Photohosting.Views.AuthorizationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,local clr-namespace:Photohosting.Views  5   	   6
viewmodels%clr-namespace:Photohosting.ViewModels  5   	     � Title$  AuthorizationWindow��5   	   $	��500��6%   $	��400��62    � WindowStyle$
 None=�6>    � WindowState 5   	   �� *CurrentWindowState+��5   Q   Z� .��5      � ���	#FFEAEAEA J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��0.7* �6   �� 5      $
��0.1* �6   �� 5      $
��0.1* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��0.3* �6#   �� 5      $
��0.5* �6#   �� 5      $
��0.3* �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��2��6N   .+�5       ��    MaterialDesignDarkSeparator#��[  6   $��0 0 0 0q�6V   $��30��6g   $	��Top=�6s    � LayoutTransform 5!      �� 5"       �� Angle$ 90Q�6*   5$      �� 5%      $
��auto��6   $
��auto��6)     MaterialDesignFlatButton#��[ 66   ��6h   �� *MinimizeCommand+.��5&      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 WindowMinimize=�6.   5'      �� 5+      $
��auto��6   $
��auto��6)   #��[ 66   ��6h   �� *CloseCommand+.��5,        $	 Close=�6.   5-      5.      �� 5/      $��Photohosting��6   ���	#FF7763C5$��Modern No. 20)�6C   $��Center=�6^   $��Center=�6{   $��25(�6�   $��1��6�   50      �� 51   
   $��1��6e   ��6   �� *SelectedViewModel+
 �� UpdateSourceTrigger$
 PropertyChanged=�6e   �� 52   
   $��2��6   $.��(Перейти к регистрации��6   $��	15 0 15 0q�6>   $��30��6Q   $	��200��6]    # MaterialDesignFlatLightBgButton#��[ 6i   ��6�   �� *ToLoginCommand+y�6�   �� *ToLoginVisibility+$
 PropertyChanged=�53      �� 54   
   $��2��6   $.��(Перейти к авторизации��6   $��	15 0 15 0q�6>   $��30��6Q   $	��200��6]   #��[ 6i   ��6�   �� *ToRegisterCommand+y�6�   �� *ToRegistrationVisibility+$
 PropertyChanged=�55      56      57      