using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        int n = 100; // Górna granica przedziału

        // Tworzymy tablicę, w której będziemy śledzić, czy liczby są pierwsze (0 - nie pierwsza, 1 - pierwsza)
        int[] isPrime = new int[n + 1];

        // Inicjalizujemy wszystkie liczby jako potencjalnie pierwsze
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = 1;
        }

        // Wypełniamy tablicę przy użyciu funkcji FillSieve
        FillSieve(isPrime, n);

        // Wyświetlamy liczby pierwsze w przedziale
        Console.WriteLine("Liczby pierwsze w przedziale 2 do " + n + " to:");

        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i] == 1)
            {
                Console.Write(i + " ");
            }
        }

        Console.ReadLine(); // Pauza
    }

    static void FillSieve(int[] isPrime, int n)
    {
        // Algorytm Sita Eratostenesa
        for (int p = 2; p * p <= n; p++)
        {
            // Jeśli p jest pierwszą liczbą, oznacz jej wielokrotności jako liczby nie pierwsze
            if (isPrime[p] == 1)
            {
                for (int i = p * p; i <= n; i += p)
                {
                    isPrime[i] = 0;
                }
            }
        }
    }
}
