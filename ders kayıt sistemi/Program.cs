class Program
{
    static List<Ders> Dersler = new List<Ders>();
    static List<Ogrenci> Ogrenciler = new List<Ogrenci>();
    static List<OgretimGorevlisi> OgretimGorevlileri = new List<OgretimGorevlisi>();

    static void Main(string[] args)
    {
        ornekVerileriEkle();
        while (true)
        {
            Console.WriteLine("1. Öğrenci Ekle");
            Console.WriteLine("2. Öğretim Görevlisi Ekle");
            Console.WriteLine("3. Ders Ekle");
            Console.WriteLine("4. Ders Kayıt");
            Console.WriteLine("5. Bilgileri Göster");
            Console.WriteLine("6. Çıkış");
            Console.Write("Seçiminiz: ");
            var secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    OgrenciEkle();
                    break;
                case "2":
                    OgretımGorevlisiyükle();
                    break;
                case "3":
                    YeniDersEkle();
                    break;
                case "4":
                    DersKayit();
                    break;
                case "5":
                    BilgileriGoster();
                    break;
                case "6":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }

    static void OgrenciEkle()
    {
        var ogrenci = new Ogrenci();
        Console.Write("Öğrenci Adı: ");
        ogrenci.Isim = Console.ReadLine();
        Console.Write("Öğrenci Numarası: ");
        ogrenci.OgrenciNo = Console.ReadLine();
        Ogrenciler.Add(ogrenci);
    }

    static void OgretımGorevlisiyükle()
    {
        var ogretimGorevlisi = new OgretimGorevlisi();
        Console.Write("Öğretim Görevlisi Adı: ");
        ogretimGorevlisi.Isim = Console.ReadLine();
        Console.Write("Bölüm: ");
        ogretimGorevlisi.Bolum = Console.ReadLine();
        OgretimGorevlileri.Add(ogretimGorevlisi);
    }

    static void YeniDersEkle()
    {
        var ders = new Ders();
        Console.Write("Ders Adı: ");
        ders.DersAdi = Console.ReadLine();
        Console.Write("Kredi: ");
        ders.Kredi = int.Parse(Console.ReadLine());
        Console.WriteLine("Öğretim Görevlileri:");
        for (int i = 0; i < OgretimGorevlileri.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {OgretimGorevlileri[i].Isim}");
        }
        Console.Write("Öğretim Görevlisi Numarasını Seçiniz: ");
        var ogretimGorevlisi = Console.ReadLine();
        ders.OgretimGorevlisi = OgretimGorevlileri[int.Parse(ogretimGorevlisi) - 1];
        Dersler.Add(ders);
    }

    static void DersKayit()
    {
        Console.WriteLine("Öğrenciler:");
        for (int i = 0; i < Ogrenciler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Ogrenciler[i].Isim}");
        }
        Console.Write("Öğrenci Numarasını Seçiniz: ");
        var ogrenciNo = Console.ReadLine();
        var ogrenci = Ogrenciler[int.Parse(ogrenciNo) - 1];

        Console.Write("Dersler:");
        for (int i = 0; i < Dersler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Dersler[i].DersAdi}");
        }
        Console.Write("Ders Numarasını Seçiniz: ");
        var dersNo = Console.ReadLine();
        var ders = Dersler[int.Parse(dersNo) - 1];

        ders.OgrenciKaydet(ogrenci);
    }

    static void BilgileriGoster() 
    {
        Console.WriteLine("Bilgi türünü seçiniz:");
        Console.WriteLine("1. Öğrenci");
        Console.WriteLine("2. Öğretim Görevlisi");
        Console.WriteLine("3. Ders");

        var secim = Console.ReadLine();
        switch (secim)
        {
            case "1":
                if (Ogrenciler.Count == 0)
                {
                    Console.WriteLine("Öğrenci bulunamadı!");
                    return;
                }
                foreach (var ogrenci in Ogrenciler)
                {
                    ogrenci.BilgiGoster();
                    Console.WriteLine("--------------------");
                }
                break;
            case "2":
                if (OgretimGorevlileri.Count == 0)
                {
                    Console.WriteLine("Öğretim görevlisi bulunamadı!");
                    return;
                }
                foreach (var ogretimGorevlisi in OgretimGorevlileri)
                {
                    ogretimGorevlisi.BilgiGoster();
                    Console.WriteLine("--------------------");
                }
                break;
            case "3":
                if (Dersler.Count == 0)
                {
                    Console.WriteLine("Ders bulunamadı!");
                    return;
                }
                foreach (var ders in Dersler)
                {
                    ders.BilgiGoster();
                    Console.WriteLine("--------------------");
                }
                break;
            default:
                Console.WriteLine("Geçersiz seçim!");
                break;
        }
    }

    static void ornekVerileriEkle()
    {
        var ogrenci1 = new Ogrenci { Isim = "Hamza Mintaş", OgrenciNo = "28" };
        var ogrenci2 = new Ogrenci { Isim = "Salih Eraslan", OgrenciNo = "61" };
        Ogrenciler.Add(ogrenci1);
        Ogrenciler.Add(ogrenci2);

        var ogretimGorevlisi1 = new OgretimGorevlisi { Isim = "Emrah Sarıçiçek", Bolum = "Bilgisayar Programcılığı" };
        var ogretimGorevlisi2 = new OgretimGorevlisi { Isim = "Erkan Aydın", Bolum = "Bilgisayar mühendisliği" };
        OgretimGorevlileri.Add(ogretimGorevlisi1);
        OgretimGorevlileri.Add(ogretimGorevlisi2);

        var ders1 = new Ders { DersAdi = "Nesneye Dayalı Programlama", Kredi = 3, OgretimGorevlisi = ogretimGorevlisi1 };
        var ders2 = new Ders { DersAdi = "Görsel Programlama", Kredi = 4, OgretimGorevlisi = ogretimGorevlisi2 };
        Dersler.Add(ders1);
        Dersler.Add(ders2);

        ders1.OgrenciKaydet(ogrenci1);
        ders1.OgrenciKaydet(ogrenci2);
        ders2.OgrenciKaydet(ogrenci1);
    }
}