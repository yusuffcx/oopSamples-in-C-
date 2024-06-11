
using System;


class Program
{
    static void Main()
    {
        Class1 c = new Class1
        {
            CeyhanProp = 15
        };
        c.A = 15;
        Console.WriteLine(c.A);
        Console.WriteLine(c.B);
        Class1 a = new();
        Console.WriteLine(c.CeyhanProp);

        Record1 m = new Record1(); // Record tanımı
        var (n, s) = m; // Deconstruct tanımlama 
        Console.WriteLine(m.name);
        Console.WriteLine(m.surname);
        Record1 m1 = new Record1("Yusuf");
        Console.WriteLine(m1.name);
        Console.WriteLine(m1.surname);
        Console.WriteLine();
        Console.WriteLine();

        Ucgen U1 = new Ucgen(3, 4);
        Dortgen D1 = new Dortgen(5, 6);

        Console.WriteLine(U1.AlanHesapla());
        Console.WriteLine(D1.AlanHesapla());

        // Polimorfizm
        Arac A1 = new Araba();
        Arac A2 = new Kamyon();
        Arac A3 = new Arac();
        Arac A4 = new ElektrikliAraba();
        Arac A5 = new BuyukKamyon();
        A1.Start();
        A2.Start();
        A3.Start();
        A4.Start();
        A5.Start();

        Console.WriteLine("Nesneleri kendi türlerine dönüştürdükten sonra:");
        Console.WriteLine();

        // Nesneleri kendi turune donusturme,,,
        Araba a1 = (Araba)A1;
        Kamyon a2 = (Kamyon)A2;
        ElektrikliAraba a4 = (ElektrikliAraba)A4;
        BuyukKamyon a5 = (BuyukKamyon)A5;

        a1.Start();
        a2.Start();
        A3.Start();
        a4.Start();
        a5.Start();
    }
}

record Record1(string name, string surname) // Positional record tanımı
{  // Constructor tanımı yapıldı.
    public Record1() :this("Jack", "Hamilton")
    {

    }
    public Record1(string name) : this()
    {
        Console.WriteLine(name);
    }

    public string ahmet => name;
    public string mehmet => surname;

}


class Class1
{
    int a;
    String soyad;

    public int A // full property , field oluşturulmalı
    {
        get { return a + 10; }

        set { a = value; }
    }

    public int CeyhanProp
    {
        get;
        init;
    }

    public int B { get; set; } = 47; // Prop property , field oluşturulmaz.
}

class Sekil
{
    protected int _en;
    protected int _boy;


    public Sekil(int boy, int en)
    {
        _en = en;
        _boy = boy;
    }

    virtual public int AlanHesapla()
    {
        return 0;
    }
}

class Ucgen : Sekil
{
    public Ucgen(int boy ,int en): base(boy,en)
    {

    }

    public override int AlanHesapla()
    {
        return _boy * _en / 2;
    }
}

class Dortgen : Sekil
{
    public Dortgen(int boy, int en) : base(boy, en)
    {
        
    }
    public override int AlanHesapla()
    {
        return _en * _boy;
    }
}
class Dikdortgen : Sekil
{
    public Dikdortgen(int boy, int en): base(boy, en)
    { 

    }
    public override int AlanHesapla()
    {
        return _en * _boy;
    }
}


class Arac
{
    public int tekerSayisi;
    public int Beygir;

    public virtual void Start()
    {
        Console.WriteLine("Arac Calıştı");
    }
}

class Araba : Arac
{
    public override void Start()
    {
        Console.WriteLine("Araba Calıştı");
    }

}

class Kamyon : Arac
{
    public override void Start()
    {
        Console.WriteLine("Kamyon Çalıştı");
    }

}

class ElektrikliAraba : Araba
{
    sealed public override void Start()
    {
        Console.WriteLine("Elektrikli arac calıstı");
    }
}

class BuyukKamyon : Kamyon
{
    public override void Start()
    {
        Console.WriteLine("Buyuk kamyon calıstı");
    }
}

class ElektrikliSUV : ElektrikliAraba
{
    /*public override void Start()
    {
        Console.WriteLine("Elektrikli SUV calıstı");
    }*/
    // sealed ile mühürlenmiş bir metot override edilemez.
}





