using System;
using System.IO;

namespace OnlineShop.IO
{
    public class ConsoleWriter : IWriter
    {
        private string path = "../../../output.txt";
        public ConsoleWriter()
        {
            File.Delete(path);
        }
        public void CustomWrite(string message)
        {
            using(StreamWriter writer = new StreamWriter(path,true))
            {
                writer.Write(message);
            }
        }
        public void CustomWriteLine(string message)
        {
            using(StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine(message);
            }
        }
    }
}