using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace WpfApp8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "new.json";
            File.Create(filePath).Close();
            Console.WriteLine("JSON faylı yaradıldı: " + filePath);
            Process.Start("explorer.exe");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "new.json";
            string content = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            File.WriteAllText(filePath, content);
            MessageBox.Show("Data faylda saxlanıldı");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            autoSave.Checked += AutoSaveCheckBox_Checked;
            autoSave.Unchecked += AutoSaveCheckBox_Unchecked;
        }

        private void AutoSaveCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            richTextBox.TextChanged += RichTextBox_TextChanged;
        }

        private void AutoSaveCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            richTextBox.TextChanged -= RichTextBox_TextChanged;
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filePath = "new.json";
            string content = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            File.WriteAllText(filePath, content);
            Console.WriteLine("Data avtomatik olaraq faylda saxlanıldı");
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Cut();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Copy();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Paste();
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.SelectAll();
        }
    }
}
