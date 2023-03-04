using System.Windows;


namespace TextEditor.MVVM.View
{
    /// <summary>
    /// Interaction logic for Test1.xaml
    /// </summary>
    public partial class Test1 : Window
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void SaveConfirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.GetName(window.StringFromRichTextBox(NameBox));
            Window window1= GetWindow(this);
            window1.Close();
        }

        private void CancelConfirm_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
