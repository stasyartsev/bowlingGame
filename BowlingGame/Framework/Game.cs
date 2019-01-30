using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Framework
{
    public class Game
    {
        private int[] _frameScore;
        private int[] _rolls;

        public Game() { }

        public void Start()
        {
            _rolls = Enumerable.Repeat(0, 21).ToArray();
            _frameScore = Enumerable.Repeat(0, 10).ToArray();
        }

        public void Roll(int roll, int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentOutOfRangeException("Pins amount may not be negative or more than ten");
            _rolls[roll] = pins;
        }

        public int GetGameScore()
        {
            int roll = 0;
            for (int frame = 0; frame < _frameScore.Length; frame++)
            {
                if (StrikeRoll(roll))
                {
                    _frameScore[frame] = 10 + StrikeBonus(roll);
                    roll++;
                }

                else if (SpareRoll(roll))
                {
                    _frameScore[frame] = 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    _frameScore[frame] = SumOfRollsInFrame(roll);
                    roll += 2;
                }
            }
            return _frameScore.Sum();
        }

        //Validate if a strike
        private bool StrikeRoll(int roll)
        {
            return _rolls[roll] == 10;
        }

        //Validate if a spare
        private bool SpareRoll(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }

        //Get Strike bonus
        private int StrikeBonus(int roll)
        {
            return _rolls[roll + 1] + _rolls[roll + 2];
        }

        //Get Spare bonus
        private int SpareBonus(int roll)
        {
            return _rolls[roll + 2];
        }

        //Calucalate amount of pins per one frame
        private int SumOfRollsInFrame(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }
    }
}
