   M S B A M L   `   `   `  ����T  PGalaSoft.MvvmLight.Dialog, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullhJclr-namespace:GalaSoft.MvvmLight.Dialog;assembly=GalaSoft.MvvmLight.DialogGalaSoft.MvvmLight.Dialog  5   	   E AMvvmLight1, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null'clr-namespace:MvvmLight1
MvvmLight1 5   	      MvvmLight1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ZdlgJclr-namespace:GalaSoft.MvvmLight.Dialog;assembly=GalaSoft.MvvmLight.Dialog     5   	   *localclr-namespace:MvvmLight1     5   	   (ignorehttp://www.ignore.com     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  6N   $	��824��5   	   $	��631��5   	     � Title$  MVVM Light Application��5   	   +   %GalaSoft.MvvmLight.Dialog.ViewManager   Register .  � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main� � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Skins/MainSkin.xaml?�6%   %    5      .��5       � -   5         �Name$ 
LayoutRoot��5       .  (System.Windows.Interactivity.Interaction	   Triggers	 5"      /  )System.Windows.Interactivity.EventTrigger  5#      
   	EventName$
 MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5$      /  )GalaSoft.MvvmLight.Command.EventToCommand  5%      .+�5(      �� $��36(�6   $
��Bold"�5)      
���� ��$��Center=�5,      $
��Wrap=�5-      $	��142��6   $��10,10,10,641q�6%   ��5+      �� *WelcomeTitle+5-   %   �� 5.      -   5         ��Name$ listbox��5.      $
��Left=�6   $	��440��68   $��
10,157,0,0q�6E   $	��Top=�6Y   $	��603��6q    �� DisplayMemberPath$
 Name��6�   ��6}   �� *
Students+6�   �� 5/      $
��Edit��6f   $
��Left=�6u   $��
10,615,0,0q�6�   $	��Top=�6�   $��76��6�   ��6   �� *	EditCmd+��6'   �� *SelectedItem+ �� ElementName$ listbox��6�   o� 50      $
��Left=�6	   $��28��6$   $��
10,741,0,0q�60   $	��Top=�6D   $	��100��6\   .@�51      m� $��测试��6   .@�52      m� $��dd��6   53      54      56      57      