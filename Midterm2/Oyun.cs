using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Midterm2
{
    internal class Oyun
    {
        private List <Oyuncu>oyuncular=new List<Oyuncu>();
        private List<HarfTasi> tas_havuzu=new List<HarfTasi>();
        Torba torba=new Torba();
        OyunTahtasi tahta =new OyunTahtasi() ;
        private int oyuncu1Puan = 0;
        private int oyuncu2Puan=0;  
        private Sozluk sozluk= new Sozluk();
        string[] kelimeListesi = new string[]
     {
                 "elma", "masa", "kalem", "kitap", "bardak", "kapı", "telefon", "araba", "çanta", "sandalye",
             "saat", "bilgisayar", "yastık", "defter", "uçak", "ev", "ışık", "pantolon", "ayakkabı", "gözlük",
             "çorap", "kazak", "kedi", "köpek", "battaniye", "perde", "ayna", "lamba", "televizyon", "çalışma",
    "yemek", "su", "ekmek", "tuz", "şeker", "bal", "peynir", "zeytin", "yumurta", "çay",
    "kahve", "yoğurt", "makarna", "pilav", "et", "balık", "muz", "portakal", "karpuz", "üzüm",
    "çilek", "kiraz", "kavun", "şeftali", "kayısı", "domates", "salatalık", "soğan", "patates", "havuç",
    "lahana", "ıspanak", "pırasa", "kabak", "fasulye", "bezelye", "biber", "mısır", "marul", "turp",
    "limon", "nar", "ceviz", "fındık", "fıstık", "badem", "yoğunluk", "hız", "zaman", "uzay",
    "gezegen", "dünya", "güneş", "ay", "yıldız", "galaksi", "evren", "madde", "enerji", "kuark",
    "atom", "nötron", "proton", "elektron", "ışık", "manyetik", "çekim", "yerçekimi", "kuvvet", "basınç",
    "sıcaklık", "derece", "hava", "rüzgar", "yağmur", "kar", "bulut", "fırtına", "gökkuşağı", "şimşek",
    "yıldırım", "sel", "deprem", "volkan", "tsunami", "orman", "ağaç", "çiçek", "yaprak", "dal",
    "kök", "tohum", "toprak", "göl", "nehir", "deniz", "okyanus", "kıyı", "ada", "yarımada",
    "çöl", "vadi", "dağ", "tepe", "plato", "bozkır", "ova", "iklim", "mevsim", "ilkbahar",
    "yaz", "sonbahar", "kış", "gece", "gündüz", "sabah", "öğle", "akşam", "gece", "tan",
    "zaman", "takvim", "saat", "dakika", "saniye", "milisaniye", "gün", "hafta", "ay", "yıl",
    "yüzyıl", "bin", "sayı", "rakam", "onluk", "ikilik", "hesap", "matematik", "geometri", "fizik",
    "kimya", "biyoloji", "canlı", "hayvan", "bitki", "mikrop", "virüs", "bakteri", "insan", "çocuk",
    "kadın", "erkek", "aile", "anne", "baba", "kardeş", "abi", "abla", "dede", "nine",
    "kuzen", "amca", "dayı", "teyze", "hala", "yeğen", "arkadaş", "dost", "komşu", "öğrenci",
    "öğretmen", "müdür", "doktor", "hemşire", "polis", "asker", "pilot", "şoför", "mühendis", "avukat",
    "hakim", "savcı", "memur", "sekreter", "işçi", "patron", "çiftçi", "balıkçı", "kasap", "manav",
    "berber", "kuaför", "terzi", "boyacı", "tamirci", "garson", "aşçı", "şarkıcı", "oyuncu", "sporcu",
    "yazar", "şair", "ressam", "heykeltıraş", "gazeteci", "fotoğrafçı", "sunucu", "yönetmen", "editör", "programcı",
    "yazılım", "donanım", "kod", "veri", "algoritma", "sistem", "uygulama", "program", "internet", "ağ",
    "sunucu", "istemci", "dosya", "klasör", "işletim", "giriş", "çıkış", "arayüz", "buton", "menü",
    "ayar", "ekran", "görüntü", "renk", "çözünürlük", "boyut", "genişlik", "yükseklik", "piksel", "format",
    "video", "ses", "müzik", "şarkı", "melodi", "ritim", "nota", "enstrüman", "piyano", "gitar",
    "keman", "davul", "flüt", "zurna", "klarnet", "saz", "bağlama", "kaval", "bateri", "org"
     };
        public void oyunuBaslat() {
            oyuncuBilgileriniAl();
           
            torba.doldur();
            torba.karistir();

            tas_havuzu = torba.TaslariGetir();
            tahta.tahtaCiz();
            foreach(var kelime in kelimeListesi)
            {
                sozluk.kelimeYukle(kelime);
            }
            taslariDagit();
        }
        public void oynat() {
            bool oyunBittimi = false;
            int oyuncuSayisi = oyuncular.Count;
            while (!oyunBittimi)
            {
                for(int i = 0; i < oyuncuSayisi; i++)
                {
                    Oyuncu aktifOyuncu=oyuncular[i];
                    Console.WriteLine("\n"+aktifOyuncu.name+" adlı oyuncunun sırası");
                    aktifOyuncu.taslariniYaz();
                    aktifOyuncu.taslariniYaz();
                    

                    Console.WriteLine("Bir harf seçin: ");
                    string secim = Console.ReadLine().ToUpper();
                    if (string.IsNullOrWhiteSpace(secim))
                    {
                        Console.WriteLine("Geçersiz giriş!");
                            continue;
                    }
                    char harf = secim[0];
                    HarfTasi tas = aktifOyuncu.taslar.Find(T => T.harf == harf);
                    if (tas == null) {
                        Console.WriteLine("Bu harf taşlarınız arasında bulunmuyor.");
                        continue;
                    }
                    Console.WriteLine("Yatay koordinatı giriniz(0-14): ");
                    if(!int.TryParse(Console.ReadLine(),out int yatay) || yatay < 0 || yatay > 14)
                    {
                        Console.WriteLine("Geçersiz giriş");
                        continue;
                    }
                    Console.WriteLine("Dikey koordinatı giriniz(0-14):");
                    if (!int.TryParse(Console.ReadLine(),out int dikey) || dikey < 0 || dikey > 14)
                    {
                        Console.WriteLine("Geçersiz giriş");
                        continue;
                    }

                    tahta.hucreGuncelle(yatay, dikey, tas.harf.ToString());
                    aktifOyuncu.taslar.Remove(tas);

                    var yerlestirilen = new List<(int x, int y, HarfTasi tas)>
                    {
                        (yatay,dikey,tas)
                    };

                    int puan = tahta.kelimePuanla(yerlestirilen);
                    aktifOyuncu.point += tas.harfPuani;
                    tahta.tahtaCiz();


                    if (tas_havuzu.Count > 0) { 
                        HarfTasi yeniTas=tas_havuzu[0];
                        tas_havuzu.RemoveAt(0);
                        aktifOyuncu.taslar.Add(yeniTas);
                    }
                    if(tas_havuzu.Count==0&& aktifOyuncu.taslar.Count == 0)
                    {
                        oyunBittimi = true;
                        break;
                    }
                }
                Console.WriteLine($"Kalan taş sayısı: {tas_havuzu.Count}");
                SkorlariYaz();
            }
            Console.WriteLine("Oyun bitti");
            foreach(var o in oyuncular)
            {
                Console.WriteLine($"{o.name}: {o.point} puan");
            }
        
        }

        public bool oyunBittimi(bool sonuc)
        {
            return tas_havuzu.Count == 0 && oyuncular.All(o => o.taslar.Count == 0);
        }
        public void oyuncuBilgileriniAl()
        {
           for(int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"{i}. Oyuncunun adını girin: ");
                string isim=Console.ReadLine();
                Console.WriteLine($"{i}. Oyuncunun yaşını girin: ");
                int yas = int.Parse(Console.ReadLine());
                

                Oyuncu o=new Oyuncu();
                o.name= isim;
                o.age= yas;
                oyuncular.Add(o);
            }
        }
        public void taslariDagit()
        {
            Random rnd = new Random();
            foreach(var oyuncu in oyuncular)
            {
                while (oyuncu.taslar.Count < 7 && tas_havuzu.Count > 0)
                {
                    int index = rnd.Next(tas_havuzu.Count);
                    oyuncu.tasEkle(tas_havuzu[index]);
                    tas_havuzu.RemoveAt(index);
                }
            }
        }
        public void oyuncularinTaslarinigoster()
        {
            foreach(var oyuncu in oyuncular)
            {
                oyuncu.taslariniYaz();
            }
        }
   
        public bool GirilenInputGecerliMi(string input , Oyuncu oyuncu)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            char harf = input[0];
            return oyuncu.taslar.Any(t => t.harf == harf);
        }

        public void SkorlariYaz()
        {
            foreach (var oyuncu in oyuncular)
                Console.WriteLine($"{oyuncu.name}-Puan: {oyuncu.point}");
        }     
    }
}
