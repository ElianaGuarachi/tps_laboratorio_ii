using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensiones
    {
        public static int GetRandom(this Random value, int hasta)
        {
            return value.Next(1000, hasta);
        }
    }
}
