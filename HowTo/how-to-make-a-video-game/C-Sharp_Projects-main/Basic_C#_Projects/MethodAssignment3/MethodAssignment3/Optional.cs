using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAssignment3
{
    class Optional
    {
        public int Squared(int var1, int scalar = 1)
        {
            int result = scalar * (var1 * var1);
            return result;
        }
    }
}
