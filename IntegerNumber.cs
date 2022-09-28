using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoDeVectores
{
    class IntegerNumber
    {
        // Property
        private int number;
        // Constructor
        public IntegerNumber()
        {
            number = 0;
        }
        // Method set and get
        public void setNumber(int value)
        {
            number = value;
        }

        public int getNumber()
        {
            return number;
        }
        // Methods
        public bool isEven()
        {
            return number % 2 == 0;
        }

        public bool isMultiple(int multiple)
        {
            return number % multiple == 0;
        }

        public bool isSubMultiple()
        {
            int index = 0;
            bool result = false;
            for (index = 1; index <= number; index++)
                if (isMultiple(index)) result = true;
            return result;
        }

        public bool isPrime()
        {
            int index;
            double half = Math.Sqrt(number);
            for (index = 2; index <= half; index++)
            {
                if (number % index == 0) return false;
            }
            return number > 1;
        }

        public int reverseInteger()
        {
            int num, digit, result = 0;
            num = number;
            while (num > 0)
            {
                digit = num % 10;
                result = (result * 10) + digit;
                num = num / 10;
            }
            return result;
        }

        public bool isPalindrome()
        {
            return reverseInteger() == number;
        }

        public bool checkIfIsFibonacci(int a = 0, int b = 1)
        {
            if (number == 0 || number == 1) return true;
            int c = a + b;
            if (c == number) return true;
            else if (c > number) return false;
            return checkIfIsFibonacci(b, c);
        }

        public double getFactorial()
        {
            double result = 1;
            int index;
            if (number != 0)
            {
                for (index = Math.Abs(number); index > 1; index--)
                {
                    result = result * index;
                }
                if (number < 0) result = -result;
            }
            return result;
        }

        public bool isOrder()
        {
            int[] numArray = new int[number];
            int digit, clone = number, index = 1, numOrder = 0;
            while (clone > 0)
            {
                digit = clone % 10;
                numArray[index] = digit;
                clone = clone / 10;
                index++;
            }

            Array.Sort(numArray);
            foreach (int value in numArray)
            {
                numOrder = numOrder * 10 + value;
            }
            return number == numOrder;
        }
    }
}
