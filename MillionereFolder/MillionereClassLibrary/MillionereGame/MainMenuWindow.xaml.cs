using System.Windows;
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
            var window = new StartNewGameWindow();
            window.Show();
            this.Close();
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new LoadGameWindow();
            var game = window.LoadGame();
            if (game == null) return;
            var gameWindow = new GameWindow(game);
            gameWindow.Show();
            this.Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
