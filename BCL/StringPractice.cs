using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPractice
{
    public class PrintString
    {
        public void Run()
        {
            string text = "Hello World";

            Console.WriteLine(text.Contains("Hello"));
            Console.WriteLine(text.Contains("Halo"));
            Console.WriteLine();

            Console.WriteLine(text.EndsWith("World"));
            Console.WriteLine(text.EndsWith("Word"));
            Console.WriteLine();

            Console.WriteLine(text.GetHashCode());
            Console.WriteLine();

            Console.WriteLine(text.IndexOf("World"));
            Console.WriteLine(text.IndexOf("Word"));
            Console.WriteLine();

            Console.WriteLine(text.Replace("World", ""));
            Console.WriteLine(text.Replace('o', 't'));
            Console.WriteLine();

            // etc ...0
        }

        public void RunStringAppendWithManyAllocation()
        {
            DateTime before = DateTime.Now;

            string text = "Hello World";

            for (int i = 0; i< 300_000; i++)
            {
                text += "1";
            }

            DateTime after = DateTime.Now;

            Console.WriteLine("Cost Time : " + (after - before).Milliseconds);
        }

        public void RunStringAppendWithBuilder()
        {
            DateTime before = DateTime.Now;

            string text = "Hello World";

            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            for (int i = 0; i < 300_000; i++)
            {
                sb.Append("1");
            }

            string newText = sb.ToString();

            DateTime after = DateTime.Now;

            Console.WriteLine("Cost Time : " + (after - before).Milliseconds);
        }
    }
}
