using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datapusher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "";
        string data = "";
        public MainWindow()
        {
            InitializeComponent();
            progress.IsEnabled = false;
            progress.IsIndeterminate = false;
        }

        private async void InsertButton_Click(object sender, RoutedEventArgs e)
        {

            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();
            path = fileDialog.FileName;
            progress.IsEnabled = true;
            progress.IsIndeterminate = true;
            progress.IsEnabled = true;
            progress.IsIndeterminate = true;
            Task<string> task=GetFileAsync();
            txtBlock.Text = await task;
            progress.IsEnabled = false;
            progress.IsIndeterminate = false;
        }

        private async Task<string> GetFileAsync() 
        {
            return await Task.Run(() => getFile());
        }
        private string getFile() 
        {
            data = "";
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            data += line;
                            
                        }
                    }
                }
            }
            
            return data;
        }

         
    }
}
