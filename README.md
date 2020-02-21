# DataTable - ComboBox Fake Binding

This project shows a possible solution to update a ComboBox items when its linked ItemsSource it's modified elsewhere

## Explanation

If not explicitly called, a Control is not updated when its ItemsSource get modified.
A workaround is to explicitly tell the Control's ItemsSource Binding that its source has changed, via INotifyPropertyChanged.

So every time an edit is done on the DataTable exposed by the DataGrid, I notify the ComboBox of the change.

The only requirement to implement this method is to create a binding between the ComboBox and The DataTable (DefaultView).
To be able to do that, in case you have your code in the code-behind, you need to set the correct DataContext.
In my case I set MainWindow.xaml DataContext to its code-behind via: 'DataContext="{Binding RelativeSource={RelativeSource Self}}"'

Hope it helps.
