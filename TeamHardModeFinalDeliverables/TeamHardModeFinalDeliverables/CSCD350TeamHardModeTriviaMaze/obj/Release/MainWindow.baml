   M S B A M L   `   `   `  ���� X  TCSCD350TeamHardModeTriviaMaze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CSCD350TeamHardModeTriviaMazeCSCD350TeamHardModeTriviaMaze  .    (CSCD350TeamHardModeTriviaMaze.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =local+clr-namespace:CSCD350TeamHardModeTriviaMaze     -     �Name$  wndMainWindow�� � Title$ Harry Potter TriviaMaze��$	��720��$
��1080�� � 
ResizeMode$ NoResize=�$��20(�.��� -    �Name$ grdMainGrid��$��0,0,0,0q�
���   �.+��� -    ��Name$ cnvBackgroundImage��$
��Left=�$	��641��$	��Top=�$
��1074��$��0,50,0,0q�����  �� ImageSource$ GryffindorTopLeft.jpg���� -   $ cnvBoardCanvas��$��Center=�$	��100��$	��Top=�$	��100��$��740,102,234,0q�� -   $ grdMovementGrid��$
��Left=�$	��236��$	��Top=�$	��272��$��412,288,0,0q�.+��� -    ��Name$ 	btnMoveUp��$��Up��$
��Left=�$	��Top=�$��75��$��	93,39,0,0q��� -   $ btnMoveDown��$
��Down��$
��Left=�$	��Top=�$��75��$��
93,129,0,0q��� -   $ btnMoveRight��$��Right��$
��Left=�$	��Top=�$��75��$��186,129,0,0q��� -	   $ btnMoveLeft��$
��Left��$
��Left=�$	��Top=�$��75��$��	0,129,0,0q�� -
   $ grdQuestionInstructions��$
��Left=�$	��199��$	��Top=�$	��185��$��
27,482,0,0q�.+��� -    ��Name$  txtblkQuestionInstructions��$
��Left=�$
��Wrap=�$��Instructions��$	��Top=�$	��189��$	��175�����	#FFF9F9F9$��14(�� -   $ grdTips��$
��Left=�$	��209��$	��Top=�$	��156��$��908,482,0,0q�.+��� -   $ 
txtblkTips��$
��Left=�$
��Wrap=�$
��Tips��$	��Top=�$	��189��$	��146�����	#FFF9F9F9$��14(�� -   $ grdQuestionGrid��$
��Left=�$	��164��$	��Top=�$	��626��$��236,482,0,0q�
���   �.+��� -    ��Name$ txtbxQuestionBox��$
��Left=�$	��100��	 �� TextWrapping$
	 Wrap=�$��Questions...��$	��Top=�$	��616��
 �� SelectionBrush
 �	#FFDEB912���	#FFF7CB54$��16(�.������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0.213Q�� $ 	#FFF90000��$ 1Q�.��� -   $ 
grdChoices��$
��Left=�$��48��$	��Top=�$	��616��$��	0,105,0,0q����	#FF3A0F06.+��� -   $ 	btnSubmit��$��Submit��$
��Left=�$	��Top=�$��76��$��	516,7,0,0q��� -   $ txtbxAnswerBox��$
��Left=�$��28��$
	 Wrap=�$	��Top=�$	��368��$��	10,10,0,0q��� -   $ btnClearAnswer��$��Clear��$
��Left=�$	��Top=�$��76��$��	422,7,0,0q�o� $
��Left=�$��40��$	��Top=�$
��1074��.@�m� -    m�Name$ mnuFile��$��_File��$��25��.@�m� -   $ 
mnuFileNew��$
��_New�� � ToolTip �� .+��� $
��Bold"�$��14(�$��0,0,0,5q�Open New Game�� !closes current window and opens�� a new MissleCommand.�� 
�������$��0,1,0,0q�$	��0,8q�m� -   $ mnuSave��$��_Save�� �� .+��� $
��Bold"�$��14(�$��0,0,0,5q�	Save Game�� Saves the state of the game�� so you can enjoy it later.�� 
�������$��0,1,0,0q�$	��0,8q��� m� -   $ mnuExit��$��_Exit��m� -   $ 
mnuSetting��$��
 _Settings��.@�m� -   $ mnuFileDBWindow��$��_Setting Window��$
��Left=�$��84��$	��237��$��0,0,-88.2,0q�� -   $ grdChooseHousesGrid��$
��Left=�$	��651��$	��Top=�$
��1074��$��0,40,0,0q�
���   �.+��� -   $ cnvChooseHouse��$
��Left=�$	��651��$	��Top=�$
��1074������ $ ChooseAHouseMenu.jpg���� -   $ btnHouseGryffindor��$�� ��$
��Left=�$	��Top=�$	��196��$��
73,152,0,0q�$	��234����Z� �� -   $ btnHouseRavenclaw��$�� ��$
��Left=�$	��Top=�$	��196��$��310,152,0,0q�$	��234����Z� �� -   $ btnHouseSlytherin��$�� ��$
��Left=�$	��Top=�$	��196��$��566,152,0,0q�$	��234����Z� �� -   $ btnHouseHufflepuff��$�� ��$
��Left=�$	��Top=�$	��196��$��827,152,0,0q�$	��234����Z� 