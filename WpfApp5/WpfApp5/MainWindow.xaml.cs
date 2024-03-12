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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage IMGG;
        public MainWindow()
        {
            InitializeComponent();
            bk.Source = IMGG;
        }
        Random r = new Random();
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                MainWindow window = new MainWindow();
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sound.wav");

                window.IMGG = IMGG;
                window.bk.Source = IMGG;
                window.Top = r.Next(0, 1000);
                window.Left = r.Next(0, 1100);
                sound.Play();
                window.Show();
            }
            else if (e.Key == Key.E)
            {
                try
                {
                    Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

                    dialog.Multiselect = false;
                    dialog.Title = "Выеби картинку епт";

                    // Show open folder dialog box
                    bool? result = dialog.ShowDialog();

                    // Process open folder dialog box results
                    if (result == true)
                    {
                        // Get the selected folder
                        string filePath = dialog.FileName;
                        IMGG = new BitmapImage(new Uri(filePath));
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
            }
        }
    }
}
