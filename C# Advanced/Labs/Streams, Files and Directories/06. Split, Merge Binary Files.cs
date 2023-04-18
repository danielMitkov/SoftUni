namespace SplitMergeBinaryFile {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile {
        static void Main() {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath,partOnePath,partTwoPath);
            MergeBinaryFiles(partOnePath,partTwoPath,joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath,string partOneFilePath,string partTwoFilePath) {
            var image = File.ReadAllBytes(sourceFilePath);
            File.WriteAllBytes(partOneFilePath,image.Length%2!=0 ? image.Take(image.Length/2+1).ToArray() : image.Take(image.Length/2).ToArray());
            File.WriteAllBytes(partTwoFilePath,image.Length%2!=0 ? image.Skip(image.Length/2+1).ToArray() : image.Skip(image.Length/2).ToArray());
        }

        public static void MergeBinaryFiles(string partOneFilePath,string partTwoFilePath,string joinedFilePath) {
            File.WriteAllBytes(joinedFilePath, File.ReadAllBytes(partOneFilePath).Concat(File.ReadAllBytes(partTwoFilePath)).ToArray());
        }
    }
}
