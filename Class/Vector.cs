using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoDeVectores.Class
{
    class Vector
    {
        private int number;
        private int[] arrNumbers;

        public Vector()
        {
            number = 0;
        }

        public void setData(int value)
        {
            number = value;
            arrNumbers = new int[value.ToString().Length];
        }

        public string getData()
        {
            return number.ToString();
        }
    }
}
