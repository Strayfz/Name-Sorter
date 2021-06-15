using System;
using System.IO;
using System.Linq;
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
            // Read text file
            string[] fileData = File.ReadAllLines(args[0]);

            // Prepares names for sorting
            Person[] unsortedNames = PrepareNames(fileData);            

            //This displays the contents of the unsorted array.
            WriteLine("LIST OF UNSORTED NAMES:");
            PrintToScreen(unsortedNames);

            // The Array is sorted with merge sort.
            WriteLine("====SORTING====");
            WriteLine();
            Person[] sortedNames = SortNames.MergeSort(unsortedNames);

            // This displays the sorted array.
            WriteLine("LIST OF SORTED NAMES:");
            PrintToScreen(sortedNames);

            // A file is created in the projects working folder.            
            WriteNamesToFile(sortedNames);

            WriteLine("Output file has been written.");
        }
        // Entry point for testing 
        public static string TestSort(string input)
        {
            string[] inputFile = input.Split('\r');
            Person[] unsortedNames = PrepareNames(inputFile);
            Person[] sortedNames = SortNames.MergeSort(unsortedNames);
            string output = CreateStringOutput(sortedNames);
            return output;
        }
        
        public static void WriteNamesToFile(Person[] inputArray)
        {
            const string FILE_PATH = @".\sorted-names-list.txt";
            FileStream outFile = new FileStream(FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            foreach (Person p in inputArray)
            {
                writer.WriteLine(p);
            }
            writer.Close();
            outFile.Close();
        }

        public static string CreateStringOutput(Person[] input)
        {
            string output = "";
            foreach (Person p in input)
            {
                output = String.Concat(output, p + "\r" );
                
            }            
            return output.TrimEnd('\r');
        }

        public static Person[] PrepareNames(string[] inputFile)
        {
            
            
            int fileLength = inputFile.Length;

            // An array of type Person is created to store names.
            Person[] personArray = new Person[fileLength];

            // Populates array
            for (var i = 0; i < fileLength; i++)
            {
                personArray[i] = new Person(inputFile[i]);
            }
            return personArray;
        }
        

        public static void PrintToScreen(Person[] names)
        {
            foreach (Person p in names)
            {
                WriteLine(p);
            }
            WriteLine();
            WriteLine($"Length: {names.Length}");
            WriteLine();
        }
    }
}
