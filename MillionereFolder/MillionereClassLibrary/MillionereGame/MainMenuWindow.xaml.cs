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
using MillionereClassLibrary;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGameWindow window = new StartNewGameWindow();
            window.Show();
            this.Close();
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGameWindow window = new LoadGameWindow();
            Game game = window.LoadGame();
            if (game != null)
            {
                GameWindow gameWindow = new GameWindow(game);
                gameWindow.Show();
                this.Close();
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
