using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SortThroughRecoveredFiles
{
    class Program
    {
        static List<string> extensions = new List<string>() { "NoFileExtension_"};

        private static string recoveredFilesPath = @"D:\Recovered";
        private static string destinationPath = @"D:\RecoveredFolder_";

        static List<string> destinationPaths = new List<string>() { destinationPath + @"\NoFileExtension_" };

        static void Main(string[] args)
        {
            FileInfo[] files = new DirectoryInfo(recoveredFilesPath).GetFiles();

            Directory.CreateDirectory(destinationPaths[0]);

            for (int i = 0; i < files.Length; i++) {
                string fileExtension = files[i].Extension;
                fileExtension = string.IsNullOrEmpty(fileExtension) ? "NoFileExtension_" : fileExtension;

                if (!extensions.Contains(fileExtension)) {
                    extensions.Add(fileExtension);
                    destinationPaths.Add(destinationPath + @"\" + fileExtension);
                    Directory.CreateDirectory(destinationPath + @"\" + fileExtension);
                }
            }

            for (int i = 0; i < files.Length; i++) {
                string fileExtension = files[i].Extension;
                fileExtension = string.IsNullOrEmpty(fileExtension) ? "NoFileExtension_" : fileExtension;

                int index = extensions.FindIndex(r => r.Equals(fileExtension));

                File.Move(files[i].FullName, destinationPaths[index] + @"\" + files[i].Name);
                Console.WriteLine((((double)i / (double)files.Length) * 100) + "%");
            }
        }
    }
}
