using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Day_11
{
    public class Monkey
    {
        private Func<long, long> _operation;
        private long _testDivisor;
        private List<long> _items;
        private long _trueMonkey;
        private long _falseMonkey;
        public long Number { get; private set; }
        public long InspectedItems { get; private set; }

        public Monkey(string[] monkeyData)
        {
            Number = SetNumber(monkeyData[0]);
            _items = SetItems(monkeyData[1]);
            _operation = SetOperation(monkeyData[2]);
            _testDivisor = SetTargetNumber(monkeyData[3]);
            _trueMonkey = SetTargetNumber(monkeyData[4]);
            _falseMonkey = SetTargetNumber(monkeyData[5]);
        }

        public void ThrowItems(IEnumerable<Monkey> monkeys, bool useWorryLevelDivisor = false)
        {
            var itemsToThrow = _items.Count;
            for (long i = 0; i < itemsToThrow; i++)
            {
                var item = _items.First();
                _items.RemoveAt(0);
                item = _operation(item);
                if (useWorryLevelDivisor)
                    item = (long)Math.Floor((double)(item / 3));
                long targetMonkey = Inspection(item) ? _trueMonkey: _falseMonkey;
                if (useWorryLevelDivisor == false)
                    item = PrepareItem(item, monkeys);
                ThrowItem(item, targetMonkey, monkeys);
            }
        }

        public void CatchItem(long item) => _items.Add(item);

        public Monkey GetNextMonkey(long item, IEnumerable<Monkey> monkeys, out long nextItem)
        {
            nextItem = _operation(item);
            long targetMonkey = Inspection(nextItem, isCounted: false) ? _trueMonkey : _falseMonkey;
            return monkeys.First(x => x.Number == targetMonkey);
        }

        private void ThrowItem(long item, long targetMonkey, IEnumerable<Monkey> monkeys)
        {
            monkeys.First(x => x.Number == targetMonkey).CatchItem(item);
        }

        private long PrepareItem(long item, IEnumerable<Monkey> monkeys)
        {
            return item % (monkeys.Select(x => x.GetDivisor()).Aggregate(1, (long x, long y) => x * y));
        }

        public long GetDivisor() => _testDivisor;

        private long SetNumber(string data)
        {
            return Convert.ToInt64(data.Replace("Monkey ", string.Empty).Replace(":", string.Empty));
        }
        private List<long> SetItems(string data)
        {
            return data.Replace("  Starting items: ", string.Empty).Split(", ").Select(x => Convert.ToInt64(x)).ToList();
        }
        private Func<long, long> SetOperation(string data)
        {
            var func = data.Replace("  Operation: new = ", string.Empty);
            return (x) =>
            {
                var functionWithVariable = func.Replace("old", x.ToString() + ".0");
                return Convert.ToInt64(new DataTable().Compute(functionWithVariable, string.Empty));
            };
        }
        private long SetTargetNumber(string data)
        {
            return Convert.ToInt64(data.Split(' ').Last());
        }
        private bool Inspection(long item, bool isCounted = true)
        {
            if (isCounted)
                InspectedItems++;
            return item % _testDivisor == 0;
        }

    }
}
