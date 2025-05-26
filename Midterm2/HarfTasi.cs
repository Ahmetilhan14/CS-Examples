using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2
{
    internal class HarfTasi
    {
        public char harf;
        public int harfPuani;
        public bool jokerMi;
      
       public override string ToString()
        {
            return jokerMi ? "Joker" : $"{harf} ({harfPuani})";
        }
    }
}
