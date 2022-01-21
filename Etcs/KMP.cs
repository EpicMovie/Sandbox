using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://bowbowbow.tistory.com/6
// Suffix와 Prefix의 매칭을 통해서 비교를 하는 것은 이해가 갔으나 코드의 정확한 로직은 이해가 아직 안됨
public class KMP
{
    public static void Test()
    {
        string main = "ABAABA";
        string sub = "AB";

        var result = KMP.Run(main, sub);

        foreach (int i in result)
        {
            Console.Write(i);
        }
    }

    // Get array of index that matches between Prefix and Suffix 
    public static int[] GetPi(string p)
    {
        int[] m = new int[p.Length];
        int j = 0;

        for (int i = 1; i < p.Length; i++)
        {
            // 연속적으로 일치하기 때문에 이전에 일치했던 값을 가져와서 그대로 매칭을 해버리네
            while (j > 0 && p[i] != p[j])
            {
                j = m[j - 1]; 
            }

            if (p[i] == p[j])
            {
                m[i] = ++j;
            }
        }

        return m;
    }

    public static List<int> Run(string mainStr, string subStr)
    {
        List<int> matches = new List<int>();

        int[] pi = GetPi(subStr);

        int j = 0;

        for (int i = 0; i< mainStr.Length; i++)
        {
            while (j > 0 && mainStr[i] != subStr[j])
            {
                j = pi[j - 1];
            }

            if(mainStr[i] == subStr[j])
            {
                if (j == subStr.Length - 1)
                {
                    matches.Add(i - subStr.Length + 1);
                    j = pi[j];
                }
                else
                {
                    j++;
                }
            }
        }

        return matches;
    }
}
