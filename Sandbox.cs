// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using BCLPractice;
using StringPractice;
using CastTest;

namespace ConsoleAppTest
{
    class Sandbox
    {
        static void Main()
        {
            // Main_Internal_One();
            // Main_Internal_Two();
            // Main_Internal_Three();
            // Main_Internal_Four();

            // DigitClassifier cl = new DigitClassifier();
            // cl.TestWrite(100000);
            // Console.ReadKey();

            KMP.Test();
        }
        
        static void Main_Internal_One()
        {
            Console.WriteLine("Hello, World!");

            object pg = new object();

            Console.WriteLine(GC.GetGeneration(pg));

            GC.Collect();
            Console.WriteLine(GC.GetGeneration(pg));

            GC.Collect();
            Console.WriteLine(GC.GetGeneration(pg));

            GC.Collect();
            Console.WriteLine(GC.GetGeneration(pg));
            Console.WriteLine("------------------");

            object a = new object();
            object b = new object();
            object c = new object();

            DoMethod();
            GC.Collect();

            FileLogger logger = null;

            try
            {
                logger = new FileLogger("TEST");
                logger.Write("Test");
            }
            finally
            {
                logger.Dispose();
            }

            Stack<int> intStack = new Stack<int>(10);

            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);

            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());

            Base newOne = Utility.Allocate<Base, Derived>();

            ArrayNoException<int> arrNoException = new ArrayNoException<int>(5);

            Console.WriteLine("Print Default Value : " + arrNoException[10]);

            NaturalNumber nn = new NaturalNumber();

            foreach (int i in nn)
            {
                if (i > 100)
                {
                    Console.Write("\n");
                    break;
                }

                Console.Write(i + " ");
            }

            SimpleTest st = new SimpleTest(10) { Id = 20 };

            Console.WriteLine("SimpleTest ID : " + st.Id);

            List<int> intList = new List<int> { 10, 20, 30 };

            Action<string> logOut = (txt) =>
            {
                Console.WriteLine(DateTime.Now + ": " + txt);
            };

            logOut("This is my World");

            Func<double> pi = () => 3.14159266;

            Console.WriteLine(pi);

            List<Person> people = new List<Person>()
            {
                new Person {Name = "Andrew", Age = 53, Addr = "KOR" },
                new Person {Name = "Windy", Age = 38, Addr = "USA"},
                new Person {Name = "Tom", Age = 49, Addr = "JPN"},
                new Person {Name = "Hans", Age = 14, Addr = "CHA"},
            };

            List<MainLang> lang = new List<MainLang>
            {
                new MainLang {Name = "Andrew", Lang = "C#"},
                new MainLang {Name = "Andrew", Lang = "Python"},
                new MainLang {Name = "Windy", Lang = "C++"},
                new MainLang {Name = "Tom", Lang = "Java"},
                new MainLang {Name = "Hans", Lang = "R"},
            };

            var all = from person in people select person;

            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

            var result = ParseInteger("50");
            (bool, int) result2 = result;

            Console.WriteLine(result.number);
            Console.WriteLine(result.parsed);

            Console.WriteLine(result2.Item1);
            Console.WriteLine(result2.Item2);
        }

        static void Main_Internal_Two()
        {
            ReadOnlyTest.Test();

            string input = "100,200";
            
            int pos = input.IndexOf(',');

            ReadOnlySpan<char> view = input.AsSpan();

            ReadOnlySpan<char> v1 = view.Slice(0, pos);
            ReadOnlySpan<char> v2 = view.Slice(pos + 1);

            int testData = 1_000_000_000;

            {
                Console.WriteLine(testData);
                Console.WriteLine(int.Parse(v1.ToString()));
                Console.WriteLine(int.Parse(v2.ToString()));
            }
        }

        static void Main_Internal_Three()
        {
            EventTest pro3 = new EventTest();

            pro3.Run();
            Console.WriteLine(pro3.AddAll(1, 2, 3, 4, 5, 6, 7, 8, 9));
            Console.WriteLine(pro3.AddAll(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            PrintTime printTime = new PrintTime();

            printTime.Run_CountTime();
            printTime.Run_UTC();
            printTime.Run_LeftTimeOfYear();
            printTime.Run_StopWatch();
            printTime.Run_FormatString();

            SerializationPrac sp = new SerializationPrac();

            sp.Run_Serialize();

            MemStreamPrac mem = new MemStreamPrac();

            mem.Run_MemStream();

            FileStreamPrac fsp = new FileStreamPrac();

            fsp.Run_FileStream();

            PrintString ps = new PrintString();

            ps.RunStringAppendWithManyAllocation();
            ps.RunStringAppendWithBuilder();
        }

        static void Main_Internal_Four()
        {
            CastTestRunner castTestRunner = new CastTestRunner();

            castTestRunner.Run();
        }

        static (bool parsed, int number) ParseInteger(string text)
        {
            int number = 0;
            bool result = false;

            try
            {
                number = Int32.Parse(text);
                result = true;
            }
            catch (Exception e) {}

            return (result, number);
        }

        public static int GetSizeOf<T>(T item) where T : struct
        {
            return Marshal.SizeOf(item);
        }

        public static bool CheckNull<T>(T item) where T : class
        {
            return null != item;
        }

        private static void DoMethod()
        {
            object d = new object();
            object e = new object();

            object f = new object();
            object g = new object();

            d = null;
            e = null;

            GC.Collect();

            object h = new object();
            object i = new object();

            object j = new object();
            object k = new object();

            j = null;
            k = null;

            GC.Collect();
        }
    }
}

