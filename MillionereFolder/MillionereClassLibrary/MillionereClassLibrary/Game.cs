using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionereClassLibrary
{
    public class Game
    {
        private Hoster _hoster;
        private int currentScorePosition;
        private Round _currentRound;
        private bool _roundWon;
        private Player _currentPlayer;
        private List<QuestionStructure> _questionStructureList;

        public Game(Hoster host, Player player)
        {
            _hoster = host;
            currentScorePosition = 0;
            _currentPlayer = player;
        }


        public void ChangeScore()
        { }

        public void PlayRound()
        { }


    }
}
