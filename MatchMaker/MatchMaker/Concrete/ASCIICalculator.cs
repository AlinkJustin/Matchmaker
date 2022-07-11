using MatchMaker.Abstract;
using System;
using System.Text;

namespace MatchMaker.Concrete
{
    public class ASCIICalculator : CalculatorBase, IASCIICalculator, ICalculator
    {
        public override int Calculate(string name, string name2)
        {
            return CalculateScore(name, name2);
        }

        public int CalculateASCII(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                int asciiScore = 0;
                byte[] textAsASCII = Encoding.ASCII.GetBytes(name);

                foreach (var item in textAsASCII)
                {
                    asciiScore += item;
                }
                return asciiScore;
            }
            else 
            {
                throw new ArgumentNullException("Name is Empty!");
            }
        }

        private int CalculateScore(string name, string name2)
        {
            int score1 = CalculateASCII(name);
            int score2 = CalculateASCII(name2);

            int diff = Math.Abs(score1 - score2);
            int result = 100 - diff;

            return result;
        }
    }
}
