using System.Numerics;
using System.Reflection;

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
            List<IAru> aruk = [];
            bool megBeker = true;
            while (megBeker)
            {
                char c = FeltetellelBeker("Italt, vagy gyümölcsöt akarsz megadni? (i/g) (ha nem akarsz többet megadni, írj \"*\"-ot): ", "Csak \"i\"-t, \"g\"-t, vagy \"*\"-ot lehet megadni.", static (char c) => (stackalloc char[] { 'i', 'g', '*' }).Contains(char.ToLower(c)));
                if (c != '*')
                {
                    aruk.Add(c switch {
                        'i' => new Ital(
                            Beker("Add meg az ital nevét: ") ?? "-",
                            EnumErteketBeker<FolyadekMertekegyseg>($"Add meg a mennyiség mértékegységét ({string.Join('/', Enum.GetNames<FolyadekMertekegyseg>())}): "),
                            Beker<float>("Add meg a mennyiséget: "),
                            Beker<int>("Add meg az ital árát: "),
                            Beker<float>("Add meg a gyümölcstartalmát: ")
                        ),
                        'g' => new Gyumolcs(
                            Beker("Add meg a gyümölcs nevét: ") ?? "-",
                            EnumErteketBeker<TomegMertekegyseg>($"Add meg a mennyiség mértékegységét ({string.Join('/', Enum.GetNames<TomegMertekegyseg>())}): "),
                            Beker<float>("Add meg a mennyiségét: "),
                            Beker<int>("Add meg a gyümölcs árát: "),
                            FeltetellelBeker("Add meg, hogy friss-e a gyümölcs (i/n): ", "Csak 'i'-t, vagy 'n'-t lehet megadni.", static (char c) => (stackalloc char[] { 'i', 'n' }).Contains(char.ToLower(c))) == 'i'
                        ),
                        _ => throw new Exception("bruh")
                    });
                }
                else
                {
                    megBeker = false;
                }
            }
            aruk.ForEach(Console.WriteLine);
        }

        static string? Beker(string uzenet)
        {
            Console.Write(uzenet);
            return Console.ReadLine();
        }

        static T EnumErteketBeker<T>(string uzenet) where T : struct, Enum => Beker(uzenet, $"Csak az alábbi értékekből lehet választani:\n" + string.Join('\n', Enum.GetValues<T>().Select(static (T ertek) => Convert.ChangeType(ertek, typeof(T).GetEnumUnderlyingType()).ToString() + ": " + ertek.ToString())), static (string? s, out T result) => Enum.TryParse(s, true, out result) && Enum.IsDefined(result));

        static T Beker<T>(string uzenet) where T : struct, IParsable<T> => Beker(uzenet, $"Csak {typeof(T).Name} típusú adatot lehet megadni.", static (string? s, out T result) => T.TryParse(s, null, out result));

        static T Beker<T>(string uzenet, string hibaUzenet, Parser<T> parser) where T : struct
        {
            T ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                Console.Write(uzenet);
                if (parser(Console.ReadLine(), out ertek))
                {
                    helyesErtek = true;
                }
                else
                {
                    Console.WriteLine($"Hiba! " + hibaUzenet);
                }
            }
            return ertek;
        }

        delegate bool Parser<T>(string? s, out T result);

        static T FeltetellelBeker<T>(string uzenet, string hibaUzenet, Func<T, bool> feltetel) where T : struct, IParsable<T>
        {
            T ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                ertek = Beker<T>(uzenet);
                if (feltetel(ertek))
                {
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
