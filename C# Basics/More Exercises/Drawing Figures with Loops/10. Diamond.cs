using System;
namespace SoftUni {
    internal class Program {
        static int add = 0;
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int lr = a % 2 == 0 ? a - 2 : a - 1;
            int mid = 0;
            bool doneF = false;
            for (int i = 1; i <= Math.Ceiling(a / 2.0); ++i) {
                for (int ni = 1; ni <= lr / 2; ++ni) {
                    Console.Write("-");
                }
                Console.Write("*");
                for (int ni = 1; ni <= mid; ++ni) {
                    Console.Write("-");
                }
                if (doneF) {
                    Console.Write("*");
                }
                if (a % 2 == 0 && !doneF) {
                    Console.Write("*");
                    doneF = true;
                }
                doneF = true;
                for (int ni = 1; ni <= lr / 2; ++ni) {
                    Console.Write("-");
                }
                lr -= 2;
                mid = a % 2 == 0 ? mid + 2 : AddMid(mid);
                Console.WriteLine();
            }
            lr = 2;
            mid -= 4;
            for (int i = 1; i <= Math.Ceiling(a / 2.0) - 1; ++i) {
                for (int ni = 1; ni <= lr / 2; ++ni) {
                    Console.Write("-");
                }
                Console.Write("*");
                for (int ni = 1; ni <= mid; ++ni) {
                    Console.Write("-");
                }
                if (i < Math.Ceiling(a / 2.0) - 1) {
                    Console.Write("*");
                }
                if (i == Math.Ceiling(a / 2.0) - 1 && a % 2 == 0) {
                    Console.Write("*");
                }
                for (int ni = 1; ni <= lr / 2; ++ni) {
                    Console.Write("-");
                }
                lr += 2;
                mid = a % 2 == 0 ? mid - 2 : SubMid(mid);
                Console.WriteLine();
            }
        }
        static int AddMid(int mid) {
            if (mid == 0) {
                return 1;
            } else {
                add += 2;
                return add + 1;
            }
        }
        static int SubMid(int mid) {
            if (mid == 0) {
                return 1;
            } else {
                add -= 2;
                return add - 3;
            }
        }
    }
}