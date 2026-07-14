// LECȚIA 1 — Simulare Test LIV pentru o diodă laser
// 1. Crește curentul pas cu pas (ca sursa Keysight)
// 2. Citește puterea optică (ca power meterul Thorlabs)
// 3. Afișează rezultatele și le salvează în CSV

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // "DIODA" SIMULATĂ:
    // sub prag → aproape zero lumină
    // peste prag → puterea crește liniar
    static double CitestePuterea(double curent_mA)
    {
        double prag = 20.0;      // curent de prag: 20 mA
        double eficienta = 0.8;  // mW câștigați per mA peste prag

        if (curent_mA < prag)
        {
            // Sub prag: doar puțină lumină spontană
            return curent_mA * 0.01;
        }
        else
        {
            // Peste prag: liniar + puțin zgomot,
            // ca o măsurătoare reală
            double zgomot = new Random().NextDouble() * 0.2;
            return (curent_mA - prag) * eficienta + zgomot;
        }
    }

    static void Main()
    {
        Console.WriteLine("=== TEST LIV — Dioda simulata ===");
        Console.WriteLine();
        Console.WriteLine("Curent (mA)   Putere (mW)");
        Console.WriteLine("--------------------------");

        // Lista în care adunăm rândurile pentru CSV
        List<string> rezultate = new List<string>();
        rezultate.Add("Curent_mA,Putere_mW");

        // BUCLA DE TEST: 0 → 50 mA, pas de 2 mA
        for (double curent = 0; curent <= 50; curent += 2)
        {
            // 1. "Setăm" curentul și "citim" puterea
            double putere = CitestePuterea(curent);

            // 2. Afișăm pe ecran
            Console.WriteLine($"{curent,8:F1}   {putere,10:F2}");

            // 3. Adăugăm rândul în lista CSV
            rezultate.Add($"{curent:F1},{putere:F2}");
        }

        // Salvăm totul în fișier (se deschide în Excel)
        File.WriteAllLines("rezultate_LIV.csv", rezultate);

        Console.WriteLine();
        Console.WriteLine("Gata! Salvat in: rezultate_LIV.csv");
    }
}
