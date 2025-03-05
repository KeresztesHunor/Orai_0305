namespace Orai_0305
{
    internal class Ruhazat(string nev, string szin, int beszerzesiAr) : Termek(nev, beszerzesiAr)
    {
        public string szin { get; } = szin;

        protected override float alapArSzorzo => 1.1f;

        public override float Kedvezmeny => 0.2f;

        public override string ToString() => base.ToString() + $", Szín {szin}";
    }
}
