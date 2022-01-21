using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class PrimeCallbackArg : EventArgs
    {
        public int Prime;

        public PrimeCallbackArg(int prime)
        {
            this.Prime = prime;
        }
    }

    class PrimeGenerator
    {
        public event EventHandler PrimeGenerated;
        public EventTest owner;

        public void Run(int limit)
        {
            for (int i = 2; i <= limit; i++)
            {
                if (IsPrime(i) && PrimeGenerated != null && owner != null)
                {
                    PrimeGenerated(owner, new PrimeCallbackArg(i));
                }
            }
        }

        private bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (int i = 3; Math.Pow(i, 2) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }
    }

    public class EventTest
    {
        public int Sum = 0;

        void PrintPrime(object sender, EventArgs arg)
        {
            Console.Write((arg as PrimeCallbackArg).Prime + ", ");
        }

        void SumPrime(object sender, EventArgs arg)
        {
            Sum += (arg as PrimeCallbackArg).Prime;
        }

        public void Run()
        {
            PrimeGenerator gen = new PrimeGenerator();
            
            gen.owner = this;
            gen.PrimeGenerated += PrintPrime;
            gen.PrimeGenerated += SumPrime;

            gen.Run(10);
            Console.WriteLine();
            Console.WriteLine(Sum);
        }

        public int AddAll(params int[] values)
        {
            int returnVal = 0;

            foreach (int value in values)
            {
                returnVal += value;
            }

            return returnVal;
        }
    }
}
