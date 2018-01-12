using System;
using System.Collections.Generic;

namespace basic_13
{
    class MainClass
    {
        public static void print_1_255() {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void print_odd_1to255() {
            for (int i = 1; i <= 255; i++) {
                if (i % 2 != 0) {
                    Console.WriteLine(i);
                }
            }
        }

        public static void print_sumTo255() {
            int sum = 0;
            for (int i = 0; i <= 255; i++) {
                sum += i;
                Console.WriteLine("New number: {0} Sum: {1}", i, sum);
            }
        }

        public static void iterate_array(int[] myArr) {
            foreach (int i in myArr) {
                Console.WriteLine(i);
            }
        }

        public static void find_max(int [] myArr) {
            int max = myArr[0];
            for (int i = 1; i < myArr.Length; i++) {
                if (myArr[i] > max) {
                    max = myArr[i];
                }
            }
            Console.WriteLine(max);
        }

        public static void get_average(int[] myArr) {
            int sum = 0;
            double average = 0;
            foreach (int num in myArr) {
                sum += num;
            }
            average = sum / (double)myArr.Length;
            Console.WriteLine("{0}", average.ToString("#.##"));
        }

        public static void array_with_odd() {
            int[] intArr = new int[128];
            int idx = 0;
            for (int i = 1; i <= 255; i++) {
                if (i % 2 != 0) {
                    intArr[idx] = i;
                    idx++;
                }
            }

            foreach (int intValue in intArr)
            {
                Console.Write("{0,4}",intValue);
            }
        }

        public static int greater_than_y(int[] myArr, int y) {
            int count = 0;

            foreach (int num in myArr) {
                if (num > y) {
                    count++;
                }
            }

            return count;
        }

        public static void square_the_values(int[] myArr) {
            for (int i = 0; i < myArr.Length; i++) {
                myArr[i] *= myArr[i];
            }

            foreach (int j in myArr) {
                Console.WriteLine(j);
            }
        }

        public static void eliminate_negativity(int[] myMixedArr) {
            for (int i = 0; i < myMixedArr.Length; i++) {
                if (myMixedArr[i] < 0) {
                    myMixedArr[i] = 0;
                }
                Console.Write("{0,4}", myMixedArr[i]);
            }
        }

        public static void min_max_average(int[] myMixedArr) {
            int min = myMixedArr[myMixedArr.Length - 1];
            int max = myMixedArr[0];
            double avg = 0.0;
            int sum = 0;

            foreach (int num in myMixedArr) {
                if (num < min) {
                    min = num;
                }
                if (num > max) {
                    max = num;
                }
                sum += num;
            }
            avg = sum / (double)myMixedArr.Length;

            Console.WriteLine("Min: {0}",min);
            Console.WriteLine("Max: {0}",max);
            Console.WriteLine("Average: {0}", avg.ToString("#.##"));

        }

        public static void shift_values(int[] myArr) {
            for (int i = 0; i < (myArr.Length-1); i++) {
                myArr[i] = myArr[i + 1];
            }
            myArr[myArr.Length - 1] = 0;
            foreach (int value in myArr) {
                Console.Write("{0,4}",value);
            }
        }

        public static void number_to_string(int[] myArr) {
            List<object> myList = new List<object>();

            for (int i = 0; i < myArr.Length; i++) {
                if (myArr[i] < 0) {
                    myList.Add("Dojo");
                } else {
                    myList.Add(myArr[i]);
                }
            }

            foreach (object value in myList) {
                Console.WriteLine(value);
            }
        }

        public static void Main(string[] args)
        {
            //print_1_255();
            //print_odd_1to255();
            //print_sumTo255();
            int[] myArr= new int[] { 1, 53, 5, 27, 9, 44 };
            int[] myMixedArr = new int[] { 1, 5, -4, 12, -33, -27, 16, 75 };
            //iterate_array(myArr);
            //find_max(myArr);
            //get_average(myArr);
            //array_with_odd();
            //Console.WriteLine(greater_than_y(myArr, 11));
            //square_the_values(myArr);
            //eliminate_negativity(myMixedArr);
            //min_max_average(myMixedArr);
            //shift_values(myArr);
            number_to_string(myMixedArr);
        }
    }
}
