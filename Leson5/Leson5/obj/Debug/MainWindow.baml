   M S B A M L   `   `   `  ����A  =Leson5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Leson5Leson5  5   	       Leson5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Leson5     5   	     � Title$  
MainWindow��5	   	   $	��494��6   $��649.221��6)    � 	Resources 5
         Leson5.LockedConverter   lockedConverter��%   &	          5   
   6:   5      .��5      � $
��Left=�6   $	��890��6&   $	��450��62   $	��Top=�6?   $��0,0,-357,-31q�6W    � ColumnDefinitions 5   
   �� 5      $
��214* �6   �� 5      $
��231* �6   .+�5   
   �� -   5         ��Name$ EmployeeListView��5      $��10,10,271,68q�6E   $��2��6�   ��6-   ��  �� View 5      �� 5      .P�5      ��  �� Width$	 100��6%   $��Имя��61    �� DisplayMemberBinding 6>   �� *Name+�� 5      $	 100��6%   $��Пол��61    6>   �� *Gender+�� 5      $	 200��6%   $��День рожденья��61    6H   �� *
Birthday+�� 5      $	 100��6%   $��Департамент��61    6F   �� *
Department+�� 5      $	 100��6%   $��Блокировка��61    6E   �� *Locked+ �� 	Converter# [  5      5      �� 5   
   -   5         ��Name$ changeButton��5      $<��6Изменить/добавить сотрудника��6'   $��10,356,271,10q�6N   $��2��6�   5      5      