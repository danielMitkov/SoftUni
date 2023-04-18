namespace MergeFiles {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles {
        static void Main() {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath,secondInputFilePath,outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath,string secondInputFilePath,string outputFilePath) {
            var lines1 = File.ReadAllLines(firstInputFilePath).ToList();
            var lines2 = File.ReadAllLines(secondInputFilePath).ToList();
            using(StreamWriter writer = new(outputFilePath)) {
                while(lines1.Any()||lines2.Any()) {
                    if(lines1.Any()) {
                        writer.WriteLine(lines1[0]);
                        lines1.RemoveAt(0);
                    }
                    if(lines2.Any()) {
                        writer.WriteLine(lines2[0]);
                        lines2.RemoveAt(0);
                    }
                }
            }
        }
    }
}
