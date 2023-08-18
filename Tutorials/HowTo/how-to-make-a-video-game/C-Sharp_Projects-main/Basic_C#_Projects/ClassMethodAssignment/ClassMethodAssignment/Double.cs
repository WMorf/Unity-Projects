using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodAssignment
{
    public static class Double
    {
        public static void Dub(int var2, out int varDouble)
        {
            varDouble = var2 * 2;
        }

        public static void Dub(decimal var3, out decimal varDubDec)
        {
            varDubDec = var3 * 2;
        }
    }
}
