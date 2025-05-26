using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Midterm2
{
    internal class Sozluk
    {
        private List<string> kelimeler=new List<string>();
        public void kelimeYukle(string kelime)
        {
            kelimeler.Add(kelime);
        }
        public void kelimeOlustur(string kelime)
        {
            if (!string.IsNullOrWhiteSpace(kelime)&&!kelimeler.Contains(kelime))
            {
                kelimeler.Add(kelime.Trim().ToLower()); 
            }
        }
        public bool kelimeVarmi(string kelime) 
        {
            return kelimeler.Contains(kelime.Trim().ToLower());
        }
    }
}
