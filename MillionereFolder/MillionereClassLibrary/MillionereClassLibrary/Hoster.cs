using System;

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
