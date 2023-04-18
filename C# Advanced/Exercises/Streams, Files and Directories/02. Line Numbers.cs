namespace LineNumbers {
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class LineNumbers {
        static void Main() {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            ProcessLines(inputFilePath,outputFilePath);
        }
        public static void ProcessLines(string inputFilePath,string outputFilePath) {
            StringBuilder sb = new();
            var lines = File.ReadAllLines(inputFilePath);
            for(int i = 0;i<lines.Length;i++) {
                int letters = lines[i].Count(char.IsLetter);
                int marks = lines[i].Count(char.IsPunctuation);
                sb.AppendLine($"Line {i+1}: {lines[i]} ({letters})({marks})");
            }
            File.WriteAllText(outputFilePath,sb.ToString());
        }
    }
}
