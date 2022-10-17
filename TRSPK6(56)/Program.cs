// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Diagnostics;
using System.Globalization;

Task2();
Task5();
Task6();

void Task2()
{
    int a = 1234;

    WriteInColor("Стандартные форматы", 1);

    Console.Write($"Число {a} с форматом \"D6\" (целое число и незначащие нули): ");
    WriteInColor(a.ToString("D6"));

    double b = 1234.5678;

    Console.Write($"Число {b} с форматом \"C, en-US\" (валюта): ");
    WriteInColor(b.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));

    Console.Write($"Число {b} с форматом \"E\" (экспоненциальная нотация): ");
    WriteInColor(b.ToString("E"));

    Console.Write($"Число {b} с форматом \"F1, en-US\" (с плавющей запятой): ");
    WriteInColor(b.ToString("F1", CultureInfo.CreateSpecificCulture("en-US")));

    Console.Write($"Число {b} с форматом \"G6, se-SE\" (экспоненциально или с плавющей запятой): ");
    WriteInColor(b.ToString("G6", CultureInfo.CreateSpecificCulture("se-SE")));

    Console.Write($"Число {b} с форматом \"N, ru-RU\" (разделение по группам и целой и дроьной части): ");
    WriteInColor(b.ToString("N", CultureInfo.CreateSpecificCulture("ru-RU")));

    Console.Write($"Число {b} с форматом \"P\" (проценты): ");
    WriteInColor(b.ToString("P"));

    Console.WriteLine($"Число {b} с форматом \"R\", \"G17\", \"G9\" - даёт при обратном приобразовании идентичное число (BigInteger, Double, Single)");

    Console.Write($"Число {a} с форматом \"X\" (шестнадцатеричный): ");
    WriteInColor(a.ToString("X"));

    WriteInColor(DateTime.Now.ToString("d"));
    WriteInColor(DateTime.Now.ToString("D"));
    WriteInColor(DateTime.Now.ToString("f"));
    WriteInColor(DateTime.Now.ToString("F"));
    WriteInColor(DateTime.Now.ToString("g"));
    WriteInColor(DateTime.Now.ToString("G"));
    WriteInColor(DateTime.Now.ToString("M"));
    WriteInColor(DateTime.Now.ToString("O"));
    WriteInColor(DateTime.Now.ToString("R"));
    WriteInColor(DateTime.Now.ToString("s"));
    WriteInColor(DateTime.Now.ToString("t"));
    WriteInColor(DateTime.Now.ToString("T"));
    WriteInColor(DateTime.Now.ToString("u"));
    WriteInColor(DateTime.Now.ToString("U"));
    WriteInColor(DateTime.Now.ToString("Y"));

    Console.WriteLine();

    WriteInColor("Нестандартные форматы", 1);

    string s = String.Format("Сегодня {0:d} {0:t}", DateTime.Now);
    Console.WriteLine(s);

    s = String.Format("Сейчас {0:H:mm:ss K} {0:yyyy gg}", DateTime.Now);
    Console.WriteLine(s);

    s = String.Format("{0:0000000}", a);
    Console.WriteLine(s);
    s = String.Format("{0:######.##}", b);
    Console.WriteLine(s);
    s = String.Format("{0:%#0.00}", 0.053);
    Console.WriteLine(s);

    Console.WriteLine("Введите дату в формате (дд/мм/гггг): ");
    string? s11 = Console.ReadLine();
    ConvertToDate(s11);

    Console.WriteLine("Введите дату в формате (ДеньНедели Месяц Число, Год): ");
    s11 = Console.ReadLine();
    ConvertToDate(s11);

    Console.WriteLine("Введите дату в формате (чч:мм:сс): ");
    s11 = Console.ReadLine();
    ConvertToDate(s11);
}

void Task5()
{
    String s1 = "Not a long string";
    String s2 = "Other string";
    StringBuilder sb1 = new StringBuilder("Not a long string");
    StringBuilder sb2 = new StringBuilder("Other string");
    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; i < 10000; i++)
    {
        s1 = String.Concat(s1, s2);
    }
    sw.Stop();
    TimeSpan ts = sw.Elapsed;
    Console.WriteLine($"Время конкатенации String: {ts}");
    sw = Stopwatch.StartNew();
    for (int i = 0; i < 10000; i++)
    {
        sb1.Append(sb2);
    }
    sw.Stop();
    ts = sw.Elapsed;
    Console.WriteLine($"Время конкатенации StringBuilder: {ts}");
}

void Task6()
{
    string s3 = "", s6 = "", s5 = "";
    string s4 = "AbraCadabraBruhBruhBruh";
    for (int i = 0; i < 10000; i++)
    {
        s3 = String.Concat(s3, s4);
        s5 = String.Concat(s5, s4);
        s6 = String.Concat(s6, s4);
    }
    s3 = String.Intern(s3);
    s5 = String.Intern(s5);
    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++)
    {
        if (s3 == s5)
        { }
    }
    sw.Stop();
    TimeSpan ts = sw.Elapsed;
    Console.WriteLine($"Время сравнения с  интернированием: {ts}");
    sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++)
    {
        if (s3 == s6)
        { }
    }
    sw.Stop();
    ts = sw.Elapsed;
    Console.WriteLine($"Время сравнения без интернирования: {ts}");
}


void WriteInColor(string a, int opt = 0)
{
    if (opt == 0)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
    }
    Console.Write(a);
    Console.WriteLine();
    Console.ResetColor();
}

void ConvertToDate(string? s)
{
    try
    {
        Console.WriteLine("{0}", Convert.ToDateTime(s));
    }
    catch (FormatException)
    {
        Console.WriteLine("Format Exception");
    }
}