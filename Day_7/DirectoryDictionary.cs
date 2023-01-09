using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_07
{
    public class DirectoryDictionary
    {
        private readonly string mainFolderCommand = "$ cd /";
        private readonly string moveInCommand = "$ cd ";
        private readonly string moveOutCommand = "$ cd ..";
        private readonly string listCommand = "$ ls";
        private readonly string directoryCommand = "dir ";
        private Dictionary<string, DirectoryItem> _dictionaryOfDirectory { get; set; }

        public DirectoryDictionary()
        {
            _dictionaryOfDirectory = new Dictionary<string,DirectoryItem>();
            var mainDirectory = new DirectoryItem("/", null);
            _dictionaryOfDirectory[mainDirectory.FullName] = mainDirectory;
        }
        public DirectoryItem Create(string[] input)
        {
            DirectoryItem? currentDirectory = _dictionaryOfDirectory["/"];
            foreach (var line in input)
            {
                if (line.StartsWith("$"))
                {
                    if (line == mainFolderCommand || line == listCommand)
                    {
                        continue;
                    }
                    if (line == moveOutCommand)
                    {
                        currentDirectory = currentDirectory?.GetParent();
                        if (currentDirectory == null)
                            throw new ArgumentException("Error in input logic");
                    }
                    else if (line.StartsWith(moveInCommand))
                    {
                        var directoryName = line.Replace(moveInCommand, string.Empty);
                        currentDirectory = currentDirectory.GetChild(directoryName);
                    }
                }
                else if(line.StartsWith(directoryCommand))
                {
                    var directoryName = line.Replace(directoryCommand, string.Empty);
                    var newDirectory = new DirectoryItem(directoryName, currentDirectory);
                    _dictionaryOfDirectory[newDirectory.FullName] = newDirectory;
                    currentDirectory.AddDirectoryItem(newDirectory);
                }
                else
                {
                    currentDirectory.AddFileItem(line);
                }
            }
            return _dictionaryOfDirectory["/"];
        }

        public IEnumerable<int> GetDirectoriesSize()
        {
            return _dictionaryOfDirectory.Where(dir => dir.Value.Name != "/").Select(x => x.Value.Size);
        }
    }
}
