using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_03
{
    public class Backpack
    {
        public List<char> AllItems { get; set; } 
        public List<char> Compartment1 { get; set; }
        public List<char> Compartment2 { get; set; }

        public Backpack(string backpackItems)
        {
            Compartment1 = new List<char>();
            Compartment2 = new List<char>();
            AllItems = new List<char>();
            AllItems.AddRange(backpackItems);
            var firstCompartment = backpackItems.Substring(0, backpackItems.Length / 2);
            Compartment1.AddRange(firstCompartment);
            Compartment2.AddRange(backpackItems.Replace(firstCompartment, ""));
        }

        public int GetScore()
        {
            var sameItem = Compartment1.Intersect(Compartment2).First();
            return LetterToScore(sameItem);
        }

        private int LetterToScore(char letter)
        {
            var additionalPoints = char.IsUpper(letter) ? 26 : 0;
            var number = (byte)char.ToLower(letter) - 96;
            return number + additionalPoints;
        }

        public int GetScoreOfBadges(Backpack secondBackpack, Backpack thirdBackpack)
        {
            var badge = this.AllItems.Intersect(secondBackpack.AllItems).Intersect(thirdBackpack.AllItems).First();

            return LetterToScore(badge);
        }
    }
}
