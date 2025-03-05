namespace Orai_0305
{
    internal abstract class Termek(string nev, int beszerzesiAr)
    {
        public string nev { get; } = nev;
        public int beszerzesiAr { get; set; } = beszerzesiAr;

        public int EladasiAr => (int)MathF.Round(beszerzesiAr * alapArSzorzo);

        public int Haszon => (int)MathF.Round(EladasiAr * (1 - Kedvezmeny) - beszerzesiAr);

        protected virtual float alapArSzorzo => 1;

        public virtual float Kedvezmeny => 0;

        public override string ToString() => $"Név: {nev}, Beszerzési ár: {beszerzesiAr}, Eladási ár: {EladasiAr}, Kedvezmény: {Kedvezmeny * 100}%, Haszon: {Haszon}";
    }
}
