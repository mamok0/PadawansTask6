using System;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (Math.Abs(number) / 10 == 0)
                return null;
            if (number == int.MaxValue)
                throw new OverflowException();
            int powerOfDivisor = 1;
            int divisor = 10;
            while (number % divisor != number)
            {
                divisor *= 10;
                powerOfDivisor++;
            }

            int[] digits = new int[powerOfDivisor];
            int bufNum = number;
            for (int i = powerOfDivisor - 1; i >= 0; i--)
            {
                digits[i] = bufNum % 10;
                bufNum /= 10;
            }
            int num = getNearNumber(digits);
            if (num == number)
                return null;
            return num;
        }

        public static int getNearNumber(int[] digits)
        {
            int number = 0;
            int[] comparsionalArr = digits;
            for (int i = digits.Length - 1; i > 0; i--)
            {
                int[] bufarr = digits;
                int bufDigit = bufarr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if(bufarr[i] > bufarr[j])
                    {
                        bufarr[i] = bufarr[j];
                        bufarr[j] = bufDigit;
                        break;
                    } 
                }
                bool isSuccessfull = false;
                for (int k = 0; k < digits.Length; k++)
                {
                    if (digits[k] <= bufarr[k])
                    {
                        comparsionalArr = bufarr;
                        isSuccessfull = true;
                    }
                }
                if (isSuccessfull)
                    break;
            }
            for (int i=comparsionalArr.Length-1, k=1; i>=0; i--, k*=10 )
            {
                number += comparsionalArr[i] * k;
            }
            return number;
        }
    }
}
