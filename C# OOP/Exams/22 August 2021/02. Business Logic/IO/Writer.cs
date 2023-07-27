namespace SpaceStation.IO
{
    using System;
    using System.IO;
    using Contracts;

    public class Writer : IWriter
    {
        private string path = "../../../output.txt";
        public Writer()
        {
            File.Delete(path);
        }
        public void Write(string message)
        {
            using(StreamWriter writer = new StreamWriter(path,true))
            {
                writer.Write(message);
            }
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
