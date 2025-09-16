using System;
using System.IO;
using System.Linq;

namespace ConsoleNameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: name-sorter <file-path>");
                return;
            }

            string inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Error: File '{inputFile}' not found.");
                return;
            }

            var names = File.ReadAllLines(inputFile)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

            var sortedNames = NameSorter.SortNames(names);

            // Print to console
            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }

            // Write to file
            File.WriteAllLines("sorted-names-list.txt", sortedNames);
        }
    }
}