using MatchMaker.Abstract;
using System;
using System.Linq;

namespace MatchMaker.Concrete
{

    public class ComplexCalculator : CalculatorBase, IComplexCalculator, ICalculator
    {
        private static readonly string vowels = "aeiouy";
        private static readonly char[] vowelsArray = vowels.ToCharArray();
        private static readonly string love = "love";
        private static readonly char[] loveArray = love.ToCharArray();


        public override int Calculate(string name, string name2)
        {
            return ComplexCalculate(name, name2);
        }

        public int ComplexCalculate(string name, string name2)
        {
            int score = 0;
            int numberOfVowelsName1 = CountChars(name, vowelsArray, false);
            int numberOfVowelsName2 = CountChars(name2, vowelsArray, false);
            int numberOfConsonantsName1 = CountChars(name, vowelsArray, true);
            int numberOfConsonantsName2 = CountChars(name2, vowelsArray, true);
            int numberofLoveName1 = CountChars(name, loveArray, false);
            int numberofLoveName2 = CountChars(name2, loveArray, false);

            if (name.Length == name2.Length)
            {
                score += 20;
            }
            if (numberOfVowelsName1 == numberOfVowelsName2)
            {
                score += 20;
            }
            if (numberOfConsonantsName1 == numberOfConsonantsName2)
            {
                score += 20;
            }
            if (numberofLoveName1 > 0 || numberofLoveName2 > 0)
            {
                score += (numberofLoveName1 * 5);
                score += (numberofLoveName2 * 5);
            }
            if ((StartsWithConstonant(name) && StartsWithConstonant(name2)))
            {
                score += 10;
            }
            if (StartsWithVowel(name) && StartsWithVowel(name2))
            {
                score += 10;
            }

            return score;
        }

        private int CountChars(string searchIn, char[] searchFor, bool inverse)
        {
            int result = 0;
            int resultReverse = 0;

            result = searchIn.Count(searchFor.Contains);
            if (inverse)
            {
                for (int i = 0; i < searchFor.Length; i++)
                {
                    if (!searchIn.Contains(searchFor[i]))
                    {
                        resultReverse++;
                    }
                }
            }
            return inverse ? resultReverse : result;
        }

        private bool StartsWithVowel(string name)
        {
            char firstChar = name[0];

            return vowelsArray.Contains(firstChar);
        }

        private bool StartsWithConstonant(string name)
        {
            char firstChar = name[0];

            return !vowelsArray.Contains(firstChar);
        }

    }
}
