using System;
using KCTable;

namespace HashTableTests
{
    class MainClass
    {
        static int passed;
        static int failed;

        public static void Main(string[] args)
        {
            passed = 0;
            failed = 0;
            testCreate();
            testAdd();
            testExists();
            testGet();
            testRemove();
            testResize();

            Console.WriteLine("{0} tests passed out of {1}", passed, passed + failed);
            Console.ReadLine();
        }

        static void testCreate()
        {
            try
            {
                KCTable<string, string> tbl1 = new KCTable<string, string>();
                KCTable<string, int> tbl2 = new KCTable<string, int>();
                KCTable<int, char> tbl3 = new KCTable<int, char>();
            }
            catch
            {
                failed++;
                return;
            }
            passed++;
        }

         static void testAdd()
         {
            try
            {
                KCTable<string, string> tbl1 = new KCTable<string, string>();

                tbl1.Add("Casey", "17");
                tbl1.Add("Will", "17");

                if (tbl1.Size() != 2) throw new Exception();

            }
            catch
            {
                failed++;
                return;
            }
            passed++;
        }

        static void testExists()
        {
            try
            {
                KCTable<string, string> tbl1 = new KCTable<string, string>();

                tbl1.Add("Casey", "17");
                tbl1.Add("Will", "17");

                if (!tbl1.Exists("Casey") || !tbl1.Exists("Will")) throw new Exception();

            }
            catch
            {
                failed++;
                return;
            }
            passed++;
        }

        static void testGet()
        {
            try
            {
                KCTable<string, string> tbl1 = new KCTable<string, string>();

                tbl1.Add("Casey", "17");
                tbl1.Add("Will", "17");

                if (tbl1.Get("Casey") != "17" || tbl1.Get("Will") != "17") throw new Exception();

                KCTable<int, string> tbl2 = new KCTable<int, string>();
                tbl2.Add(2, "First item");
                tbl2.Add(33, "Second item");
                tbl2.Add(64, "Third item");

                tbl2.Remove(33);

                if (!tbl2.Exists(64) || tbl2.Get(64) != "Third item") throw new Exception();

            }
            catch
            {
                failed++;
                return;
            }
            passed++;
        }

        static void testRemove()
        {
            try
            {
                KCTable<string, string> tbl1 = new KCTable<string, string>();

                tbl1.Add("Casey", "17");
                tbl1.Add("Will", "17");

                tbl1.Remove("Will");

                if (tbl1.Exists("Will")) throw new Exception();

            }
            catch
            {
                failed++;
                return;
            }
            passed++;
        }
        
        static void testResize()
        {
            try
            {
                KCTable<int, char> tbl1 = new KCTable<int, char>();

                for(int i = 0; i < 30; i++)
                {
                    tbl1.Add(i, (char)i);
                }

                if (tbl1.Size() != 30 || tbl1.Capacity() != 67) throw new Exception();
            }
            catch
            {
                failed++;
                return;
            }
            passed++;
        }
    }
}
