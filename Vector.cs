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
            int[] arrTest = {0, 3, 1, 9, 5, 12, 12, 6, 7 };
            // int arrLength = arrNumbers.Length;
            for (index = 1; index < 8; index++)
            {
                objInteger.setNumber(index);
                if (objInteger.isMultiple(arrNumbers[index]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
