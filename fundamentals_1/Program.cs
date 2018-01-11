using System;

namespace fundamentals_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // 1.
            // for (int i = 1; i <= 255; i++) {
            //     Console.WriteLine(i);
            // }

            // 2.
            // for (int i = 1; i <= 100; i++) {
            //     if (i % 3 == 0 && i % 5 == 0) {
            //         continue;
            //     } else if (i % 3 == 0 || i % 5 == 0) {
            //         Console.WriteLine(i);
            //     }
            // }

            // 3.
            // for (int i = 1; i <= 100; i++) {
            //     if (i % 3 == 0 && i % 5 == 0) {
            //         Console.WriteLine("FizzBuzz: {0}", i);
            //         continue;
            //     } else if (i % 3 == 0) {
            //         Console.WriteLine("Fizz:  {0}", i);
            //     } else if (i % 5 == 0) {
            //         Console.WriteLine("Buzz:  {0}", i);
            //     }
            // }
            // 4.
            Random rand = new Random();
            int r;
            for (int i = 1; i <= 10; i++) {
                r = rand.Next(1,100);
                if (r % 3 == 0 && r % 5 == 0) {
                    Console.WriteLine("FizzBuzz: {0}", r);
                    continue;
                } else if (r % 3 == 0) {
                    Console.WriteLine("Fizz:  {0}", r);
                } else if (r % 5 == 0) {
                    Console.WriteLine("Buzz:  {0}", r);
                } else {
                    Console.WriteLine(r);
                }
            }
        }
    }
}
