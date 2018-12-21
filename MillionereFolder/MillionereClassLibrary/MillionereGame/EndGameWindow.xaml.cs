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
using System.Windows.Shapes;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for EndGameWindow.xaml
    /// </summary>
    public partial class EndGameWindow : Window
    {
        public EndGameWindow(string result)
        {
            InitializeComponent();
            ResultsOfGameLabel.Content = result;
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = new MainMenuWindow();
            menu.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
