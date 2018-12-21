using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionereGame
{
    static class Validator
    {
        public static bool CheckPlayersName(string name)
        {
            return name.Length <= 20 && name.Length >= 1;
        }
    }
}
