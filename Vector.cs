using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoDeVectores
{
    class Vector
    {
        private int number;
        private int[] arrNumbers;

        public Vector()
        {
            number = 0;
        }

        public int showNumber()
        {
            return number;
        }

        public void setDataManually(int amount, int numBase)
        {
            number = amount;
            arrNumbers = new int[amount];
            int index;
            for (index = 0; index < amount; index++)
            {
                double result = Math.Pow(numBase, index);
                arrNumbers[index] = Convert.ToInt32(result);
            }
        }

        public void setData(int value, int min, int max)
        {
            number = value;
            arrNumbers = new int[value];
            Random numRandom = new Random();
            int index;
            for (index = 0; index < value; index++)
                arrNumbers[index] = numRandom.Next(min, max);
        }

        public string getData()
        {
            string result = "";
            int index, arrLength = arrNumbers.Length;
            for (index = 0; index < arrLength; index++)
                if (index == arrLength - 1) result = result + arrNumbers[index];
                else result = result + arrNumbers[index] + ", ";
            return "V{" + result + "}";
        }

        public string getArrNumber(int amount, int numBase)
        {
            string result = "";
            int index;
            for (index = 0; index < amount; index++)
            {
                result = result + $"{numBase}^{index};   ";
            }
            return result + "...";
        }

        public string accumulateElements()
        {
            string result = "";
            int arrLength = arrNumbers.Length, index, a = -1, b = 1, c = 0;
            bool flag = true;
            for (index = 0; index < arrLength; index++)
            {
                c = a + b;
                if (index == arrLength - 1)
                    result = result + $"{arrNumbers[index]}/{c}";
                else
                {
                    if (flag) result = result + $"{arrNumbers[index]}/{c} - ";
                    else result = result + $"{arrNumbers[index]}/{c} + ";
                }
                flag = !flag;
                a = b;
                b = c;
            }

            return "F = " + result;
        }

        // TODO: Should count the submultiples
        public int countSubMultiples()
        {
            IntegerNumber objInteger = new IntegerNumber();
            int index, count = 0;
            int arrLength = arrNumbers.Length;
            for (index = 1; index < number; index++)
            {
                objInteger.setNumber(index);
                if (objInteger.isMultiple(arrNumbers[index - 1]))
                {
                    count++;
                }
            }
            return count;
        }

        public double findTheMean(int initialValue = 5, int reason = 3)
        {
            int index = 1, magic = 0;
            double result = 0.0;
            while (magic < number)
            {
                magic = initialValue + (index - 1) * reason;
                result = result + arrNumbers[magic - 1];
                index++;
            }
            return result / (index - 1);
        }

        public string selectPrimesAndNotPrimes()
        {
            IntegerNumber objInteger = new IntegerNumber();
            string result = "", strPrimes = "", strNoPrimes = "";
            int index, indexP = 0, indexNP = 0;
            int[] primes = new int[number];
            int[] noPrimes = new int[number];
            for (index = 0; index < number; index++)
            {
                objInteger.setNumber(arrNumbers[index]);
                if (objInteger.isPrime())
                {
                    primes[indexP] = arrNumbers[index];
                    strPrimes = strPrimes + arrNumbers[index] + ",";
                    indexP++;
                }
                else
                {
                    primes[indexNP] = arrNumbers[index];
                    strNoPrimes = strNoPrimes + arrNumbers[index] + ",";
                    indexNP++;
                }
            }
            return "R1: V{" + strPrimes + "}  R2: V{ "+ strNoPrimes + "}";
        }

        public void investNumberInRange()
        {
            int index, a = 2, b = 7;
            int[] newArr = new int[number];
            
            for (index = 0; index < number; index++)
            {
                if (index >= 1 && index <= 7)
                {
                    arrNumbers[b] = arrNumbers[index];
                        b--;
                }
            }
        }

    }
}
