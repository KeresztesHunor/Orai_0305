namespace Orai_0305
{
    internal class ElektronikaiTermek(string nev, string tipus, int beszerzesiAr) : Termek(nev, beszerzesiAr)
    {
        public string tipus { get; } = tipus;

        protected override float alapArSzorzo => 1.2f;

        public override float Kedvezmeny => 0.1f;

        public override string ToString() => base.ToString() + $", Típus: {tipus}";
    }
}
