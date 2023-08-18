using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAssignment2
{
    class Operations
    {
        public Operations()
        {
            Integer = 0;
            Decimal = 0.0m;
            String = "0";
        }
        public int Operation(int num1)
        {
            //Takes an integer to the fourth power
            int newNum = num1 * num1 * num1 * num1;
            return newNum;
        }

        public int Operation(decimal num2)
        {
            //Multiplies a decimal by 4, then rounds up to the next highest integer
            decimal newNum2 = num2 + num2 + num2 + num2;
            int rounded = Convert.ToInt32(newNum2);
            int result = newNum2 > rounded ? rounded + 1 : rounded;
            return result;
        }

        public int Operation(string num3)
        {
            //Takes a string, converts it to an integer, then adds four
            int newNum3 = Convert.ToInt32(num3);
            int fourNum = newNum3 + 4;
            return fourNum;
        }

        public int Integer { get; set; }
        public decimal Decimal { get; set; }
        public string String { get; set; }


    }
}
