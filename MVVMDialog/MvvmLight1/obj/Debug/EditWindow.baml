   M S B A M L   `   `   `  ����T  PGalaSoft.MvvmLight.Dialog, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullhJclr-namespace:GalaSoft.MvvmLight.Dialog;assembly=GalaSoft.MvvmLight.DialogGalaSoft.MvvmLight.Dialog  5   	    
MvvmLight1   MvvmLight1.EditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ZdlgJclr-namespace:GalaSoft.MvvmLight.Dialog;assembly=GalaSoft.MvvmLight.Dialog     5   	   f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   "ignorehttp://www.ignore.com  5	   	   +   %GalaSoft.MvvmLight.Dialog.ViewManager    Register  . $��75.353��5   L   $��338.845��6\    � DataContext 6	   ��  �� Path$
 Edit�   Locator �� Source# [  .��5      � .+�5   
   �� -   5         ��Name$
 name��5      $
��Left=�6    $��23��6;   $��	10,10,0,0q�6G    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6�   $	��153��6�   ��6n   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Submit��6/   $
��Left=�6@   $��
175,10,0,0q�6[   $	��Top=�6o   $��62��6�   ��6   �� *	SubmitCmd+6�   �� 5   
   $��Apply��6f   $
��Left=�6v   $��	252,9,0,0q�6�   $	��Top=�6�   $��62��6�   ��6   �� *
ApplyCmd+��6.   ��  �� ElementName$
 name��$
 Text�6�   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
   	   	EventName$	 Closing��6   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6!   �� *Closed+6\   5      5      