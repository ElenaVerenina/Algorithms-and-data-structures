using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work___1
{
    class Program
    {
        static void PrintList (LinkedList List1)
        {
            Console.WriteLine("Current List");
            for (int j = 0; j < List1.GetCount(); j++)
            {
                Console.Write($"   {List1.FindNodeIndex(j).Value}");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("For Exit press Escape after operation");
            var List1 = new LinkedList();
            int iter = 0;
            List1.AddNode(2);
            List1.AddNode(6);
            List1.AddNode(8);
            List1.AddNode(5);
            PrintList(List1);
            Console.WriteLine("Выберите операцию со списком");
            Console.WriteLine("1 - GetCount, 2 - AddNode, 3 - AddNodeAfter, 4 - RemoveNode (index), 5 - RemoveNode (Value)");
            bool oper = true;
            iter = Convert.ToInt32(Console.ReadLine());
            while (oper)
            {
                try
                {
                    switch (iter)
                    {
                        case 1:
                            Console.WriteLine($"Count of List - {List1.GetCount()}");
                            break;
                        case 2:
                            Console.WriteLine("Enter Value of Node");
                            List1.AddNode(Convert.ToInt32(Console.ReadLine()));
                            PrintList(List1);
                            break;
                        case 3:
                            Console.WriteLine("Enter index of Node (index start 0)");
                            int index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Value of Node");
                            List1.AddNodeAfter(List1.FindNodeIndex(index), Convert.ToInt32(Console.ReadLine()));
                            PrintList(List1);
                            break;
                        case 4:
                            Console.WriteLine("Enter index of Node (index start 0)");
                            List1.RemoveNode(Convert.ToInt32(Console.ReadLine()));
                            PrintList(List1);
                            break;
                        case 5:
                            Console.WriteLine("Enter Value of Node");
                            List1.RemoveNode(List1.FindNode(Convert.ToInt32(Console.ReadLine())));
                            PrintList(List1);
                            break;
                    }
                    ConsoleKeyInfo key;
                    Console.WriteLine("For Enter next operation press ENTER");
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        oper = false;
                        return;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Enter next operation");
                        iter = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error argument");
                }
            }                 

        }
    }
}
