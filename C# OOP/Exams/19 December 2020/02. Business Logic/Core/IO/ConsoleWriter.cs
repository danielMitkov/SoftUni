using System;
using System.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
	public class ConsoleWriter : IWriter
	{
        private string path = "../../../output.txt";
        public ConsoleWriter()
        {
            File.Delete(path);
        }
        public void WriteLine(string message)
        {
            using(StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine(message);
            }
        }
    }
}