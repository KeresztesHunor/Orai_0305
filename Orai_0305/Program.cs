namespace Orai_0305
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadLine();
        }

        void Run()
        {
            TermekFeladat();
            HengerFeladat();
            AruFeladat();
        }

        void TermekFeladat()
        {
            IReadOnlyList<Termek> termekek = [
                new ElektronikaiTermek("TV", "Smasnug", 69420),
                new ElektronikaiTermek("Bath bomb", "Toaster", 1337),
                new Ruhazat("Kabát", "Fekete", 12345),
                new ElektronikaiTermek("Laptop", "15 éves Lenovo Thinkpad", 1),
                new Ruhazat("Programozó zokni", "Rózsaszín csíkos", 0)
            ];
            termekek.ForEach(Console.WriteLine);
        }

        void HengerFeladat()
        {
            Henger henger = new Henger(
                FeltetellelBeker("Add meg a henger sugarát: ", "A kör sugara nem lehet kisebb 0-nál.", static (float sugar) => sugar >= 0),
                FeltetellelBeker("Add meg a henger magasságát: ", "A henger magassága nem hehet kisebb 0-nál", static (float magassag) => magassag >= 0)
            );
            Console.WriteLine(henger);
        }

        void AruFeladat()
        {
            List<IAru<Enum>> aruk = [];
            bool megBeker = true;
            while (megBeker)
            {
                char c = FeltetellelBeker("Italt, vagy gyümölcsöt akarsz megadni? (i/g) (ha nem akarsz többet megadni, írj \"*\"-ot): ", "Csak \"i\"-t, \"g\"-t, vagy \"*\"-ot lehet megadni.", static (char c) => c == 'i' || c == 'g' || c == '*');
                if (c != '*')
                {
                    
                }
            }
        }

        static string? Beker(string uzenet)
        {
            Console.Write(uzenet);
            return Console.ReadLine();
        }

        static T Beker<T>(string uzenet) where T : struct, IParsable<T>
        {
            T ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                Console.Write(uzenet);
                if (T.TryParse(Console.ReadLine(), null, out T value))
                {
                    ertek = value;
                    helyesErtek = true;
                }
                else
                {
                    Console.WriteLine($"Hiba! Csak {typeof(T).Name} típusú adatot lehet megadni.");
                }
            }
            return ertek;
        }

        static T FeltetellelBeker<T>(string uzenet, string hibaUzenet, Func<T, bool> feltetel) where T : struct, IParsable<T>
        {
            T ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                T esetlegesErtek = Beker<T>(uzenet);
                if (feltetel(esetlegesErtek))
                {
                    ertek = esetlegesErtek;
                    helyesErtek = true;
                }
                else
                {
                    Console.WriteLine("Hiba! " + hibaUzenet);
                }
            }
            return ertek;
        }
    }
}
