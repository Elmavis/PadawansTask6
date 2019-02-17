using System;
using System.Collections.Generic;

namespace PadawansTask6
{
    public class Sorter : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
    public static class NumberFinder
    {
        private static int NumFromDigits(List<int> numArr)
        {
            int newDigit = 0;
            for (int j = 0; j < numArr.Count; j++)
                newDigit += numArr[j] * (int)Math.Pow(10, numArr.Count - 1 - j);

            return newDigit;
        }

        public static int? NextBiggerThan(int number)
        {
            List<int> numArr = new List<int>();

            do
            {
                int elem = number % 10;
                number /= 10;
                numArr.Add(elem);
            } while (number != 0);

            //количество цифр, которые я буду сравнивать между собой
            for (int k = 1; k < numArr.Count; k++)
            {
                //индекс того, с которым сравниваю
                for (int i = 0; i < k; i++)
                {
                    //индекс сравниваемого
                    for (int j = i; j - 1 < k; j++)
                    {
                        if (numArr[j] < numArr[i])
                        {
                            int temp = numArr[i];
                            numArr[i] = numArr[j];
                            numArr[j] = temp;
                            numArr.Sort(0, j, new Sorter());
                            numArr.Reverse();
                            int newDigit = NumFromDigits(numArr);

                            return newDigit;
                        }
                    }

                }
            }

            return null;
        }
    }
    /*
     * for(колво цифр влево)
     * for(иду по массиву от 0 до колва цифр влево (i))
     * for(иду по массиву от i до колва цифр влево (j))
     * {
     *     if(j-ый меньше i-ого)
     *     {
     *         меняю местами
     *         сорчу всё правее i-го
     *         составляю число из массива
     *         return
     *     }
     * }
     * 
     * 
     * 
     */
}