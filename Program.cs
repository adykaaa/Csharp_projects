using System;
using System.Collections.Generic;
using System.IO;


namespace DeleteFiless
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the Directory you want to delete files from: ");
            string dir = Console.ReadLine();

            Console.WriteLine("What is the extension of the files you want to delete? for example write .txt");
            string extension = Console.ReadLine();

            List<string> listOfFolderNames = new List<string>();

            DirectoryInfo d = new DirectoryInfo(@dir);
            d.Attributes = FileAttributes.Normal;
            DirectoryInfo[] directoriesInside = d.GetDirectories();

            foreach (DirectoryInfo dri in directoriesInside)
            {
                dri.Attributes = FileAttributes.Normal;
                listOfFolderNames.Add(dri.ToString());
            }
            
            for (int i=0; i<listOfFolderNames.Count;++i)
            {
                DirectoryInfo d2 = new DirectoryInfo(listOfFolderNames[i]);
                FileInfo[] files = d2.GetFiles("*" + extension);
                

                foreach (var unwantedFile in files)
                {
                    File.Delete(unwantedFile.FullName);
                    Console.WriteLine("Deleted : " + unwantedFile.FullName);
                }
            }

        }
    }
}
