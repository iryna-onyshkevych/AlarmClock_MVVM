   M S B A M L   `   `   `  ����G  CMVVMDatagrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVMAlarmClockMVVMAlarmClock  5   	   !    MVVMAlarmClock.UpdateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MVVMAlarmClock     5   	     � Title$  UpdateWindow��5      $	��250��6   $	��300��6*    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       '�� P     �� 5
   
   " ��6   .�5      ��  � ��$ 
Constantia)�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 
Constantia)�62   5      5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   .��6   Hour6#   �� 5   
   -   5        $��alhour��5      $��0��6   $��60,0,0,0q�6-   ��6?   �� *
NewHours+6\   �� 5   
   $��1��6   .��6   Minute6%   �� 5   
   -   5        $��alminute��5      $��1��6   $��60,0,0,0q�6/   ��6A   �� *
NewMinutes+6`   �� 5   
   $��2��6   .��6   Second6%   �� 5   
   $��2��6   $��60,0,0,0q�6    ��62   �� *
NewSeconds+6Q   �� 5    
   $��3��6   .��6   Day6"   �� 5!   
   -   5        $��alday��5!      $��3��6   $��60,0,0,0q�6,   ��6>   �� *	NewDate+6Z   �� 5"   
   $��4��6   .��6   	Message6&   �� 5#   
   -   5        $��	almessage��5#      $��4��6   $��60,0,0,0q�60   ��6B   �� *
NewMessage+6a   �� 5$   
   -   5        $��Submit��5$      $��5��6   
�������$��
Constantia)�6D   .��6\   OK6`   5%      5&      