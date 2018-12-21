using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;
using Microsoft.Win32;
using MillionereClassLibrary;
using MillionereClassLibrary.Hints;

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
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "dat files ( *.dat )|*.dat",
            };
            BinaryFormatter formatter = new BinaryFormatter();

            if (ofd.ShowDialog() == true)
            {
                return (Game)formatter.Deserialize(new FileStream(ofd.FileName, FileMode.Open));
            }
            return null;
        }
    }
}
