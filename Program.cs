using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work___2
{

    class Program
    {
        public class TestCase
        {
            public int[] array { get; set; }
            public int numberofsearch { get; set; }
            public int Expected { get; set; }
            public Exception Error { get; set; }
        }

        static void Test(TestCase testCase)
        {
            try
            {
                Console.WriteLine("------------------");
                Console.WriteLine($"NumberOfSearch - {testCase.numberofsearch}");
                Console.WriteLine("------------------");
                var actual = BinarySearch(testCase.array, testCase.numberofsearch);
                Console.WriteLine($"Index element of array - {BinarySearch(testCase.array, testCase.numberofsearch)}");
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.Error != null)
                {

                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static int BinarySearch(int[] inputArray, int searchValue) // сложность log_2(n)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        static void PrintArray (int [] array)
        {
            for (int i=0; i< array.Length; i++)
            {
                Console.Write($"{array[i]}   ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            int[] inputArray = new int[] { 1, 32, 5, 71, 8, 22, 44, 2, 9, 5 };
            PrintArray(inputArray);
            BubbleSort(inputArray);
            PrintArray(inputArray);
            Console.WriteLine("------------------");
            Console.WriteLine($"NumberOfSearch - {32}");
            Console.WriteLine("------------------");
            Console.WriteLine($"Index element of array - {BinarySearch(inputArray, 32)}");

            var testCase1 = new TestCase()
            {
                array = inputArray,
                numberofsearch = 5,
                Expected = 2,
                Error = null
            };
            Test(testCase1);
            var testCase2 = new TestCase()
            {
                array = inputArray,
                numberofsearch = 100,
                Error = null
            };
            Test(testCase2);
            var testCase3 = new TestCase()
            {
                array = inputArray,
                numberofsearch = 1,
                Expected = 0,
                Error = null
            };
            Test(testCase3);
            var testCase4 = new TestCase()
            {
                array = inputArray,
                numberofsearch = 22,
                Expected = 6,
                Error = null
            };
            Test(testCase4);
            var testCase5 = new TestCase()
            {
                array = inputArray,
                numberofsearch = 10345,
                Error = null
            };
            Test(testCase5);
            Console.ReadKey();
        }
    }
}
