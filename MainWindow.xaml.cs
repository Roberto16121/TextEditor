using System;
using System.IO;
using System.Text;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using TextEditor.MVVM.View;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public string path;
        public bool saved = true;
        public string name = null;
        public MainWindow()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = path +@"\TxtEditor\";
            System.IO.Directory.CreateDirectory(path);
            
        }
        private void SaveToFolder(object sender)
        {
            if(name == null)
            {
                Test1 test1= new Test1();
                test1.Show();
                return;
            }
            string txtName = name + @".txt";
            using (StreamWriter sw = File.CreateText(path + txtName))
                sw.Write(StringFromRichTextBox(TextB));//get all text from rich text
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            SaveToFolder(sender); 
        }
        public void GetName(string name)
        {
            this.name = name;
            SaveToFolder(this);
        }

        public string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WindowRes_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);//make it fullscreen
            window.Width = 1920;
            window.Height = 1080;
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (saved)
                this.Close();
        }

        private void TextB_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            saved = false;
        }
    }
}
