using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionereClassLibrary.Hints;
using System.Xml.Serialization;

namespace MillionereClassLibrary
{
    [Serializable]
    public class Player
    {
        public string Name;
        public List<Hint> Hints;
        public int CurrentScore;

        public Player(string n)
        {
            Name = n;
            Hints = new List<Hint> { new FiftyHint(true) , new CallFriendHint(true), new AudienceHelpHint()};
            CurrentScore = 0;
        }
        public Player()
        { }
        public List<Hint> GetAvailableHints()
        {
            var availableHints = Hints.FindAll(x => x.IsAvailable == true);
            return availableHints;
        }
    }
}
