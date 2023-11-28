using System;

List<List<string>> labirynty = new List<List<string>>();
labirynty.Add(new List<string>());


for (int i = 1; i < 101; i++)
{
    string znak = "*";
    if (i%10 ==0)
    {
        labirynty[0].Add(znak+"\n");
    }
    else
    {
        labirynty[0].Add(znak);
    }
}



for (; ; )
{
    Console.WriteLine("\nWybierz co chcesz zrobic\n" +
        "1. Wyswietl labirynty\n" +
        "2. Utwórz labirynt\n" +
        "3. Edytuj labirynt\n" +
        "4. Usun labirynt\n" +
        "5. Zapisz labirynt\n" +
        "6. Odczytaj labirynt\n" +
        "7. Wyjdz z programu");

    try
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int j = 0;
        switch (a)
        {

            case 1:
                j = 0;
                foreach (var lista in labirynty)
                {
                    Console.WriteLine($"Labirynt numer: {j}");
                    foreach (var element in lista)
                    {
                        Console.Write($"{element}");
                    }
                    Console.WriteLine("\n");
                    j++;
                }
                j = 0;
                break;
            case 2:

                Console.WriteLine("Ile labirynt ma miec kolumn?");
                int kolumny = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ile labirynt ma miec wierszy?");
                int wiersze = Convert.ToInt32(Console.ReadLine());

                labirynty.Add(new List<string>());
                int ktoryLabirynt = (labirynty.Count - 1);

                for (int i = 1; i <= (kolumny * wiersze); i++)
                {
                    string znak = "*";
                    if (i % kolumny == 0)
                    {
                        labirynty[ktoryLabirynt].Add(znak + "\n");
                    }
                    else
                    {
                        labirynty[ktoryLabirynt].Add(znak);
                    }
                }

                Console.WriteLine("Prawidlowo utworzona labirynt");

                break;
            case 3:
                j = 0;
                Console.WriteLine("Ktory labirynt chcesz edytowac?");
                foreach (var lista in labirynty)
                {
                    Console.WriteLine($"Labirynt numer: {j}");
                    foreach (var element in lista)
                    {
                        Console.Write($"{element}");
                    }
                    Console.WriteLine("\n");
                    j++;
                }
                int edycja = Convert.ToInt32(Console.ReadLine());
                foreach (var lista in labirynty)
                {
                    if (labirynty[edycja] == lista)
                    {
                        int i = 0;
                        Console.WriteLine($"Wybrales labirynt {edycja}");
                        foreach (var element in lista)
                        {
                            Console.Write($"{i} {element} ");
                            i++;
                        }
                    }
                }
                Console.WriteLine($"Ktory element chcesz edytowac?");
                int edytowanyElement = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Jaka ma tam byc wartosc (podaj jeden znak)?");
                string wartoscEdytowanegoElementu = Convert.ToString(Convert.ToChar(Console.ReadLine()));

                if (labirynty[edycja][edytowanyElement].Contains("\n")) 
                {
                    labirynty[edycja][edytowanyElement] = wartoscEdytowanegoElementu+"\n";
                }
                else
                {
                    labirynty[edycja][edytowanyElement] = wartoscEdytowanegoElementu;
                }

                Console.WriteLine($"Poprawnie edytowales wpis");

                break;
            case 4:
                j = 0;
                foreach (var lista in labirynty)
                {
                    Console.WriteLine($"Labirynt numer: {j}");
                    foreach (var element in lista)
                    {
                        Console.Write($"{element}");
                    }
                    Console.WriteLine("\n");
                    j++;
                }
                j = 0;
                Console.WriteLine("Ktory labirynt chcesz usunac?");
                int b = Convert.ToInt32(Console.ReadLine());
                labirynty.RemoveAt(b);
                Console.WriteLine($"Poprawnie usunales labirnyt numer: {b}");

                break;
            case 5:
                j = 0;
                foreach (var lista in labirynty)
                {
                    Console.WriteLine($"Labirynt numer: {j}");
                    foreach (var element in lista)
                    {
                        Console.Write($"{element}");
                    }
                    Console.WriteLine("\n");
                    j++;
                }
                j = 0;

                Console.WriteLine("Podaj jaki labirynt chcesz zapisac");
                int jakichcezapisac = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj pod jaka nazwe chcesz zapiasac labirynt (pamietaj jesli taki labirynt istnieje zostanie nadpisany)");
                string labiryntnazwa = Convert.ToString(Console.ReadLine());

                string sciezka = $"G:\\3p Dominik K\\labirynty\\{labiryntnazwa}.txt";
                using (StreamWriter pisaniepliku = File.CreateText(sciezka))
                {
                    foreach (var element in labirynty[jakichcezapisac])
                    {
                        pisaniepliku.Write(element);
                    }
                }

                Console.Write($"Prawidlowo zapisales plik");
                break;
            case 6:
                Console.WriteLine("Podaj nazwe pliku jakiego chcesz odczytac");
                string labiryntszukananazwa = Convert.ToString(Console.ReadLine());
                string sciezkaa = $"G:\\3p Dominik K\\labirynty\\{labiryntszukananazwa}.txt";

                using (StreamReader odczytpliku = new StreamReader(sciezkaa))
                {
                    labirynty.Add(new List<string>());

                    while (!odczytpliku.EndOfStream)
                    {
                        string odczytyciag = odczytpliku.ReadLine();
                        Console.WriteLine(odczytyciag);
                        
                        int labLiczba = labirynty.Count - 1;
                        char[] okee = odczytyciag.ToCharArray();
                        int dlugoscTabCharuw = okee.Length - 1;

                        int k = 0;
                        foreach (var item in okee)
                        {
                            if(k == dlugoscTabCharuw)
                            {
                                labirynty[labLiczba].Add($"{Convert.ToString(item)}\n");
                            }
                            else
                            {
                                labirynty[labLiczba].Add($"{Convert.ToString(item)}");
                            }
                            k++;
                        }

                    }
                }

                break;
            case 7:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Podales zla liczbe");
                break;
        }
    }
    catch
    {
        Console.WriteLine("Zly znak ;P");
    }
}