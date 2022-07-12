using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzz : IEnumerable<string>
    {
        private List<string> items;
        private Dictionary<string, bool> rules;

        public FizzBuzz(int n, Dictionary<string, bool> _rules)
        {
            items = new List<string>();
            rules = _rules;

            for (int i = 1; i <= n; ++i)
            {
                items.Add(GetFizzBuzz(i));
            }
        }

        public string this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, GetFizzBuzz(index)); }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private string GetFizzBuzz(int n)
        {
            var ans = new List<String>();
            string str = "";

            if (n % 3 == 0 && rules["Fizz"])
            {
                ans.Add("Fizz");
            }

            if (n % 5 == 0 && rules["Buzz"])
            {
                ans.Add("Buzz");
            }

            if (n % 7 == 0 && rules["Bang"])
            {
                if (ans.Count == 2 || ans.Count == 0)
                {
                    ans.Clear();
                }

                ans.Add("Bang");
            }

            if (n % 11 == 0 && rules["Bong"])
            {
                ans.Clear();
                ans.Add("Bong");
            }

            if (n % 13 == 0 && rules["Fezz"])
            {
                ans.Add("Fezz");
                int pos = -1;

                for (int i = 0; i < ans.Count; ++i)
                {
                    if (ans[i][0] == 'B')
                    {
                        pos = i;
                        break;
                    }
                }

                if (pos != -1)
                {
                    for (int i = ans.Count - 1; i > pos; --i)
                    {
                        ans[i] = ans[i - 1];
                    }

                    ans[pos] = "Fezz";
                }
            }

            if (n % 17 == 0 && rules["Rev"])
            {
                ans.Reverse();
            }

            if (!ans.Any())
            {
                return n.ToString();
            }
            else
            {
                foreach (var word in ans)
                {
                    str += word;
                }
            }

            return str;
        }
    }

    class Program
    {
        static void OneLiner(int n)
        {
            var nums = Enumerable.Range(1, n).Select(x =>
                (x % 7 == 0)
                    ? ((x % 3 == 0) ? "FizzBang" : ((x % 5 == 0) ? "BuzzBang" : "Bang"))
                    : ((x % 3 == 0) ? ((x % 5 == 0) ? "FizzBuzz" : "Fizz") : ((x % 5 == 0) ? "Buzz" : x.ToString())));

            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
        }
        
        static void Main(string[] args)
        {
            Console.Write("Generate output up to: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, bool> rules = new Dictionary<string, bool>();
            rules.Add("Fizz", false);
            rules.Add("Buzz", false);
            rules.Add("Bang", false);
            rules.Add("Bong", false);
            rules.Add("Fezz", false);
            rules.Add("Rev", false);

            Console.Write("Write rules (e.g. 'Fizz Buzz Bong'): ");
            var words = Console.ReadLine().Split();

            foreach (var word in words)
            {
                rules[word] = true;
            }

            var fizzBuzzer = new FizzBuzz(n, rules);

            foreach (var value in fizzBuzzer)
            {
                Console.WriteLine(value);
            }

            OneLiner(100);
        }
    }
}
