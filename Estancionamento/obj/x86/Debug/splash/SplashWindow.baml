   M S B A M L   `   `   `  ����  Estancionamento)    #Estancionamento.splash.SplashWindow   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   �   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5          � Title$  splash��5   	    � WindowStyle$
 None=�6    � WindowStartupLocation$ CenterScreen=�6+    � 
ResizeMode$ NoResize=�6P    � ShowInTaskbar .   � Topmost . $	��310��67  $	��459��6D   � 	Resources 5         showStoryBoard �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame	 p� KeyTime
 p� Value  HideStoryBoard��%�  &	        &	 �     �� 5   
   .��5      r� $ (FrameworkElement.Margin)�6/   $ 
txtLoading��6e   .	�5        $	 0:0:0��6*   $
 0,0,0,0q�6:     5	      $	 0:0:1��6*   $
 0,0,0,70q�6:   5
      5      �� 5   
   .��5      r� $ (FrameworkElement.Margin)�6/   $ 
txtLoading��6e   .	�5        $	 0:0:0��6*   $
 0,0,0,70q�6:     5      $	 0:0:1��6*   $
 	0,0,0,150q�6:   5      5      5      .��5      � .+�5   
   � $	��Top=�6   $��Stretch=�6'   $	��150��6E   ���	#00FFFFFF$��	0,-12,0,0q�6i    J� OpacityMask 5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#00000000��6#    � Offset$ 0.283Q�65   � 5      $ 	#00000000��6#   $ 0.778Q�65   � 5      $ White��6#   $ 0.491Q�61   5      .+�5      �� -   5         ��Name$ 
txtLoading��5       �� TextAlignment$
 Left=�6,   $��16(�6A   $��Normal"�6O   ���#FFFFFF$��Beta 0.9��6z   $
��Wrap=�6�   $��Bottom=�6�   $��Right=�6�   $	��421��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 6Q�6      Color$ 
WhiteSmoke��6'      	Direction$	 201Q�6:      Opacity$
 0.68Q�6J      ShadowDepth$ 3Q�6Y   5!      5#      �� 5$   
   $��16(�6   $
��Bold"�6"   
�������$��Center=�6G   $��315,279,10,0q�6d   $��versão 1.0.0��6z   $ Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $	��134��6�    6�     5%      $ 6Q�6   $ 	#FF797979��6&   $	 201Q�68   $
 0.68Q�6H   $ 3Q�6W   6~   �� 5&   
   $ Center=�6   $
��Left=�6+   $��	1,2,107,0q�6F   $
��Wrap=�6Y   $��EstacionamentoFacil��6m   $	��Top=�6�   
�������$
��Bold"�6�   $	��329��6�   $��26(�6�   $��46��6�   $y�Hidden=�6�    5'        5(      $ 	#FF3E3E3E��6   $	 201Q�6)   $
 0.68Q�69   $ 3Q�6H   $ 6Q�6X   5)      ��5*   
   �� 5-       �� ImageSource$[ Uhttp://www.ehsolucoes.com.br/sistemas/Estacionamento/imagens/EstancionamentoFacil.jpg��6   5/      50      