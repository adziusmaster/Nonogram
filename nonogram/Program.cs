using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This challenge is inspired by nonogram puzzles, 
//but you don't need to be familiar with these puzzles in order to complete the challenge.

//A binary array is an array consisting of only the values 0 and 1. 
//Given a binary array of any length, return an array of positive integers that represent the lengths of the sets of consecutive 
//1's in the input array, in order from left to right.

//nonogramrow([]) => []
//nonogramrow([0,0,0,0,0]) => []
//nonogramrow([1, 1, 1, 1, 1]) => [5]
//nonogramrow([0,1,1,1,1,1,0,1,1,1,1]) => [5, 4]
//nonogramrow([1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0]) => [2,1,3]
//nonogramrow([0,0,0,0,1,1,0,0,1,0,1,1,1]) => [2, 1, 3]
//nonogramrow([1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1]) => [1,1,1,1,1,1,1,1]
//As a special case, nonogram puzzles usually represent the empty output ([]) as [0]. 
//If you prefer to do it this way, that's fine, but 0 should not appear in the output in any other case.

namespace nonogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] emptyArray = ArrayPass();
            int[] binaryArray = ArrayCreator(emptyArray);
            int[] finalArray = ArrayCalculator(binaryArray);

            Console.WriteLine("######### binary array #########");
            foreach (int i in binaryArray)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\n");
            Console.WriteLine("######### result array #########");
            foreach (int i in finalArray)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadLine();
        }
        static int[] ArrayPass()
        {
            bool checker = false;
            int arrayLength = 0;
            Console.WriteLine("######### Create an array #########");
            Console.WriteLine("How many elements do you want in your array?");
            while (!checker)
            {
                string input = Console.ReadLine();
                checker = int.TryParse(input, out arrayLength);
                if (!checker) Console.WriteLine("That is not a number");
            }
            int[] emptyArray = new int[arrayLength];
            return emptyArray;
        }
        static int[] ArrayCreator(int[] emptyArray)
        {
            for (int i = 0; i < emptyArray.Length; i++)
            {
                Console.WriteLine("Pass '0' or '1' to create a binary array");
                Console.WriteLine($"Pass {i + 1} of {emptyArray.Length} element of your array");
                bool checker = false;
                while (!checker)
                {
                    string input = Console.ReadLine();
                    checker = (input == "0" || input == "1");
                    if (!checker) Console.WriteLine("That is not '0' or '1'");
                    else emptyArray[i] = int.Parse(input);
                }
            }
            return emptyArray;
        }
        static int[] ArrayCalculator(int[] binaryArray)
        {
            List<string> finalList = new List<string>();
            int counter = 0;
            int i = 0;
            while (i < binaryArray.Length)
            {
                if (binaryArray[i] == 0)
                {
                    i++;
                }
                while (i<binaryArray.Length && binaryArray[i] == 1)
                {
                    counter++;
                    i++;                                                          
                }
                if (counter != 0)
                {
                    finalList.Add(counter.ToString());
                    counter = 0;
                }
        }
            int[] finalArray = new int[finalList.Count];
            for (int j = 0; j < finalList.Count; j++)
            {
                finalArray[j] = int.Parse(finalList[j]);
            }
            return finalArray;
        }
    }
}