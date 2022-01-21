using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public class TupleRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TupleRectangle(int x, int y, int width, int hegith)
        {
            X = x;
            Y = y;
            Width = width;
            Height = Height;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        public void Deconstruct(out int x, out int y, out int width, out int height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }
    }

    public class TestVector
    {
        double x;
        double y;

        public TestVector(double x) => this.x = x;
        public TestVector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        ~TestVector() => Console.WriteLine("~Vector()");

        public double X
        {
            get => x;
            set => x = value;
        }

        public double Y
        {
            get => y;
            set => y = value;
        }

        public double this[int index]
        {
            get => (index == 0) ? x : y;
            set => _ = (index == 0) ? x = value : y = value;
        }
    }

    class AnonymousTest
    {
        delegate (bool success, int result) MyDivide(int a, int b);

        public void AnonymousMethodTest()
        {
            MyDivide func = delegate (int a, int b)
            {
                if (b == 0)
                {
                    return (false, 0);
                }

                return (true, a / b);
            };

            // Local Function ... 
            (bool, int) func2(int a, int b)
            {
                if (b == 0)
                {
                    return (false, 0);
                }

                return (true, a / b);
            }; 

            Console.WriteLine(func(10, 5));
            Console.WriteLine(func(2, 0));
        }
    }

    struct Vector
    {
        public int x;
        public int y;

        public void Increment()
        {
            x++;
            y++;
        }

        public override string ToString()
        {
            return "X : " + x + ", Y : " + y;
        }
    }
    
    readonly struct ReadOnlyVector
    {
        readonly public int X;
        readonly public int Y;

        public ReadOnlyVector(int x, int y)
        {
            X = x; Y = y;
        }

        public ReadOnlyVector Increment(int x, int y)
        {
            return new ReadOnlyVector(X + x, Y + y);
        }

        public void Increment()
        {
            // X++; Y++;
        }
    }

    public class ReadOnlyTest
    {
        readonly Vector v1 = new Vector();

        public static void Test()
        {
            ReadOnlyTest rot = new ReadOnlyTest();
            Console.WriteLine(rot.v1.ToString());
            rot.v1.Increment();
            Console.WriteLine(rot.v1.ToString());
        }
    }

    public class EnumValueCache<TEnum> where TEnum : System.Enum 
    {
        Dictionary<TEnum, int> enumDic = new Dictionary<TEnum, int>();

        public EnumValueCache()
        {
            int[] intVal = Enum.GetValues(typeof(TEnum)) as int[];
            TEnum[] enumVal = Enum.GetValues(typeof(TEnum)) as TEnum[];

            for (int i = 0; i < intVal.Length; i++)
            {
                enumDic.Add(enumVal[i], intVal[i]);
            }
        }

        public int GetInteger(TEnum value)
        {
            return enumDic[value];
        }

        public int this[TEnum key]
        {
            get => enumDic[key];
        }
    }
}
