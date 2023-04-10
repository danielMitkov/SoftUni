using System;
using System.Linq;
using System.Text;
class SoftUni {
    static void Main() {
        var sb = new StringBuilder();
        sb.Append($"<h1>\n{Console.ReadLine()}\n</h1>\n");
        sb.Append($"<article>\n{Console.ReadLine()}\n</article>\n");
        var div = "";
        while ((div = Console.ReadLine()) != "end of comments") {
            sb.Append($"<div>\n{div}\n</div>\n");
        }
        Console.Write(sb.ToString());
    }
}