import clr
clr.AddReference('PresentationFramework')
clr.AddReference('ABC')
from ABC import *
from System.Windows import *

uc =  MainControl()
mainWindow = Application.Current.MainWindow
grid = mainWindow.FindName('GridMain')

grid.Children.Add(uc)
uc.Msg()