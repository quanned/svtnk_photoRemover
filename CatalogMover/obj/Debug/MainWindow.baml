   M S B A M L   `   `   `  ����G  CCatalogMover, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CatalogMoverCatalogMover  5   	       CatalogMover.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CatalogMover     5   	     � Title$  CatalogMover��5   	   $	��457��6   $
��1124��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      �� 5      $��50.04 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ ModelsListBox��5      $��1��6T   $��10,0,0,0q�6a   .@�5      �� 5      �� 5   
   -   5        $ PhotosListBox��5      $��1��6)   $��1��6d   $��5,0,2,0q�6q   6�   �� 5   
   -   5        $ MorePhotosListBox��5      $��2��6-   $��1��6h   $��2,0,5,0q�6u   6�   �� 5   
   -   5        $ FilesListBox��5      $��3��6(   $��1��6c   $��0,0,10,0q�6p   6�   �� 5   
   -   5         ��Name$ LoadFileButton��5      $��1��6)   $��	Load file��69   $��2��6M   $��Center=�6Z   $��2��6u   $��29��6�   $��0,0,10,0q�6�   6�   �� 5   
   $��Models list��6   $
��Left=�6&   $��10,0,0,0q�6A   $��Center=�6S   $��26��6n   $��67��6z   �� 5   
   $��Photos��6   $
��Left=�6!   $��5,0,0,0q�6<   $��Center=�6M   $��1��6h   $��26��6x   $��47��6�   �� 5   
   $��More photos��6   $
��Left=�6&   $��2,0,0,0q�6A   $��Center=�6R   $��2��6m   $��26��6}   $��79��6�   �� 5   
   $��Files��6   $
��Left=�6    $��Center=�6;   $��3��6V   $��26��6f   $��33��6r   �� 5    
   -   5         ��Name$ FilesListBoxCount��5       $��3��6+   $)��#Количество файлов: ��6;   $��2��6Y   $	��Top=�6f   $��0,5,10,0q�6~   $��26��6�   �� 5!   
   -   5        $ ModelsListBoxCount��5!      $+��%Количество моделей: ��6,   $��Right=�6K   $��0,5,10,0q�6g   $��2��6y   $	��Top=�6�   $��26��6�   $	��261��6�   5#      5$      