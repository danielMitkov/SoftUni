using System;
using System.IO;

namespace FolderSize {
    public class FolderSize {
        static void Main(string[] args) {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath,outputPath);
        }
        public static void GetFolderSize(string folderPath,string outputFilePath) {
            decimal sum = GetSize(folderPath);
            File.WriteAllText(outputFilePath, sum + " KB");
        }
        static decimal GetSize(string folderPath) {
            string[] files = Directory.GetFiles(folderPath);
            decimal sum = 0;
            foreach(var file in files) sum+=new FileInfo(file).Length/(decimal)1000;
            string[] dirs = Directory.GetDirectories(folderPath);
            foreach(var dir in dirs) sum += GetSize(dir);
            return sum;
        }
    }
}
