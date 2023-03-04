using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public string path = "";     //Stores the path to the MyDocuments
        public bool saved = true;   //stores the state of the file
        public string name = "";    //name of the file
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SaveToFolder()
        {
            string txtName = path + @".txt";    //ads .txt to the file name
            using StreamWriter sw = File.CreateText(txtName); // Creates the file in directory
            sw.Write(StringFromRichTextBox(TextB));     //Get's all text from rich text box
        }
        private void Save_Click(object sender, RoutedEventArgs e)   //Click on save button
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.ShowDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            path = saveFileDialog.FileName;
            SaveToFolder();
        }

        private static string StringFromRichTextBox(System.Windows.Controls.RichTextBox rtb)    //Get's the text from rich text box
        {
            string richText = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;   
            return richText;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            
            /* LOAD
            using (var dialog = new FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                path = dialog.SelectedPath;
            }*/
        }
        private bool maximized = false;     //var for storing the state of the window
        private void WindowRes_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);//make it fullscreen
            if (!maximized)
            {
                window.WindowState = WindowState.Maximized;
                maximized = true;
            }
            else
            {
                window.WindowState = WindowState.Normal;
                maximized = false;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)      //Click on close button
        {
            if (saved)      //if saved then close
                this.Close();
            else SaveToFolder();    //else save
        }

        private void TextB_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)    //if the user writes in the text box
        {
            saved = false;      //this means that you can't save
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Functionality for moving the window
        private void Header_Loaded(object sender, RoutedEventArgs e)
        {
            InitHeader(sender as DockPanel);
        }
        private void InitHeader(DockPanel header)
        {

            header.MouseLeftButtonDown += (s, e) =>
            {
                DragMove();
            };
        }
    }
}