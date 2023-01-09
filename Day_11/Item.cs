using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    public class Item
    {
        public Guid Id { get; private set; }
        public int Value { get; set; }

        public Item(int value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}
