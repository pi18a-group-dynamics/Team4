   M S B A M L   `   `   `  ����D  @GroupTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GroupTask	GroupTask  5   	       GroupTask.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GroupTask     5   	     � Title$  
MatrixTask��5   	   $	��476��5	   	   $	��700��5
   	    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ WidthAndHeight=�5   	    J� InputBindings 5      �� 5   
    �� Command$$ local:UserCommands.SaveCommand��6    �� Gesture$ Ctrl+S��6>   �� 5   
   $$ local:UserCommands.LoadCommand��6   $ Ctrl+L��6>    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$$ local:UserCommands.SaveCommand��5      6B     5   
   -   5        $$ local:UserCommands.LoadCommand��5      6B   .��5      � .+�5   
   �� $��Размерность:��5      $��79,371,511,59q�5      $��16(�5      �� 5   
   -   5         ��Name$ tbCountOfRows��5      $��189,374,481,59q�5      $��16(�5      $��30��5      	 �� TextAlignment$	 Center=�5!      �� 5#   
   -   5        $ tbCountOfColumns��5%      $��239,374,431,59q�5&      $��16(�5'      $��30��5(      $	 Center=�5)      �� 5*   
   $��х��5+      $��220,370,460,60q�5,      $��16(�5-      �� 5.   
   -   5        $��79,406,431,27q�5/      $��Применить��50      $��14(�51      52      �� 53   
   -   5        
 ��Name$
 	cbMethods��54      $��25��55      $��70,29,210,406q�56      $��14(�57      �� 58   
   -   5        $��25��59      $��14(�5:      $��525,29,66,406q�5;      $��Вычислить��5<      5=      �� 5>   
   -   5        $��25��5?      $��25��5@      $��665,10,10,425q�5A      
�������$��?��5C      $��20(�5D      $��0 -2 0 0q�5E      5F      �� 5G   
   $��Ввод��5H      $��18(�5I      $��148,54,498,374q�5J      �� 5K   
   $��
Вывод��5L      $��18(�5M      $��490,54,140,374q�5N      &   System.Windows.Controls.DataGrid  5O   
   -	   5          Name$ dgFirstMatrix��5P         CanUserAddRows$ False��5Q      $	��250��5R      $	��250��5S      $��50,91,400,119q�5T        5U   
   -
   5        $ dgSecondMatrix��5V      $ False��5W      $	��250��5X      $	��250��5Y      $��50,91,400,119q�5Z        5[   
   -   5        $ dgResultMatrix��5\      $ False��5]      $	��250��5^      $	��250��5_      $��400,91,50,119q�5`      �� 5a   
   -   5         ��Name$ bFirstMatrix��5c      $	��100��5d      $��20��5e      $��50,346,550,94q�5f      $��1-я матрица��5g      �� 5h   
   -   5        $ bSecondMatrix��5j      $	��100��5k      $��20��5l      $��200,346,400,94q�5m      $��2-я матрица��5n      �� 5o   
   -   5        $	��100��5q      $��30��5r      $��Сохранить��5s      $��18(�5t      $��550,373,50,57q�5u      �� 5v   
   -   5        $	��100��5x      $��30��5y      $��Загрузить��5z      $��18(�5{      $��400,373,200,57q�5|      5}      5~      