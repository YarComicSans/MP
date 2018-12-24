using System.Windows;

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
