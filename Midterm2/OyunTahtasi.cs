using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2
{
    internal class OyunTahtasi
    {
        public string[,] tablo = new string[15, 15]
        {
        {"", "", "", "K3", "", "", "H2", "", "", "", "K1", "", "", "", ""},
        {"", "H3", "", "", "", "H2", "", "", "", "", "", "", "", "", ""},
        {"", "K3", "", "", "", "", "H2", "", "", "", "", "", "", "", ""},
        {"", "", "", "K2", "", "", "", "", "", "", "", "K3", "", "", ""},
        {"", "", "H3", "", "", "", "", "", "", "", "", "", "", "", ""},
        {"H2", "", "", "H2", "", "", "", "", "", "", "", "", "", "", ""},
        {"", "H2", "", "", "", "", "", "", "", "", "", "", "", "", ""},
        {"", "", "K2", "", "", "", "", "", "", "", "", "", "", "", ""},
        {"", "H2", "", "", "H2", "", "", "", "", "", "", "", "", "", ""},
        {"", "H2", "", "", "H2", "", "", "", "", "", "", "H2", "", "", ""},
        {"", "", "", "H3", "", "", "", "", "", "", "", "", "", "", ""},
        {"", "", "K2", "", "", "", "", "", "", "", "", "", "", "", ""},
        {"K3", "", "", "", "", "", "", "", "", "", "", "", "", "", "K3"},
        {"", "H3", "", "", "H2", "", "", "", "", "", "", "", "", "", ""},
        {"", "", "K3", "", "H2", "", "", "", "", "", "", "K3", "", "", ""}
        };
        public void olustur() 
        { 
           
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    if (string.IsNullOrEmpty(tablo[i, j]))
                    {
                        tablo[i, j] = " ";
                    }
                }
            }
        }
        public void tahtaCiz() 
        {
            
            Console.Write("   ");
            for(int i=0;i<15; i++)
            {
                Console.Write($" {i,2} ");
            }
            Console.WriteLine();



            
            Console.Write("   +");
            for(int i = 0; i < 15; i++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();

            for(int y = 0; y < 15; y++)
            {
               
                Console.Write($"{y,2} |" );
                
                
                for(int x = 0; x<15; x++)
                {
                    string hucre = tablo[y, x];
                    if (string.IsNullOrEmpty(hucre))
                    {
                        Console.Write("   |");
                    }
                    else { Console.Write($"{hucre,3}|"); }
                }


                Console.WriteLine();

               
                Console.WriteLine("   +");
                for (int j = 0; j < 15; j++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();

            }
        }

        public bool gecerliMi(int x,int y,string yon ,Sozluk sozluk) 
        {
            string kelime = "";
            if (yon == "yatay")
            {
                for (int i = y; i < 15 && !string.IsNullOrWhiteSpace(tablo[x,i]); i++) {
                    kelime += tablo[x,i];
                }
            }
            else if (yon == "dikey")
            {
                for(int i=x;i< 15 &&tablo[i,y] != null; i++)
                {
                    kelime += tablo[i,y];
                }
            }

            return sozluk.kelimeVarmi(kelime);
        }
         
        public int kelimePuanla(List<(int x, int y, HarfTasi tas)> yerlestirilen)
        {
            int toplampuan = 0;
            foreach (var (x, y, tas) in yerlestirilen)
            {
                string bonus = tablo[y, x];
                int carpim = 1;
                switch (bonus)
                {
                    case "H2":
                        toplampuan += tas.harfPuani * 2;
                        break;
                    case "H3":
                        toplampuan += tas.harfPuani * 3;
                        break;
                    case "K2":
                        carpim = 2;
                        toplampuan += tas.harfPuani;
                        break;
                    case "K3":
                        carpim = 3;
                        toplampuan += tas.harfPuani;
                        break;
                    default:
                        toplampuan += tas.harfPuani;
                        break;

                }
            }
            return toplampuan;
        }

        public void hucreGuncelle(int x,int y,string harf) {
            if(x>=0&&x<15&& y >= 0 && y < 15)
            {
                tablo[y,x] = harf;
            }
        }

        public string hucreOku(int x, int y)
        {
            if (x >= 0 && x < 15 && y >= 0 && y < 15)
            {
                return tablo[y, x];
            }
            return " "; 
        }

    }
}
