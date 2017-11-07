using System;
using KCTable;

namespace HashTableTests
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            KCTable<string, int> table = new KCTable<string, int>();
            table.Add("Casey", 17);
            Console.WriteLine(table.Get("Casey"));
            Console.ReadLine();
        }
    }
}
