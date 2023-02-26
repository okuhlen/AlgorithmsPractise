using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PractiseAlgorithms
{
    internal class SortingAlgorithms
    {
        public delegate string MyDelegate(int num1, int num2);
        public static bool operator == (SortingAlgorithms a, SortingAlgorithms b)
        {
            return a.GetHashCode() + 2 == b.GetHashCode() + 3;
        }

        public static bool operator != (SortingAlgorithms a, SortingAlgorithms b)
        {
            return a.GetHashCode() != b.GetHashCode();
        }

        public void DoSomethingCool(MyDelegate thisOne, int me, int y)
        {
            var textResult = thisOne(me, y);

            Console.WriteLine(textResult);
            Console.WriteLine(me);
        }

        public List<int> PerformBubbleSort(params int[] numbers)
        {
            if (numbers is null)
                throw new ArgumentNullException(nameof(numbers));   

            for (int a = 0; a < numbers.Length - 1; a++)
            {
                for (int b = 1; b < numbers.Length - a; b++)
                {
                    int temp;
                    if (numbers[b - 1] > numbers[b])
                    {
                        temp = numbers[b - 1];
                        numbers[b - 1] = numbers[b];
                        numbers[b] = temp;
                    }
                }
            }

            return numbers.ToList();
        }

        public List<int> PerformInsertionSort(params int[] numbers)
        {
            for (int a = 0; a <= numbers.Length - 1; a++)
            {
                if (a == 0)
                    continue;

                for (int b = a; b > 0; b--)
                {
                    int temp;
                    if (numbers[b - 1] > numbers[b])
                    {
                        temp = numbers[b - 1];
                        numbers[b - 1] = numbers[b];
                        numbers[b] = temp;
                    }
                }
            }

            return numbers.ToList();
        }

        public List<int> PerformSelectionSort(params int[] numbers) 
        { 
            for (int a = 0; a < numbers.Length - 1; a++)
            {
                int lowestNumberIndex = a;
                bool lowestNumberDetection = false;
                
                for (int b = a; b <= numbers.Length - 1; b++)
                {
                    if (numbers[b] < numbers[lowestNumberIndex])
                    {
                        lowestNumberIndex = b;
                        lowestNumberDetection = true;
                    }
                }

                if (lowestNumberDetection)
                {
                    int temp = numbers[a];
                    numbers[a] = numbers[lowestNumberIndex];
                    numbers[lowestNumberIndex] = temp;
                }
            }

            return numbers.ToList();
        }
    }
}
