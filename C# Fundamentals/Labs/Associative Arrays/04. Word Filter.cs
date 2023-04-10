using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        Console.Write(String.Join('\n', Console.ReadLine().Split().Where(x => x.Length % 2 == 0)));
    }
}