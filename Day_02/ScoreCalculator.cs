using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_02
{
    internal static class ScoreCalculator
    {
        private static Dictionary<string, int> firstStrategyDictionary = new Dictionary<string, int>()
        {
            {"A X", 4},
            {"A Y", 8},
            {"A Z", 3},
            {"B X", 1},
            {"B Y", 5},
            {"B Z", 9},
            {"C X", 7},
            {"C Y", 2},
            {"C Z", 6}
        };
        private static Dictionary<string, int> secondStrategyDictionary = new Dictionary<string, int>()
        {
            {"A X", 3},
            {"A Y", 4},
            {"A Z", 8},
            {"B X", 1},
            {"B Y", 5},
            {"B Z", 9},
            {"C X", 2},
            {"C Y", 6},
            {"C Z", 7}
        };

        public static int CalculateByFirstStrategy(string duel) => firstStrategyDictionary[duel];
        public static int CalculateBySecondStrategy(string duel) => secondStrategyDictionary[duel];
    }
}
