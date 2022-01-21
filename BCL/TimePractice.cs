using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLPractice
{
    public class PrintTime
    {
        public void Run_CountTime()
        {
            DateTime now = DateTime.Now;

            Console.WriteLine(now);

            DateTime dayForChild = new DateTime(now.Year, 5, 5);
            Console.WriteLine(dayForChild);

            DateTime before = DateTime.Now;

            DummySum();

            DateTime after = DateTime.Now;

            long gap = after.Ticks - before.Ticks;

            Console.WriteLine("Total Ticks : " + gap);
            Console.WriteLine("Ms : " + gap / 10_000);
            Console.WriteLine("Second : " + (gap / 10_000 / 1000));
        }

        public void Run_UTC()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now + " : " + now.Kind);

            DateTime utcNow = DateTime.UtcNow;
            Console.WriteLine(utcNow + " : " + utcNow.Kind);

            DateTime worldCup2002 = new DateTime(2002, 5, 31);
            Console.WriteLine(worldCup2002 + " : " + worldCup2002.Kind);

            worldCup2002 = new DateTime(2002, 5, 31, 0, 0, 0, DateTimeKind.Local);
            Console.WriteLine(worldCup2002 + " : " + worldCup2002.Kind);
        }

        public void Run_LeftTimeOfYear()
        {
            DateTime endOfYear = new DateTime(DateTime.Now.Year, 12, 31);
            DateTime now = DateTime.Now;

            Console.WriteLine("Left Days : " + (endOfYear - now).TotalDays);
        }

        public void Run_StopWatch()
        {
            Stopwatch st = new Stopwatch();

            st.Start();
            DummySum();
            st.Stop();

            Console.WriteLine("Total Ticks : " + st.ElapsedTicks);

            Console.WriteLine("Miliseconds : " + st.ElapsedMilliseconds);

            Console.WriteLine("Second : " + st.ElapsedMilliseconds / 1000f);

            Console.WriteLine("Second : " + st.ElapsedTicks / Stopwatch.Frequency);
        }

        public void Run_FormatString()
        {
            string text = "Hello {0} : {1}";
            string output = string.Format(text, "World", "Anderson");

            Console.WriteLine(output);

            string text2 = "Hello {0} : {1}";

            Console.WriteLine(text2, "World", "Anderson");

            Console.WriteLine("{0:E}", -123.45f);
            Console.WriteLine("{0:P}", -123.45f);
        }

        private void DummySum()
        {
            long sum = 0;

            for (int i = 0; i < 10_000_000; i++)
            {
                sum += i;
            }
        }
    }
}
