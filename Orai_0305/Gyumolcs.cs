namespace Orai_0305
{
    enum TomegMertekegyseg : byte
    {
        g,
        kg
    }

    internal class Gyumolcs(string nev, TomegMertekegyseg mertekegyseg, float mennyiseg, int ar, bool friss) : Aru<TomegMertekegyseg>(nev, mertekegyseg, mennyiseg, ar)
    {
        public bool friss { get; set; } = friss;

        public override string ToString() => base.ToString() + $", {(friss ? "Friss" : "Nem friss")}";
    }
}
