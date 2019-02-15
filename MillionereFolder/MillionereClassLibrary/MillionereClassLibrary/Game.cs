using System;
using System.Collections.Generic;

namespace MillionereClassLibrary
{
    [Serializable]
    public class Game
    {
        public Hoster _hoster;
        public List<QuestionStructure> _questionStructureList;
        public Player CurrentPlayer;
        public bool GameIsWon = false;
        public bool GameIsFinished = false;
        public int CurrentScorePosition;
        public Round CurrentRound;
        public List<int> SafePositionsSet;
        public Game(Hoster host, List<QuestionStructure> qS, Player player, List<int> sP)
        {
            _hoster = host;
            CurrentScorePosition = 0;
            _questionStructureList = qS;
            CurrentPlayer = player;
            SafePositionsSet = sP;

            SafePositionsSet.Sort();
        }
        
        public void RoundWon()
        {
            CurrentScorePosition++;
            if (CurrentScorePosition >= _questionStructureList.Count)
                GameWon();

            SetNewRound();
        }

        private void GameWon()
        {
            GameIsWon = true;
        }

        private void SetNewRound()
        {if(CurrentScorePosition<15)
            CurrentRound = new Round(CurrentPlayer, _questionStructureList[CurrentScorePosition]);
        }

        public QuestionStructure GetQuestionStructure(int index)
        {
            return _questionStructureList[index];
        }
    }
}
