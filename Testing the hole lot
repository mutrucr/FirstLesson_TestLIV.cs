using System;
using System.Collections.Generic;

class Program
{
    static double ReadPower(double current, double threshold)
    {
        if (current < threshold) return current * 0.01;
        return (current - threshold) * 0.8;
    }

    static void Main()
    {
        // ARRAY — o listă fixă de valori, lotul nostru de diode.
        // Fiecare număr = threshold-ul unei diode.
        double[] batch = { 20.0, 22.0, 35.0, 28.0, 19.5, 25.0, 31.0, 21.0 };

        int passed = 0;   // contor — începe de la zero
        int failed = 0;

        // FOREACH — loop care ia "fiecare element din listă",
        // pe rând, fără să numeri tu pozițiile
        foreach (double threshold in batch)
        {
            double power = ReadPower(50.0, threshold);
            bool pass = power >= 20.0;

            if (pass) passed++;   // ++ înseamnă "adaugă 1"
            else failed++;

            Console.WriteLine($"Threshold {threshold} mA → {power:F1} mW → {(pass ? "PASS" : "FAIL")}");
        }

        // RAPORTUL — yield = procentul de piese bune
        double yield = (double)passed / batch.Length * 100;

        Console.WriteLine($"\n=== SUMMARY ===");
        Console.WriteLine($"Total: {batch.Length} | Passed: {passed} | Failed: {failed}");
        Console.WriteLine($"Yield: {yield:F1}%");
    }
}
