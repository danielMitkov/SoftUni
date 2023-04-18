namespace EvenLines {
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class EvenLines {
        static void Main() {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }
        public static string ProcessLines(string inputFilePath) {
            using StreamReader reader = new(inputFilePath);
            StringBuilder sb = new();
            int i = 0;
            var line = "";
            while((line=reader.ReadLine())!=null) if(i++%2==0) sb.AppendLine(ReplaceReverse(line));
            return sb.ToString();
        }
        private static string ReplaceReverse(string line) {
            StringBuilder sb = new(line);
            foreach(var c in new char[] { '-',',','.','!','?' }) sb.Replace(c,'@');
            return string.Join(' ',sb.ToString().Split().Reverse());
        }
    }
}
