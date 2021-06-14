using System.IO;

namespace NameSorter
{
    public static class CreateFile
    {
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
    }
}
