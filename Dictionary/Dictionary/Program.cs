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
            for (var i = 0; i < 100; i++)
            {
                dict.Add(i, i);
            }

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine(new string('-',30));
            Console.WriteLine(dict.Count);
        }
    }
}
