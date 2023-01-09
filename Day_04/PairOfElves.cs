using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_04
{
    internal class PairOfElves
    {
        public int[] Sectors { get; set; }

        public PairOfElves(string inputSectors)
        {
            Sectors = inputSectors.Split(',', '-').Select(x => Convert.ToInt32(x)).ToArray();
        }

        public bool IsPairIntersection() => 
            IsIntersectSectorRange(Sectors.Take(2).ToArray(), Sectors.TakeLast(2).ToArray()) ||
            IsIntersectSectorRange(Sectors.TakeLast(2).ToArray(), Sectors.Take(2).ToArray());
        private bool IsIntersectSectorRange(int[] elf1, int[] elf2) => 
            (elf1[0] >= elf2[0] && elf1[1] <= elf2[1]);

        public bool IsPairOverlaping()
        {
            var firstSectors = Sectors.Take(2).ToArray();
            var secondSectors = Sectors.TakeLast(2).ToArray();
            return !(firstSectors[0] > secondSectors[1] || secondSectors[0] > firstSectors[1]);
        }
    }
}
