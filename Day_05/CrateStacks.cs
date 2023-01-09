using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_05
{
    internal class CrateStacks
    {
        private readonly Stack<char>[] _stacks;

        public CrateStacks(string[] stacksData)
        {
            _stacks = GenerateStacks(stacksData);
        }

        private Stack<char>[] GenerateStacks(string[] stacksData)
        {
            var revertData = stacksData.Reverse().ToArray();
            var numberOfStacks = Convert.ToInt32(revertData[0].Last(x => char.IsNumber(x)).ToString());
            var stacks = new Stack<char>[numberOfStacks];
            foreach (var row in revertData.Take(Range.StartAt(1)))
            {
                for (int i = 1; i <= numberOfStacks; i++)
                {
                    if (stacks[i - 1] == null)
                        stacks[i - 1] = new Stack<char>();
                    var potentialCrate = row.ElementAt(revertData[0].IndexOf(Convert.ToString(i)));
                    if (char.IsLetter(potentialCrate))
                        stacks[i - 1].Push(potentialCrate);
                }
            }
            return stacks;
        }

        public void MoveCrates(string moveCommand, bool multiple = false)
        {
            var numberOfCrates = Convert.ToInt32(moveCommand.Substring(5, moveCommand.IndexOf("from") - 6));
            var getStack = Convert.ToInt32(moveCommand.ElementAt(moveCommand.IndexOf(" to") - 1).ToString()) - 1;
            var putStack = Convert.ToInt32(moveCommand.Last().ToString()) - 1;

            if (multiple)
            {
                var tempStack = new Stack<char>();
                for (int i = 0; i < numberOfCrates; i++)
                    tempStack.Push(_stacks[getStack].Pop());
                for (int i = 0; i < numberOfCrates; i++)
                    _stacks[putStack].Push(tempStack.Pop());
            }
            else
            {
                for (int i = 0; i < numberOfCrates; i++)
                    _stacks[putStack].Push(_stacks[getStack].Pop());
            }
        }

        public void MoveCrates(string[] moveCommands, bool multiple = false)
        {
            foreach(var moveCommand in moveCommands)
                MoveCrates(moveCommand, multiple);
        }

        public string GetTopCrates()
        {
            var result = _stacks.Select(x => x.First()).ToArray();
            return new string(result);
        }
    }
}
