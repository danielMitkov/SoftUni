namespace DirectoryTraversal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class DirectoryTraversal {
    static void Main() {
        string path = Console.ReadLine();
        string reportFileName = @"\report.txt";
        string reportContent = TraverseDirectory(path);
        Console.WriteLine(reportContent);
        WriteReportToDesktop(reportContent,reportFileName);
    }
    public static string TraverseDirectory(string inputFolderPath) {
        Dictionary<string,List<FileInfo>> files = new();
        string[] paths = Directory.GetFiles(inputFolderPath);
        foreach(string path in paths) {
            FileInfo file = new(path);
            if(!files.ContainsKey(file.Extension)) files.Add(file.Extension,new List<FileInfo>());
            files[file.Extension].Add(file);
        }
        StringBuilder sb = new();
        foreach(var (extension,list) in files.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key)) {
            sb.AppendLine(extension);
            foreach(var file in list.OrderBy(x => x.Length)) sb.AppendLine($"--{file.Name} - {file.Length/1024.0:f3}kb");
        }
        return sb.ToString();
    }
    public static void WriteReportToDesktop(string textContent,string reportFileName) {
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+reportFileName,textContent);
    }
}
