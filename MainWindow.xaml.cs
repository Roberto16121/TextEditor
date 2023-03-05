using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public string path = "";     //Stores the path to the MyDocuments
        public bool saved = true;   //stores the state of the file
        public string name = "";

        public enum State   //stores the state of the file
        {
            None,
            newFile,
            exitFile
        };
        State fileState = State.None;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void SaveToFolder()
        {
            if (path == "" && fileState != State.exitFile)
                return;
            string txtName = path + @".txt";    //ads .txt to the file name
            using StreamWriter sw = File.CreateText(txtName); // Creates the file in directory
            sw.Write(StringFromRichTextBox(TextB));
            saved = true;       //Get's all text from rich text box
            switch(fileState)
            {
                case State.newFile :
                    {
                        New_Click(this, new RoutedEventArgs());
                    }break;
                case State.exitFile :
                    {
                        Close_Click(this, new RoutedEventArgs());
                    }break;
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)   //Click on save button
        {
            if (path == "")
            {
                SaveFileDialog saveFileDialog = new();
                saveFileDialog.ShowDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                path = saveFileDialog.FileName;
            }
            SaveToFolder();
        }

        private static string StringFromRichTextBox(System.Windows.Controls.RichTextBox rtb)    //Get's the text from rich text box
        {
            string richText = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;   
            return richText;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            fileState = State.newFile;

            if (saved)
            {
                TextB.Document.Blocks.Clear();
                path = "";
                fileState = State.None;
            }
            else
            {
                Save_Click(sender, e);
            }
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
            fileState = State.exitFile;
            if (saved)      //if saved then close
                this.Close();
            else Save_Click(sender, e);    //else save
        }

        

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Load_Click(object sender, RoutedEventArgs e)   //Load txt file from computer
        {
            string filePath = "";
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.ShowDialog();                             //Shows file selector
            openFile1.Filter = "txt files (*.txt)|*.txt";   
            openFile1.DefaultExt = ".txt";
            filePath = openFile1.FileName;
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)          //loads the file in the rich text box
            {
                TextB.AppendText(line);
            }

        }
        private void NewCommandMethod(object sender, ExecutedRoutedEventArgs e)     //new file shortcut command
        {
            New_Click(sender, e);
        }


        private void SaveToFileMethod(object sender, ExecutedRoutedEventArgs e)     //save file shortcut command
        {
            Save_Click(sender, e);
        }
        private void TextB_TextChanged(object sender, TextChangedEventArgs e)
        {
            saved = false;      //this means that you can't save 
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