using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionereClassLibrary.Hints;

namespace MillionereClassLibrary
{
    public class Player
    {
        public string Name;
        public List<Hint> Hints;
        public int CurrentScore;

        public Player(string n)
        {
            Name = n;
            Hints = new List<Hint> {new CallFriendHint(), new AudienceHelpHint(), new FiftyHint()};
            CurrentScore = 0;
        }
        public List<Hint> GetAvailableHints()
        {
            var availableHints = Hints.FindAll(x => x.IsAvailable == true);
            return availableHints;
        }
    }
}
