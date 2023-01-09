using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_07
{
    public class FileItem
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public FileItem(string fileString)
        {
            var splited = fileString.Split(' ');
            Name = splited[1];
            Size = Convert.ToInt32(splited[0]);
        }
    }
}
