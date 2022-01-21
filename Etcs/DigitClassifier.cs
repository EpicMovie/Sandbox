using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class DigitClassifier
{
    public static int digit = 4;

    // Make Rule
    private static readonly int NUM_OF_ALPHABET = 26;
    private static readonly int A_ASCII = 65;

    public static bool IsDigitsOnly(string str)
    {
        return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
    }

    public void TestWrite(int length)
    {
        using (FileStream fs = new FileStream("TestResult.txt", FileMode.OpenOrCreate))
        {
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            StringBuilder sb = new StringBuilder();
            sb.Capacity = length;

            for (int i = 1; i <= length; i++)
            {
                sb.Append(i % 10);
                sw.WriteLine(GetDigit(sb.ToString()));
            }

            sw.Flush();
        }
    }

    public void Test(string val)
    {
        Console.WriteLine(GetDigit(val));
    }

    public string GetDigit(string val)
    {
        if (val.Length < digit)
        {
            return val;
        }
        else
        {
            string prefix = "";

            for(int i = 0; i < Math.Min(val.Length, digit); i++)
            {
                prefix += val[i];
            }

            return prefix.ToString() + GetAlphabetPrefix(val.Length / digit);
        }
    }

    private string GetAlphabetPrefix(int length)
    {
        StringBuilder sb = new StringBuilder();
        sb.Clear();

        int l = length;
        int i = -1;

        while (l > 0)
        {
            l /= NUM_OF_ALPHABET;
            i++;
        }

        // 첫 Prefix가 B되는 것만 해결하면 되는데 ... 
        while (i >= 0)
        {
            if (i == 0)
            {
                sb.Append((char)(length % NUM_OF_ALPHABET + A_ASCII));
                i--;
            }
            else
            {
                int pow = (int)Math.Pow(NUM_OF_ALPHABET, i--);
                sb.Append((char)(length / pow + A_ASCII));

                length %= pow;
            }
        }

        return sb.ToString();
    }
}
