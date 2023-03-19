using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace PrintImage_WPF
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
        private void btnOpemImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Loại tập tin hiển thị
            openFileDialog.Filter = "Image Files (* .BMP;* .JPG;* .PNG)|* .BMP;* .JPG;* .PNG" + "|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Bitmap image = new Bitmap(openFileDialog.FileName);
                ImgSource.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void btnPrintImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(ImgSource, null);
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
