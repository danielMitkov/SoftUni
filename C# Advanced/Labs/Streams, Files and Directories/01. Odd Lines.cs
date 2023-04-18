namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var lines = File.ReadAllLines(inputFilePath);
            using(StreamWriter writer = new(outputFilePath))
            {
                for(int i = 1;i <= lines.Length;++i)
                {
                    if(i % 2 == 0)
                    {
                        writer.WriteLine(lines[i - 1]);
                    }
                }
            }
        }
    }
}
