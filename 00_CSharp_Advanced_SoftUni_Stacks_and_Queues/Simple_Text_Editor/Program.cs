using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack  = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] param = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (param[0] == "1")
                {
                    if(stack.Count == 0) stack.Push(param[1]);
                    else
                    {
                        stack.Push(stack.Peek()+param[1]);
                    }
                }
                else if (param[0] == "2")
                {
                    int erase = int.Parse(param[1]);
                    string temp = stack.Peek();
                    
                    
                    
                    stack.Push(temp.Substring(0,temp.Length-erase));
                }
                else if (param[0]=="3")
                {
                    Console.WriteLine(stack.Peek()[Convert.ToInt32(param[1])-1]);
                }
                else if (param[0] == "4") stack.Pop();

            }
        }
    }
}
