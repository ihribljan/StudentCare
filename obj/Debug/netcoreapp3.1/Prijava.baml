   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.Prijava   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  Prijava��5   	   $	��500��6   $	��400��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��10 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $	��200 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 
background��5      $��2��6(   $��2��68   $��7��6E   
�������6V   �� 5   
   -   5         ��Name$ border��5      
���  ��$��0 2 0 0q�63   $��2��6M   $��3��6]   �� 5!   
   $��./images/student.png��6   $	��150��6.   $	��150��6:   $��2��6G   $��2��6W   �� 5#   
   -   5         ��Name$ korisnickoIme��5#      $��Korisničko ime��6+   $��2��6A   $��4��6Q   $��Center=�6^   $��Center=�6y   �� 5$   
   -   5         ��Name$ txtKorisnickoIme��5$      $��5��6,   $��2��69   
�������$��Center=�6`   $��Center=�6{   $	��200��6�   
�������$��0 0 0 2q�6�   �� 5&   
   -   5        $ lozinka��5&      $��Lozinka��6%   $��2��64   $��7��6D   $��Center=�6Q   $��Center=�6l   �� 5'   
   -   5        $ 
txtLozinka��5'      $��8��6&   $��2��63   
�������$��Center=�6Z   $��Center=�6u   $	��200��6�   
�������$��0 0 0 2q�6�   �� 5)   
   -   5         ��Name$ 
btnPrijava��5)      $��
Prijavi se��6%   $��Center=�6:   $��Center=�6W   $��2��6r   $��9��6�   $��80��6�   $��40��6�   
�������$��1q�6�   
������6�   5*      5+      