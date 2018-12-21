using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MillionereGame
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>

   
    public partial class ChartWindow : Window
    {
        public ObservableCollection<KeyValuePair<string, int>> ValueList { get; private set; }
        public ChartWindow(List<string> answers, SortedSet<int> possibilities)
        {
            ValueList = new ObservableCollection<KeyValuePair<string, int>>();
            for (int i = 0; i < answers.Count; i++)
                ValueList.Add(new KeyValuePair<string, int>(answers[i], possibilities.ElementAt(i)));
            InitializeComponent();
        }
    }
}
