using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionereClassLibrary
{
    [Serializable]
    public class HintsUsage
    {
        public int CallFriendPosition = -1;
        public List<int> AudienceHelpPositions = new List<int>();
        public List<int> FiftyFiftyPositions = new List<int>();

        public HintsUsage()
        { }

    }
}
