using System;
using System.IO;
using static System.Console;


namespace NameSorter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Name Sorting Application");
            WriteLine();

            // Application closes if there is no input arguements.
            if (args.Length == 0)
            {
                WriteLine("You haven't provided an arguement containing a list of names to be sorted");
                WriteLine("Exiting Application!");
                
                Environment.Exit(0);
            }

            //Read Input file
            string[] unsortedNames = File.ReadAllLines(args[0]);
            int fileLength = unsortedNames.Length;

            //An array of type Person is created to store names.
            Person[] personArray = new Person[fileLength];

            for (var i = 0; i < fileLength; i++)
            {
                personArray[i] = new Person(unsortedNames[i]);
            }

            //This displays the contents of the unsorted array.
            WriteLine("LIST OF UNSORTED NAMES:");
            foreach (Person p in personArray)
            {
                WriteLine(p);
            }
            WriteLine();

            // The Array is sorted with merge sort.
            WriteLine("====SORTING====");
            WriteLine();
            Person[] sortedNames = SortNames.MergeSort(personArray);

            // This displays the sorted array.
            WriteLine("LIST OF SORTED NAMES:");
            foreach (Person p in sortedNames)
            {
                WriteLine(p);
            }
            WriteLine();
            // A file is created in the projects working folder.            
            CreateFile.WriteNamesToFile(sortedNames);

            WriteLine("Output file has been written.");
            WriteLine();

            WriteLine("ALL OPERATIONS COMPLETED");

        }
    }
}
