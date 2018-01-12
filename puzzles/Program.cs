using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static int[] RandomArray() {
            int min;
            int max;
            int sum = 0;

            Random rand = new Random();
            int[] randomArr = new int[10];
            for (int i = 0; i < 10; i++) {
                randomArr[i] = rand.Next(5,25);
            }
            min = randomArr[0];
            max = randomArr[0];
            foreach (int value in randomArr) {
                Console.WriteLine(value);
                if (value < min) {
                    min = value;
                }
                if (value > max) {
                    max = value;
                }
                sum += value;
            }

            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
            Console.WriteLine("Sum = " + sum);
            return randomArr;
        }

        public static string CoinFlip() {
            Console.WriteLine("Tossing a Coin!");
            Random toss = new Random();
            int tossResult = toss.Next(1,3);
            Console.WriteLine(tossResult);
            string face_result = "";
            if (tossResult == 1) {
                face_result = "Heads";
            } else {
                face_result = "Tails";
            }
            Console.WriteLine("The result of the toss is " + face_result + ".");

            return face_result;
        }

        public static double TossMultipleCoins(int num) {
            int headCount = 0;
            double ratio = 0;
            for (int i = 0; i < num; i++) {
                string result = CoinFlip();
                if (result == "Heads") {
                    headCount++;
                }
            }
            ratio = headCount/(double)num;
            Console.WriteLine(ratio);
            return ratio;
        }

        public static List<string> Names() {
            string tempString = "";
            int swapValue = 0;
            string[] names = new string[5] {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            List<string> returnList = new List<string>();
            Random shuffle = new Random();
            for (int i = 0; i < names.Length; i++) {
                swapValue = shuffle.Next(0,5);
                tempString = names[i];
                names[i] = names[swapValue];
                names[swapValue] = tempString;
            }

            foreach (string name in names) {
                if (name.Length > 5) {
                    returnList.Add(name);
                    Console.WriteLine(name);
                }
            }
            return returnList;
        }
        static void Main(string[] args)
        {
            // RandomArray();
            // CoinFlip();
            // TossMultipleCoins(4);
            Names();
        }
    }
}
