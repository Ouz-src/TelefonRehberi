using System;
using System.Collections;

namespace TelefonRehberi
{
    public class Islemler
    {
        public Dictionary<string, long> rehber = new();

        public void YeniNumaraKaydetmek()
        {
            Console.Write("Lütfen kaydetmek istediğiniz kişinin isim ve soyismini giriniz: ");
            string adSoyad = Console.ReadLine();
            Console.Write("\nLütfen telefon numarası giriniz: ");
            long numara = long.Parse(Console.ReadLine());
            if (rehber.ContainsKey(adSoyad))
            {
                Console.WriteLine("Bu kişi zaten rehberinizde kayıtlı!\nAna Menü'ye dönmek için bir tuşa basın.");
            }
            else
            {
                rehber.Add(adSoyad, numara);
                Console.WriteLine("Kayıt işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
            }
            Console.ReadKey();
            Console.Clear();
            Program.AnaMenu();
        }
        public void VarolanNumarayıSilmek()
        {
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ve soyadını giriniz: ");
            string sil = Console.ReadLine();
            if (rehber.ContainsKey(sil))
            {
                Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", sil);
                string input = Console.ReadLine();
                if (input == "y")
                {
                    rehber.Remove(sil);
                    Console.WriteLine("Kişi başarıyla silindi!\nAna Menü'ye dönmek için bir tuşa basın.");
                }
                else if (input == "n")
                {
                    Console.WriteLine("Silme işlemi iptal edildi.\nAna Menü'ye dönmek için bir tuşa basın.");
                    MenuyeDonme();
                }
                MenuyeDonme();
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için      : (2)");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Program.AnaMenu();
                        break;
                    case 2:
                        VarolanNumarayıSilmek();
                        break;
                    default:
                        Console.WriteLine("1 veya 2'yi tuşlamalısınız.");
                        MenuyeDonme();
                        break;
                }
            }
        }
        public void VarolanNumarayıGuncelleme()
        {
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ve soyadını giriniz: ");
            string guncelle = Console.ReadLine();
            if (rehber.ContainsKey(guncelle))
            {
                Console.WriteLine("Yeni numarayı tuşlayınız.");
                long yeniNumara = long.Parse(Console.ReadLine());
                long temp = rehber[guncelle];
                rehber[guncelle] = yeniNumara;
                Console.WriteLine("{0} olan eski numara {1} ile değiştirildi.\nAna Menü'ye dönmek için bir tuşa basın.", temp, yeniNumara);
                MenuyeDonme();
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Güncellemeyi sonlandırmak için : (1)\n* Yeniden denemek için      : (2)");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Program.AnaMenu();
                        break;
                    case 2:
                        VarolanNumarayıGuncelleme();
                        break;
                    default:
                        Console.WriteLine("1 veya 2'yi tuşlamalısınız.");
                        MenuyeDonme();
                        break;
                }
            }
        }
        public void RehberiListelemek()
        {
            Console.WriteLine("Telefon Rehberi\n******************************");
            foreach (var kisi in rehber)
            {
                Console.WriteLine("İsim - Soyisim: {0}", kisi.Key);
                Console.WriteLine("Telefon Numarası {0}\n----------------------------------", kisi.Value);
            }
            Console.WriteLine("Ana Menü'ye dönmek için bir tuşa basın.");
            Console.ReadKey();
            Console.Clear();
            Program.AnaMenu();
        }
        public void RehberdeAramaYapmak()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n******************************************\nİsim veya soyisime göre arama yapmak için: (1)\nTelefon numarasına göre arama yapmak için: (2)");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("Sorgulamak istediğiniz kişinin ismini ve soyismini tuşlayınız: ");
                    IsimSoyisimeGöreArama(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Sorgulamak istediğiniz numarayı tuşlayınız: ");
                    NumarayaGöreArama(long.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("1 veya 2'yi tuşlamalısınız.");
                    Console.ReadKey();
                    Console.Clear();
                    Program.AnaMenu();
                    break;
            }
        }

        private void IsimSoyisimeGöreArama(string input)
        {
            if (rehber.ContainsKey(input))
            {
                Console.WriteLine("Arama Sonuçlarınız:\n******************************************");
                Console.WriteLine("İsim - Soyisim: {0}", input);
                Console.WriteLine("Telefon Numarası: {0}", rehber[input]);
                Console.WriteLine("Ana Menü'ye dönmek için bir tuşa basın.");
                MenuyeDonme();
            }
            else
            {
                Console.WriteLine("Arama kriterlerine göre bir sonuç bulunamadı.\nAna Menü'ye dönmek için bir tuşa basın.");
                MenuyeDonme();
            }
        }
        private void NumarayaGöreArama(long input)
        {
            if (rehber.ContainsValue(input))
            {
                Console.WriteLine("Arama Sonuçlarınız:\n******************************************");
                string key = "";
                foreach (var item in rehber)
                {
                    if (item.Value == input)
                        key = item.Key;
                }
                Console.WriteLine("İsim - Soyisim: {0}", key);
                Console.WriteLine("Telefon Numarası: {0}", input);
                Console.WriteLine("Ana Menü'ye dönmek için bir tuşa basın.");
                MenuyeDonme();
            }
            else
            {
                Console.WriteLine("Arama kriterlerine göre bir sonuç bulunamadı.\nAna Menü'ye dönmek için bir tuşa basın.");
                MenuyeDonme();
            }
        }

        private void MenuyeDonme()
        {
            Console.ReadKey();
            Console.Clear();
            Program.AnaMenu();
        }
    }
}