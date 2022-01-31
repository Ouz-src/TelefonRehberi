using System;
using System.Collections;

namespace TelefonRehberi
{
    class Program : Islemler
    {
        static Islemler islemTuru = new();
        static void Main(String[] args)
        {
            //Varsayılan kullanıcılar
            islemTuru.rehber.Add("Uğur Oğuzhan Karadeniz", 5342341256);
            islemTuru.rehber.Add("Kylian Mbappé", 5365792408);
            islemTuru.rehber.Add("Marcus Fenix", 5471350198);
            islemTuru.rehber.Add("Görkem Eroğlu", 5309822264);
            islemTuru.rehber.Add("Ronnie Coleman", 5304205327);
            AnaMenu();
            Console.ReadKey();
        }

        public static void AnaMenu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz.\n*****************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek\n(2) Varolan Numarayı Silmek\n(3) Varolan Numarayı Güncelleme\n(4) Rehberi Listelemek\n(5) Rehberde Arama Yapmak");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    islemTuru.YeniNumaraKaydetmek();
                    break;
                case 2:
                    islemTuru.VarolanNumarayıSilmek();
                    break;
                case 3:
                    islemTuru.VarolanNumarayıGuncelleme();
                    break;
                case 4:
                    islemTuru.RehberiListelemek();
                    break;
                case 5:
                    islemTuru.RehberdeAramaYapmak();
                    break;
                default:
                    Console.WriteLine("1-5 aralığında girdi yapmalısınız.");
                    break;
            }
        }
    }
}