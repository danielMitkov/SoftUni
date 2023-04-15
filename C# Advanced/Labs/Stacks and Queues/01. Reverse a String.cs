using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        var stack = new Stack<char>();
        foreach (var c in Console.ReadLine()) stack.Push(c);
        while (stack.Count > 0) Console.Write(stack.Pop());
    }
}