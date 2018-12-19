using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new MyDictionary<int, int>();
            dict.Add(1, 1);
            dict.Add(2, 2);
            dict.Add(3, 3);
            dict.Add(4, 4);
            dict.Add(5, 5);
            dict.Add(6, 6);
            dict.Add(7, 7);
            dict.Add(8, 8);
            dict.Add(9, 9);
            dict.Add(10, 10);
            dict.Add(11, 11);
            dict.Add(12, 12);

            Console.WriteLine(dict.ContainsKey(12));
            Console.WriteLine(dict.ContainsValue(17));
        }
    }
}
