using System;
class SoftUni {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        string bKeg = "";
        double bVol = 0;
        for (int i = 0; i < n; i++) {
            string mod = Console.ReadLine();
            double rad = double.Parse(Console.ReadLine());
            double hei = double.Parse(Console.ReadLine());
            double vol = Math.PI * (rad * rad) * hei;
            if (vol >= bVol) {
                bVol = vol;
                bKeg = mod;
            }
        }
        Console.WriteLine(bKeg);
    }
}