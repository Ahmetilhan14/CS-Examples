using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Midterm2
{
    internal class Oyuncu
    {
        public string name;
        public int age ;
        public int point ;  
        public List<HarfTasi> taslar =new List<HarfTasi>();
        public void tasEkle(HarfTasi tas) 
        {
            if (taslar.Count < 7)
            {
                taslar.Add(tas);
            }
        }
        public HarfTasi tasCikar(char harf) 
        {
            harf = char.ToUpper(harf);
            var tas=taslar.FirstOrDefault(T=>T.harf==harf);

            if (tas != null)
            {
                taslar.Remove(tas);
                return tas;
            }
            
            tas = taslar.FirstOrDefault(T => T.jokerMi);

            if (tas != null)
            {
                taslar.Remove(tas);
                
                tas.harf = harf;
                return tas;
            }

            return null;
        }


        public bool girilenHarflereSahipmi(string kelime)
        {
            var gecici = new List<HarfTasi>(taslar);
            foreach (char h in kelime.ToUpper())
            {
                var harf = gecici.FirstOrDefault(T => T.harf == h);
                if (harf != null) {
                    gecici.Remove(harf);
                }
                else
                {
                    harf = gecici.FirstOrDefault(T => T.jokerMi);
                    if (harf != null)
                    {
                        gecici.Remove(harf);
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            } 
            return true;
        }
        public void taslariniYaz()
        {
            Console.WriteLine($"{name} taşları: {string.Join(", ", taslar.Select(T=>T.harf))}");
        }

        
        public void puanlariGuncelle(int skor) {
            point += skor;
        }
        public bool tasBittimi() 
        {
            return taslar.Count ==0;
        }
    }
}
