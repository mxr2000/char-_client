   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChatClient
ChatClient  5   	       ChatClient.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChatClient     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Log in��5
   	   $	��350��6   $	��400��6%   .��5      � .+�5   
   � $	��200��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��5q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ username��5       %  !MaterialDesignFloatingHintTextBox#��[  5      $��Center=�5      ��5      �� *
Username+ �� Mode$ TwoWay=�5      �� 5      $��1��6   $��5q�6#   $ password��5      #��[  5      $��Center=�5      ��5      �� *
Password+$ TwoWay=�5      �� 5       $��2��6      MaterialDesignOutlinedButton#��[ 5!      $��Log in��5"      $��Right=�5#      ��5$      �� *LoginCommand+�� 5&      $��3��6   $��5q�6#   $
 name��5(      #��[  5)      $��Center=�5*      ��5'      �� *Name+$ TwoWay=�5*      �� 5+      $��4��6   $��5q�6#   $ 
image path��5-      #��[  5.      $��Center=�5/      ��5,      �� *	ImagePath+$ TwoWay=�5/      �� 50      $��5��6   #��[ 51      $��Sign up��52      $��Right=�53      �� 55      $��6��6   $��5q�6!   ��6,   �� *	ErrorInfo+6L   57      58      59      