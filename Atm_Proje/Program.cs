//Kullanıcının bakiye sorgulama, para çekme ve para yatırma işlemlerini yapabileceği bir ATM simülasyonu oluşturun.
//Para çekme işlemlerinde bakiye kontrolü yapın.
//Kullanıcı yanlış giriş yaparsa 3 hak verin, 3 kez yanlış giriş yaparsa hesabı bloke edin
//product name.stock.price
//ürünler listesi oluşturup ekran çktısı veiniz 

class ATM
{
    static double bakiye = 1000;  // Başlangıç bakiyesi
    static int hak = 3;           // Kullanıcının şifre deneme hakkı
    static bool hesapBloke = false; // Hesabın bloke durumu
    static string sifre = "1234";   // Örnek şifre

    static void Main()
    {
        Console.WriteLine("ATM'ye Hoşgeldiniz!");

        while (!hesapBloke)
        {
            Console.WriteLine("Lütfen şifrenizi girin:");
            string girilenSifre = Console.ReadLine();

            if (girilenSifre == sifre)
            {
                // Şifre doğruysa işlemleri başlat
                HesapIslemleri();
                break;
            }
            else
            {
                hak--;
                if (hak > 0)
                {
                    Console.WriteLine($"Yanlış şifre! Kalan hak: {hak}");
                }
                else
                {
                    hesapBloke = true;
                    Console.WriteLine("Hesabınız bloke olmuştur. Lütfen bankayla iletişime geçin.");
                }
            }
        }
    }

    static void HesapIslemleri()
    {
        while (!hesapBloke)
        {
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Bakiye Sorgulama");
            Console.WriteLine("2 - Para Çekme");
            Console.WriteLine("3 - Para Yatırma");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    BakiyeSorgulama();
                    break;
                case "2":
                    ParaCekme();
                    break;
                case "3":
                    ParaYatirma();
                    break;
                case "4":
                    Console.WriteLine("Çıkış yapılıyor...");
                    hesapBloke = true;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek! Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void BakiyeSorgulama()
    {
        Console.WriteLine($"Mevcut bakiyeniz: {bakiye} TL");
    }

    static void ParaCekme()
    {
        Console.Write("Çekmek istediğiniz tutarı girin: ");
        double cekilecekTutar;

        // Girilen değerin geçerli bir sayı olup olmadığını kontrol et
        if (double.TryParse(Console.ReadLine(), out cekilecekTutar))
        {
            if (cekilecekTutar > bakiye)
            {
                Console.WriteLine("Yetersiz bakiye! Daha az bir tutar çekmeyi deneyin.");
            }
            else if (cekilecekTutar <= 0)
            {
                Console.WriteLine("Geçersiz tutar! Lütfen pozitif bir sayı girin.");
            }
            else
            {
                bakiye -= cekilecekTutar;
                Console.WriteLine($"{cekilecekTutar} TL başarıyla çekildi. Yeni bakiyeniz: {bakiye} TL");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz giriş! Lütfen geçerli bir sayı girin.");
        }
    }

    static void ParaYatirma()
    {
        Console.Write("Yatırmak istediğiniz tutarı girin: ");
        double yatirilanTutar;

        // Girilen değerin geçerli bir sayı olup olmadığını kontrol et
        if (double.TryParse(Console.ReadLine(), out yatirilanTutar))
        {
            if (yatirilanTutar <= 0)
            {
                Console.WriteLine("Geçersiz tutar! Lütfen pozitif bir sayı girin.");
            }
            else
            {
                bakiye += yatirilanTutar;
                Console.WriteLine($"{yatirilanTutar} TL başarıyla yatırıldı. Yeni bakiyeniz: {bakiye} TL");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz giriş! Lütfen geçerli bir sayı girin.");
        }
    }
}













