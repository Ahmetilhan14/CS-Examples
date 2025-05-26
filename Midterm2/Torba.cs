using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2
{
    internal class Torba
    {
        private List<HarfTasi> taslar = new List<HarfTasi>();
        private Random rnd = new Random();
        public void doldur() 
        {
            var harfler = new Dictionary<char, (int adet, int puan)>
            {
                 {'A',(12,1)}, {'B',(2,3)}, {'C',(2,4)}, {'Ç',(2,4)}, {'D',(2,3)}, {'E',(8,1)},
            {'F',(1,7)}, {'G',(1,5)}, {'Ğ',(1,8)}, {'H',(1,5)}, {'I',(4,2)}, {'İ',(7,1)},
            {'J',(1,10)},{'K',(7,1)}, {'L',(7,1)}, {'M',(4,2)}, {'N',(5,1)}, {'O',(3,2)},
            {'Ö',(1,7)}, {'P',(1,5)}, {'R',(6,1)}, {'S',(3,2)}, {'Ş',(2,4)}, {'T',(5,1)},
            {'U',(3,2)}, {'Ü',(2,3)}, {'V',(1,7)}, {'Y',(2,3)}, {'Z',(2,4)}
            };

            foreach (var kvp in harfler)
            {
                for(int i = 0; i < kvp.Value.adet; i++)
                {
                    HarfTasi t=new HarfTasi();
                    t.harf = kvp.Key;
                    t.harfPuani=kvp.Value.puan;
                    t.jokerMi = false;
                    taslar.Add(t);
                }
            }
            
            for(int i = 0; i < 2; i++)
            {
                HarfTasi joker = new HarfTasi();
                joker.harf = '*';
                joker.harfPuani = 0;
                joker.jokerMi = true;
                taslar.Add(joker);
            }
        }
        public void karistir() {
            taslar= taslar.OrderBy(X=>rnd.Next()).ToList();
        }
        public HarfTasi harfCek()
        {
            if (taslar.Count == 0) return null;
            var harf = taslar[0];
            taslar.RemoveAt(0);
            return harf;
        }
        public bool bosMu() { return taslar.Count == 0; }

        public List<HarfTasi> TaslariGetir()
        {
            return taslar;
        }
    }
}
