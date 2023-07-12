using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMethodsAssignment
{
    class Operations
    {
        public static int Square(int newNum)
        {
            int squareNum = newNum * newNum;
            return squareNum;
        }

        public static int Double(int nextNum)
        {
            int dubNum = nextNum * 2;
            return dubNum;
        }

        public static int Cube(int aNum)
        {
            int cubeNum = aNum * aNum * aNum;
            return cubeNum;
        }
        public int Operation { get; set; }
    }
}
