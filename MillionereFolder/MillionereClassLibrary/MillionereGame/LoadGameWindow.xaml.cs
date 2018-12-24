using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Microsoft.Win32;
using MillionereClassLibrary;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for LoadGameWindow.xaml
    /// </summary>
    public partial class LoadGameWindow : Window
    {
        public LoadGameWindow()
        {
            InitializeComponent();
        }

        public Game LoadGame()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory() + @"\Saves",
                Filter = "dat files ( *.dat )|*.dat"
            };
            var formatter = new BinaryFormatter();

            if (ofd.ShowDialog() == true)
            {
                return (Game)formatter.Deserialize(new FileStream(ofd.FileName, FileMode.Open));
            }
            return null;
        }
    }
}
