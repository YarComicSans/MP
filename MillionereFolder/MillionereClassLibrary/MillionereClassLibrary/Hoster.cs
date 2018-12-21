using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MillionereClassLibrary
{
    [Serializable]
    public class Hoster
    {
        public string Name;
        public string PathToIcon;

        public Hoster(string n, string p)
        {
            Name = n;
            PathToIcon = p;
        }

        public Hoster()
        { }
    }
}
