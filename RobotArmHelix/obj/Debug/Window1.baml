   M S B A M L   `   `   `  ����H  DRobotArmHelix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RobotArmHelixRobotArmHelix  5   	       RobotArmHelix.Window1   5   
   X THelixToolkit.Wpf, Version=2.15.0.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d$hhttp://helix-toolkit.org/wpf  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:RobotArmHelix     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&   .��5
      � .+�5   
   &   HelixToolkit.Wpf.HelixViewport3D  -   5          Name$ 
viewPort3d��5         ViewCubeHeight$	 150Q�60      ViewCubeWidth$	 150Q�6E      ViewCubeVerticalPosition$ Bottom=�6Y   &   CoordinateSystemLabelForeground
 �����'    CoordinateSystemVerticalPosition$ Center=�6�   )   "CoordinateSystemHorizontalPosition$ Right=�6�      CoordinateSystemHeight$	 150Q�6�   	   CoordinateSystemWidth$		 150Q�6  
 �� BitmapScalingMode$
 HighQuality=�61   �� EdgeMode$ Unspecified=�6_  
���   �$��5q�6�     ShowCoordinateSystem .    ShowFrameRate . $��1��6�     ShowCameraInfo .  J� IsManipulationEnabled . "   IsViewCubeEdgeClicksEnabled . ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF060A13��6#    � Offset$ 0Q�65   � 5      $ 	#FF1D64FF��6#   $ 1Q�65   5         Children. 5      (  "HelixToolkit.Wpf.GridLinesVisual3D     Width$ 16000Q�6"      Length$ 16000Q�60      	Thickness$	 1.5Q�6?      MinorDistance$	 100Q�6O      MajorDistance$	 400Q�6c   $  HelixToolkit.Wpf.MeshElement3D   Fill �	#E5CFCECE6w   $  HelixToolkit.Wpf.DefaultLights  5      5      �� 5   
   ���	#FFFBFBFB$
��Left=�6%   $	��239��6@   $��	21,21,0,0q�6M   
���   �$	��0.5��6o   $	��Top=�6�   $	��213��6�   �� 5   
   -   5         ��Name$ sliderX��5      $
��Left=�6"   $��29��6=   $��	71,52,0,0q�6I   $	��Top=�6\   $	��136��6t    � Minimum$ -10000Q�6�    � Maximum$ 10000Q�6�   6�   �� 5   
   -   5        $ sliderY��5      $
��Left=�6"   $��29��6=   $��	71,81,0,0q�6I   $	��Top=�6\   $	��136��6t   $ -10000Q�6�   $ 10000Q�6�   6�   �� 5   
   -   5        $ sliderZ��5      $
��Left=�6"   $��29��6=   $��
71,110,0,0q�6I   $	��Top=�6]   $	��136��6u   $ -10000Q�6�   $ 10000Q�6�   6�   �� 5   
   $��X��6   $
��Left=�6   $��29��67   $��	44,49,0,0q�6C   $	��Top=�6V   $��22��6n    J� RenderTransformOrigin$ 0.368,1.579&�6y   �� 5   
   $��Y��6   $
��Left=�6   $��29��67   $��	44,78,0,0q�6C   $	��Top=�6V   $��22��6n   $ 0.368,1.579&�6y   �� 5   
   $��Z��6   $
��Left=�6   $��29��67   $��
44,107,0,0q�6C   $	��Top=�6W   $��22��6o   $ 0.368,1.579&�6z   5      5      