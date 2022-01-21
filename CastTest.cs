using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastTest
{
    public class Currency
    {
        float money;
        public float Money 
        {
            get
            {
                return money;
            }
            
            protected set
            {
                money = value;
            }
        }

        public Currency(float money)
        {
            this.money = money;
        }

        public void Show()
        {
            Console.WriteLine(this.ToString());
        }
    }

    public class Won : Currency
    {
        public Won(float money) : base(money) { }

        public override string ToString()
        {
            return Money + "\\";
        }

        static public implicit operator Dollar(Won won)
        {
            return new Dollar(won.Money / 1173.5f);
        }

        static public implicit operator Yen(Won won)
        {
            return new Yen(won.Money / 13f);
        }
    }

    public class Dollar : Currency
    {
        public Dollar(float money) : base(money) { }

        public override string ToString()
        {
            return Money + "$";
        }

        static public implicit operator Yen(Dollar dollar)
        {
            return new Yen(dollar.Money * 113.7f);
        }

        // implicit, explicit은 하나만 ... 둘 다는 중복이 되서 안된다!!!
        static public implicit operator Won(Dollar dollar)
        {
            return new Won(dollar.Money * 1173.5f);
        }
    }

    public class Yen : Currency
    {
        public Yen(float money) : base(money) { }

        public override string ToString()
        {
            return Money + "Yen";
        }

        static public implicit operator Won(Yen yen)
        {
            return new Won(yen.Money * 13f);
        }

        static public implicit operator Dollar(Yen yen)
        {
            return new Dollar(yen.Money * 0.0088f);
        }
    }

    public class DeleTest
    {
        private delegate int Op(int arg1, int arg2);

        List<int> list;
        Dictionary<string, Op> ops;

        static int Add(int arg1, int arg2) => arg1 + arg2;
        static int Sub(int arg1, int arg2) => arg1 - arg2;
        static int Div(int arg1, int arg2) => arg1 / arg2;
        static int Mul(int arg1, int arg2) => arg1 * arg2;

        public DeleTest(int initSize = 100)
        {
            list = new List<int>(initSize);

            ops = new Dictionary<string, Op>();

            ops.Add("+", DeleTest.Add);
            ops.Add("-", DeleTest.Sub);
            ops.Add("/", DeleTest.Div);
            ops.Add("*", DeleTest.Mul);
        }

        public void SetList(in List<int> source)
        {
            list = source.ToList();

            list.Sort(new Comparaer());
        }

        public int DoCalc(string key, int arg1, int arg2)
        {
            Op op = ops[key] as Op;

            if (op != null)
            {
                return op(arg1, arg2);
            }

            return 0;
        }

        public void ShowList()
        {
            foreach (var target in list)
            {
                Console.Write(target + ", ");
            }

            Console.WriteLine();
        }

        public struct Comparaer : IComparer<int>
        {
            int IComparer<int>.Compare(int x, int y)
            {
                return x > y ? 1 : x == y ? 0 : -1;
            }
        }
    }

    public class CastTestRunner
    {
        public void Run()
        {
            Yen yen = new Yen(1000f);
            Dollar dollar = new Dollar(1000f);
            Won won = new Won(1000000f);

            yen.Show();
            dollar.Show();
            won.Show();

            Yen newYen = won;
            Dollar newDollar = won;

            newYen.Show();
            newDollar.Show();

            DeleTest deleTest = new DeleTest();

            List<int> list = new List<int>
            {
                1,2,3,4,5,6,7,8,9,0,-1,-2,-4,-5,11,23,43
            };

            deleTest.SetList(in list);
            deleTest.ShowList();
        }
    }

    public class SortObject
    {
        public delegate bool CompareDelegate(int arg1, int arg2);

        int[] numbers;

        public SortObject(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Sort(CompareDelegate compareDelegate)
        {
            int temp;

            for (int i = 0; i < numbers.Length; i++)
            {
                int lowPos = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (compareDelegate(numbers[i], numbers[lowPos]))
                    {
                        lowPos = j;
                    }
                }

                temp = numbers[lowPos];
                numbers[lowPos] = numbers[i];
                numbers[i] = temp;
            }
        }

        public void Display()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + ", ");
            }
        }
    }
}
