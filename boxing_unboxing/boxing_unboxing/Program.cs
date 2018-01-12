using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            List<object> list_of_objects = new List<object>();
            list_of_objects.Add(7);
            list_of_objects.Add(28);
            list_of_objects.Add(-1);
            list_of_objects.Add(true);
            list_of_objects.Add("chair");

            foreach (object list_item in list_of_objects) {
                Console.WriteLine(list_item);
            }

            foreach (object list_item in list_of_objects)
            {
                if (list_item is int) {
                    sum += (int)list_item;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
