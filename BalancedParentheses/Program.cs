using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var text1 = "a(b[c(({[d][][(())]}))])"; // true
            var text2 = "asa[34da]{sasa[(are{v})]}asa[]"; // true
            var text3 = "a(b[c(({[d][][(())}))])"; // false
            var text4 = "[]"; // true
            var text5 = "a)12{asa]"; // false
            Console.WriteLine(CheckBalance(text1));
            Console.WriteLine(CheckBalance(text2));
            Console.WriteLine(CheckBalance(text3));
            Console.WriteLine(CheckBalance(text4));
            Console.WriteLine(CheckBalance(text5));
            Console.ReadLine();
        }

        static bool CheckBalance(string text)
        {
            var parenthesis = new Dictionary<char, char>()
            {
                { '(', ')'},
                { '[', ']' },
                { '{', '}' }
            };
            var stack = new Stack<char>();
            bool isBalanced = true;
            char element;
            int i = 0;
            while (i < text.Length && isBalanced)
            {
                if (parenthesis.ContainsKey(text[i])) // it's a left parenthesis
                    stack.Push(text[i]); // add left parenthesis to stack
                else
                {
                    if (parenthesis.ContainsValue(text[i])) // it's a right parenthesis
                    {
                        if (!stack.Any())
                            isBalanced = false; // it's a left parenthesis without a pair
                        else
                        {
                            element = stack.Pop(); // get the latest paranthesis added to the stack
                            isBalanced = parenthesis.Contains(new KeyValuePair<char, char>(element, text[i]));
                        }
                    }
                }
                i++;
            }

            return isBalanced;
        }
    }
}
