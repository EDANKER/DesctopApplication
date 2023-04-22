using System;
using System.Collections.Generic;
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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\edgar\edankryzo.txt";

            string text = "Hello";

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);

                await fileStream.WriteAsync(buffer, 0, buffer.Length);
                
                

            }

            using (FileStream fileStream1 = File.OpenRead(path))
            {
                byte[] buffer = new byte[fileStream1.Length];

                await fileStream1.ReadAsync(buffer, 0, buffer.Length);

                string textFromFile = Encoding.Default.GetString(buffer);

            }

            



        }
    }
}