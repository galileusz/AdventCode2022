using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_07
{
    public class DirectoryItem
    {
        public string Name { get; set; }
        public string FullName => GetFullName();
        public List<FileItem> FileItems { get; set; }
        public List<DirectoryItem> Children { get; set; }
        public DirectoryItem? Parent { get; set; }
        public int Size => GetSizeOfDirectory();

        public DirectoryItem(string directoryName, DirectoryItem? parent)
        {
            Name = directoryName;
            FileItems = new List<FileItem>();
            Children = new List<DirectoryItem>();
            Parent = parent;
        }

        public void AddDirectoryItem(DirectoryItem child) => Children.Add(child);

        public void AddFileItem(string fileString) =>
            FileItems.Add(new FileItem(fileString));

        public DirectoryItem? GetParent() => Parent;

        public DirectoryItem GetChild(string name)
        {
            var child = Children.FirstOrDefault(x => x.Name == name);
            if (child == null)
                throw new ArgumentException($"Child with name {name} does not exist");
            return child;
        }

        public int GetSizeOfDirectory()
        {
            var size = 0;
            size += FileItems.Select(x => x.Size).Sum();
            size += Children.Select(x => x.GetSizeOfDirectory()).Sum();
            return size;
        }

        private string GetFullName()
        {
            if (Parent == null)
                return Name;
            return Parent.FullName + "." + Name;
        }

    }
}
