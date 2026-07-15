using System;

class Program
{
    // Aceeași diodă simulată ca în Lecția 1,
    // dar acum threshold-ul vine ca parametru —
    // ca să putem testa diode DIFERITE
    static double ReadPower(double current_mA, double threshold)
    {
        if (current_mA < threshold)
            return current_mA * 0.01;
        else
            return (current_mA - threshold) * 0.8;
    }

    // FUNCȚIA DE TEST: primește o diodă (threshold-ul ei)
    // și returnează verdictul: true = PASS, false = FAIL
    static bool TestDiode(string name, double threshold)
    {
        // SPECIFICAȚIA de calitate (ca în producție):
        // la 50 mA, dioda TREBUIE să dea minim 20 mW
        double testCurrent = 50.0;
        double minPower = 20.0;

        double power = ReadPower(testCurrent, threshold);

        // DECIZIA — conditional statement:
        bool pass = power >= minPower;

        // Operatorul "? :" alege un text scurt:
        // dacă pass e true → "PASS", altfel → "FAIL"
        string verdict = pass ? "PASS" : "FAIL";

        Console.WriteLine($"{name}: {power:F1} mW la {testCurrent} mA → {verdict}");

        return pass;
    }

    static void Main()
    {
        Console.WriteLine("=== QUALITY TEST — Diode Batch ===\n");

        // Un LOT de 4 diode, fiecare cu threshold-ul ei.
        // Dioda sănătoasă are threshold mic (~20 mA).
        // Threshold mare = diodă slabă/degradată.
        TestDiode("Dioda A", 20.0);
        TestDiode("Dioda B", 22.0);
        TestDiode("Dioda C", 35.0);   // asta o știi din tema ta!
        TestDiode("Dioda D", 28.0);
    }
}
