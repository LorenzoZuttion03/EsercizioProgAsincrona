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
using System.Threading;

namespace Es2_TPS
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public async void LetturaFile()
        {
            
            await Task.Run(() =>
            {
                StreamReader sr = new StreamReader("Data.txt");
                string lettura;
                lettura = sr.ReadToEnd();
                int nCaratteri = lettura.Length;

                Thread.Sleep(5000);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lblOutput.Content = nCaratteri;
                }));
               
            });
        
        }
        public async void AvanzaBarra()
        {
            await Task.Run(() =>
            {
                for(int i = 0; i < 100; i++)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        barra1.Value = i;
                    }));
                    Thread.Sleep(500);
                }
            });
        }

        private void btnAvvio_Click(object sender, RoutedEventArgs e)
        {
            LetturaFile();
            AvanzaBarra();
        }
    }
}
