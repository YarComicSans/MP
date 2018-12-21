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

namespace Redactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPack_Click(object sender, RoutedEventArgs e)
        {
            AddPack Window = new AddPack();
            Window.Show();
            this.Close();
        }

        
        private void DeletePack_Click(object sender, RoutedEventArgs e)
        {
            DeletePack Window = new DeletePack();
            Window.Show();
            this.Close();
        }

        private void ChangePack_Click(object sender, RoutedEventArgs e)
        {
            ChangePack Window = new ChangePack();
            Window.Show();
            this.Close();
        }

        private void CloseRedactor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
