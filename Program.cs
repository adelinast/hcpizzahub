using System;
using System.Collections.Generic;
using System.IO;

namespace HashCodePracticePizzaHUb
{
    class Program
    {
        private static List<int> CalcMax(int[] slices, int start, int N)
        {
            List<int> maxSlices = new List<int>();

            if (start<=0)
            {
                return null;
            }
            if (start==0)
            {
                return maxSlices;
            }
            for (int i = N-1; i>=0; i--)
            {
                maxSlices = CalcMax(slices, start - slices[i], i);
                if (maxSlices != null)
                {
                    maxSlices.Add(i);
                    return maxSlices;
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            string inputLine1 = "";
            string inputLine2 = "";
            int count = 0;
            if (args.Length != 1)
            {
                Console.WriteLine("<arg0> is the input filename");
                return;
            }
            using (StreamReader sr = new StreamReader(args[0]))
            {
                while (sr.Peek() >= 0)
                {
                    if (count == 0)
                    {
                        inputLine1 = sr.ReadLine();
                    }
                    else
                    {
                        inputLine2 = sr.ReadLine();
                    }
                    count++;
                }
            }
            string[] pizzaStr = inputLine1.Split(' ');
            string[] pizzaSlicesStr = inputLine2.Split(' ');

            int M = Convert.ToInt32(pizzaStr[0]);
            int N = Convert.ToInt32(pizzaStr[1]);//pizza types
            int[] slices = new int[N];
            for (int i = 0; i < N; i++)
            {
                slices[i] = Convert.ToInt32(pizzaSlicesStr[i]);
            }
            List<int> maxslices= CalcMax(slices, M, N);
            string path = args[0] + ".out";
            using (StreamWriter w = File.CreateText(path))
            {
                w.WriteLine(maxslices.Count);
                foreach (int number in maxslices)
                {
                    w.Write(number+" ");
                }
                w.WriteLine();
            }
        }
    }
}
