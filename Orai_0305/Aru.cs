namespace Orai_0305
{
    internal interface IAru
    {
        string nev { get; }
        string Mertekegyseg { get; }
        float mennyiseg { get; }
        int ar { get; }
    }

    internal abstract class Aru<TMertekegyseg>(string nev, TMertekegyseg mertekegyseg, float mennyiseg, int ar) : IAru where TMertekegyseg : struct, Enum
    {
        public string nev { get; } = nev;
        public TMertekegyseg mertekegyseg { get; } = mertekegyseg;
        public string Mertekegyseg => mertekegyseg.ToString();
        public float mennyiseg { get; } = mennyiseg;
        public int ar { get; } = ar;

        public override string ToString() => $"Név: {nev}, Mennyiség: {mennyiseg + Mertekegyseg}, Ár: {ar}";
    }
}
