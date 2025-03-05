namespace Orai_0305
{
    internal abstract class Aru<TMertekegyseg>(string nev, TMertekegyseg mertekegyseg, float mennyiseg, int ar) : IAru<TMertekegyseg> where TMertekegyseg : struct, Enum
    {
        public string nev { get; } = nev;
        public TMertekegyseg mertekegyseg { get; } = mertekegyseg;
        float mennyiseg { get; } = mennyiseg;
        public int ar { get; } = ar;

        protected static IReadOnlyList<TMertekegyseg> Mertekegysegek => Enum.GetValues<TMertekegyseg>();

        public override string ToString() => $"Név: {nev}, Mennyiség: {mennyiseg + mertekegyseg.ToString()}, Ár: {ar}";
    }
}
