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

        public void setData2(int value, int min, int max)
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
            string strPrimes = "", strNoPrimes = "";
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
            return "R1: V{" + strPrimes + "} 'Primos'     R2: V{ " + strNoPrimes + "} 'No Primos'";
        }

        public void investNumberInRange(int min, int max)
        {
            int index, a = max - 1;
            int[] arrClone = arrNumbers;

            for (index = 0; index < number; index++)
            {
                if (index >= min - 1 && index <= max + 1)
                {
                    arrNumbers[index] = arrClone[a];
                    a--;
                }
            }
        }

        private bool isEqual(int num, int index)
        {
            bool result = false;
            int i;
            for (i = index; i < number; i++)
                if ((arrNumbers[i] == num) && (index != i)) result = true;
            return result;
        }

        public bool IsUnique()
        {
            int index;
            bool result = true;
            int[] arrClone = arrNumbers;

            for (index = 0; index < number; index++)
            {
                if (isEqual(arrNumbers[index], index)) result = false;
            }
            return result;
        }

        private bool isEqualIntersection(int num, int index, ref Vector ObjVector3)
        {
            bool result = false;
            int i;
            for (i = 0; i < ObjVector3.arrNumbers.Length; i++)
                if ((num == ObjVector3.arrNumbers[i]))
                    result = true;
            return result;
        }

        public string FindOfIntersection(ref Vector objVector3)
        {
            string result = "";
            int index, c = 0;
            int[] intersection = new int[number];
            for (index = 0; index < number; index++)
            {
                if (isEqualIntersection(arrNumbers[index], index, ref objVector3))
                {
                    foreach (int item in intersection)
                    {
                        if ((item != arrNumbers[index]) && (intersection.Length < 0))
                        {
                            intersection[c] = arrNumbers[index];
                            c++;
                        }
                    }
                    result = result + arrNumbers[index].ToString() + ", ";
                }
            }
            if (result == "") result = " No hay intersección ";
            return "V{" + result + "}";
        }

        public string FindTheUnion(ref Vector objVector3)
        {
            return "V{" + string.Join(",", arrNumbers.Union(objVector3.arrNumbers).Where(x => x >= 0)) + "}";
        }

        public bool IsOrderInSegment(int a, int b, ref Vector objResult)
        {
            bool isOrder = false, pass = true;
            int index;
            a = a >= 1 ? a - 1 : 0; b = b >= 1 ? b - 1 : 0;
            for (index = 0; index < number; index++)
            {
                if ((index < number) && (index >= a && index < b) && pass)
                {
                    if (arrNumbers[index] <= arrNumbers[index + 1])
                        isOrder = true;
                    else
                    {
                        isOrder = false;
                        pass = false;
                    }
                }
            }
            return isOrder;
        }

        public string RemoveNoPrimes()
        {
            string result = "";
            int index;
            IntegerNumber objInteger = new IntegerNumber();
            int[] newArray = new int[number];
            for (index = 0; index < number; index++)
            {
                objInteger.setNumber(arrNumbers[index]);
                if (objInteger.isPrime())
                {
                    result = result + arrNumbers[index].ToString() + ",";
                }
            }
            return "v{" + result + "}";
        }

        public void orderElementsWithMultiple(int m)
        {
            int index, j, count = 0;
            List<int> orderEle = new List<int>();
            IntegerNumber objInteger = new IntegerNumber();
            for (index = 0; index < number; index++)
            {
                if (index + 1 > 1)
                {
                    objInteger.setNumber(index + 1);
                    if (objInteger.isMultiple(m))
                        orderEle.Add(arrNumbers[index]);
                }
            }

            orderEle.Sort();
            for (j = 0; j < number; j++)
            {
                if (j + 1 > 1)
                {
                    objInteger.setNumber(j + 1);
                    if (objInteger.isMultiple(m))
                    {
                        arrNumbers[j] = orderEle[count];
                        count++;
                    }
                }
            }
        }

        public void OrderInternalSpiral()
        {
            int index = 0, countEven = 0, countOdd = 0;
            List<int> even = new List<int>(); List<int> odd = new List<int>();
            IntegerNumber objInteger = new IntegerNumber();
            for (index = 0; index < number; index++)
            {
                objInteger.setNumber(arrNumbers[index]);
                if (objInteger.isEven())
                    even.Add(arrNumbers[index]);
                else
                    odd.Add(arrNumbers[index]);
            }
            even.Sort(); even.Reverse(); odd.Sort();
            for (index = 0; index < number; index++)
            {
                if ((index + 1) <= odd.Count)
                {
                    arrNumbers[index] = odd[countOdd];
                    countOdd++;
                }
                else
                {
                    arrNumbers[index] = even[countEven];
                    countEven++;
                }
            }
        }

        public int CountDifferentItems(int a, int b)
        {
            int index;
            List<int> differentEle = new List<int>();
            a = a >= 1 ? a - 1 : 0; b = b >= 1 ? b - 1 : 0;
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    bool isExist = differentEle.IndexOf(arrNumbers[index]) != -1;
                    if (!isExist)
                        differentEle.Add(arrNumbers[index]);
                }
            }
            return differentEle.Count;
        }

        public string LeastRepeatedElement(int a, int b)
        {
            int index, index2, count = 0;
            a = a >= 1 ? a - 1 : 0; b = b >= 1 ? b - 1 : 0;
            List<int> repeatedItems = new List<int>();
            List<int> uniqueItems = new List<int>();
            List<int> countItems = new List<int>();
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    bool isExist = uniqueItems.IndexOf(arrNumbers[index]) != -1;
                    if (!isExist) uniqueItems.Add(arrNumbers[index]);
                    repeatedItems.Add(arrNumbers[index]);
                }
            }
            repeatedItems.Sort();
            for (index = 0; index < uniqueItems.Count; index++)
            {
                for (index2 = 0; index2 < repeatedItems.Count; index2++)
                    if (uniqueItems[index] == repeatedItems[index2]) count++;
                countItems.Add(count);
                count = 0;
            }
            return $"Elementos = {uniqueItems.Count}, Frecuencia = {countItems.Min()}";
        }

        public string DistributionFrequency(int a, int b)
        {
            int index, index2, count = 0;
            a = a >= 1 ? a - 1 : 0; b = b >= 1 ? b - 1 : 0;
            List<int> uniqueItems = new List<int>();
            List<int> repeatsItems = new List<int>();
            List<int> countItems = new List<int>();
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    bool isExist = uniqueItems.IndexOf(arrNumbers[index]) != -1;
                    if (!isExist) uniqueItems.Add(arrNumbers[index]);
                    repeatsItems.Add(arrNumbers[index]);
                }
            }
            uniqueItems.Sort();
            for (index = 0; index < uniqueItems.Count; index++)
            {
                for (index2 = 0; index2 < repeatsItems.Count; index2++)
                    if (uniqueItems[index] == repeatsItems[index2])
                        count++;
                countItems.Add(count);
                count = 0;
            }
            return "Elem{ " + "V={" + string.Join(", ", uniqueItems) + "} }  -  Frec{ " + "V={" + string.Join(", ", countItems) + "} }";
        }

        public string ElementFrecuenceOnFibonacci()
        {
            int index, index2, count = 0;
            IntegerNumber objInteger = new IntegerNumber();
            List<int> elementsFibo = new List<int>();
            List<int> countItems = new List<int>();
            for (index = 0; index < number; index++)
            {
                objInteger.setNumber(arrNumbers[index]);
                if (objInteger.checkIfIsFibonacci())
                {
                    bool isExist = elementsFibo.IndexOf(arrNumbers[index]) != -1;
                    if (!isExist) elementsFibo.Add(arrNumbers[index]);
                }
            }
            elementsFibo.Sort();
            for (index = 0; index < elementsFibo.Count; index++)
            {
                for (index2 = 0; index2 < number; index2++)
                    if (elementsFibo[index] == arrNumbers[index2])
                        count++;
                countItems.Add(count);
                count = 0;
            }
            return "Elem{ " + "V={" + string.Join(", ", elementsFibo) + "} }  -  Frec{ " + "V={" + string.Join(", ", countItems) + "} }";
        }

        public void SegmentPrimesAndNonPrimes(int a, int b, ref Vector objResult)
        {
            int index, index2 = 0, index3 = 0;
            a = a >= 1 ? a - 1 : 0; b = b >= 1 ? b - 1 : 0;
            IntegerNumber objInteger = new IntegerNumber();
            objResult.number = number;
            objResult.arrNumbers = new int[number];
            objResult.arrNumbers = arrNumbers;
            List<int> primes = new List<int>();
            List<int> noPrimes = new List<int>();
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    objInteger.setNumber(arrNumbers[index]);
                    if (objInteger.isPrime())
                        primes.Add(arrNumbers[index]);
                    else
                        noPrimes.Add(arrNumbers[index]);
                }
            }
            primes.Sort(); primes.Reverse(); noPrimes.Sort(); noPrimes.Reverse();
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    if (index2 < primes.Count)
                    {
                        objResult.arrNumbers[index] = primes[index2];
                        index2++;
                    }
                    else
                    {
                        objResult.arrNumbers[index] = noPrimes[index3];
                        index3++;
                    }
                }
            }
        }

        public void SegmentPalindrome(ref Vector vectorResult)
        {
            int index, index2 = 0, index3 = 0;
            IntegerNumber objInteger = new IntegerNumber();
            vectorResult.number = number;
            vectorResult.arrNumbers = new int[number];
            List<int> palindrome = new List<int>();
            List<int> noPalindrome = new List<int>();
            for (index = 0; index < number; index++)
            {
                objInteger.setNumber(arrNumbers[index]);
                if (objInteger.isPalindrome())
                    palindrome.Add(arrNumbers[index]);
                else
                    noPalindrome.Add(arrNumbers[index]);
            }
            palindrome.Sort(); noPalindrome.Sort(); noPalindrome.Reverse();
            for (index = 0; index < number; index++)
            {
                if (index < palindrome.Count)
                {
                    vectorResult.arrNumbers[index] = palindrome[index2];
                    index2++;
                }
                else
                {
                    vectorResult.arrNumbers[index] = noPalindrome[index3];
                    index3++;
                }
            }
        }

        public void interleavePrimes(int a, int b, ref Vector vectorResult)
        {
            int index, index2 = 0, index3 = 0;
            bool pinpon = true;
            a = a >= 1 ? a - 1 : 0; b = b >= 1 ? b - 1 : 0;
            IntegerNumber objInteger = new IntegerNumber();
            vectorResult.number = number;
            vectorResult.arrNumbers = new int[number];
            vectorResult.arrNumbers = arrNumbers;
            List<int> primes = new List<int>();
            List<int> noPrimes = new List<int>();
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    objInteger.setNumber(arrNumbers[index]);
                    if (objInteger.isPrime())
                        primes.Add(arrNumbers[index]);
                    else
                        noPrimes.Add(arrNumbers[index]);
                }
            }
            primes.Sort(); noPrimes.Sort();
            for (index = 0; index < number; index++)
            {
                if (index >= a && index <= b)
                {
                    if (pinpon)
                    {
                        vectorResult.arrNumbers[index] = primes[index2];
                        Console.WriteLine(index2);
                        index2++;
                        if (index3 < noPrimes.Count)
                            pinpon = false;
                    }
                    else
                    {
                        vectorResult.arrNumbers[index] = noPrimes[index3];
                        Console.WriteLine(index3);
                        index3++;
                        if (index2 < primes.Count)
                            pinpon = true;
                    }
                }
            }
        }
    }
}
