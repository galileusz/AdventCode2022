using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Day_11
{
    public class Monkey2
    {
        private Func<Item, Item> _operation;
        private int _testDivisor;
        private List<Item> _items;
        private int _trueMonkey;
        private int _falseMonkey;
        private Dictionary<Guid, int> _itemsWithPrimaryValue;
        public int Number { get; private set; }
        public int InspectedItems { get; private set; }

        public Monkey2(string[] monkeyData)
        {
            _itemsWithPrimaryValue = new Dictionary<Guid, int>();
            Number = SetNumber(monkeyData[0]);
            _items = SetItems(monkeyData[1]);
            _operation = SetOperation(monkeyData[2]);
            _testDivisor = SetTargetNumber(monkeyData[3]);
            _trueMonkey = SetTargetNumber(monkeyData[4]);
            _falseMonkey = SetTargetNumber(monkeyData[5]);
        }

        public void ThrowItems(IEnumerable<Monkey2> monkeys)
        {
            var itemsToThrow = _items.Count;
            for (int i = 0; i < itemsToThrow; i++)
            {
                var item = _items.First();
                _items.RemoveAt(0);
                item = _operation(item);
                int targetMonkey = Inspection(item) ? _trueMonkey: _falseMonkey;
                //item = PrepareItem(item, monkeys);
                ThrowItem(item, targetMonkey, monkeys);
            }
        }

        public void CatchItem(Item item)
        {
            if (false == _itemsWithPrimaryValue.TryGetValue(item.Id, out _))
                _itemsWithPrimaryValue.Add(item.Id, item.Value);
            _items.Add(item);
        }

        public bool GetNextInspectionResult(Item item)
        {
            var tempItem = new Item(item.Value);
            tempItem = _operation(tempItem);
            return Inspection(tempItem.Value);
        }

        private void ThrowItem(Item item, int targetMonkey, IEnumerable<Monkey2> monkeys)
        {
            monkeys.First(x => x.Number == targetMonkey).CatchItem(item);
        }

        private Item PrepareItem(Item item, IEnumerable<Monkey2> monkeys)
        {
            var tempItem = new Item(_itemsWithPrimaryValue[item.Id]);
            tempItem = _operation(tempItem);
            var targetMonkey = Inspection(item.Value) ? _trueMonkey : _falseMonkey;
            var nextMonkey = monkeys.First(x => x.Number == targetMonkey);

            if (nextMonkey.GetNextInspectionResult(item) == nextMonkey.GetNextInspectionResult(tempItem))
                item.Value = tempItem.Value;
            return item;
        }

        private int SetNumber(string data)
        {
            return Convert.ToInt32(data.Replace("Monkey ", string.Empty).Replace(":", string.Empty));
        }
        private List<Item> SetItems(string data)
        {
            var valuesOfItems = data.Replace("  Starting items: ", string.Empty).Split(", ").Select(x => Convert.ToInt32(x)).ToList();
            var items = valuesOfItems.Select(x => new Item(x)).ToList();
            foreach (var item in items)
                _itemsWithPrimaryValue.Add(item.Id, item.Value);
            return items;
        }
        private Func<Item, Item> SetOperation(string data)
        {
            var func = data.Replace("  Operation: new = ", string.Empty);
            return (x) =>
            {
                var functionWithVariable = func.Replace("old", x.Value.ToString());
                var valueOfOperation = Convert.ToInt32(new DataTable().Compute(functionWithVariable, string.Empty));
                x.Value = valueOfOperation;
                return x;
            };
        }
        private int SetTargetNumber(string data)
        {
            return Convert.ToInt32(data.Split(' ').Last());
        }
        private bool Inspection(Item item)
        {
            InspectedItems++;
            return item.Value % _testDivisor == 0;
        }
        private bool Inspection(int itemValue)
        {
            return itemValue % _testDivisor == 0;
        }

    }
}
