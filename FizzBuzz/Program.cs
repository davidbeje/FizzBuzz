using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; ++i)
            {
                var ans = new List<String>();

                if (i % 3 == 0)
                {
                    ans.Add("Fizz");
                }

                if (i % 5 == 0)
                {
                    ans.Add("Buzz");
                }

                if (i % 7 == 0)
                {
                    if (ans.Count == 2 || ans.Count == 0)
                    {
                        ans.Clear();
                    }

                    ans.Add("Bang");
                }

                if (i % 11 == 0)
                {
                    ans.Clear();
                    ans.Add("Bong");
                }

                if (i % 13 == 0)
                {
                    ans.Add("Fezz");
                    int pos = 0;

                    for (int j = 0; j < ans.Count; ++j)
                    {
                        if (ans[j][0] == 'B')
                        {
                            pos = j;
                            break;
                        }
                    }

                    if (pos != ans.Count)
                    {
                        for (int j = ans.Count - 1; j > pos; --j)
                        {
                            ans[j] = ans[j - 1];
                        }

                        ans[pos] = "Fezz";
                    }
                }

                if (i % 17 == 0)
                {
                    ans.Reverse();
                }

                foreach (var)
            }
        }
    }
}
