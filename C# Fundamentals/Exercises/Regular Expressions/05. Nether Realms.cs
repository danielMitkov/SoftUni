using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        string[] names = Regex.Split(Console.ReadLine(), @" *,{1} *");
        Regex regexHp = new Regex(@"[^+\-*/.\d]");
        Regex regexDmg = new Regex(@"((|-)\d+\.\d+|(|-)\d+)");
        var data = new Dictionary<string, KeyValuePair<int, double>>(names.Length - 1);
        foreach (var demon in names.OrderBy(x => x)) {
            int hp = 0;
            var sumChar = regexHp.Matches(demon).ToArray();
            foreach (var ch in sumChar) {
                hp += char.Parse(ch.Value);
            }
            double damage = 0;
            var dmg = regexDmg.Matches(demon).ToArray();
            foreach (var num in dmg) {
                damage += double.Parse(num.Value);
            }
            var mathSymbols = Regex.Matches(demon, @"[\*\/]").ToArray();
            foreach (var symbol in mathSymbols) {
                var mathOperation = symbol.Value == "*" ? damage *= 2 : damage /= 2;
            }
            data[demon] = new KeyValuePair<int, double>(hp, damage);
        }
        foreach (var demon in data) {
            Console.WriteLine($"{demon.Key} - {demon.Value.Key} health, {demon.Value.Value:F2} damage");
        }
    }
}