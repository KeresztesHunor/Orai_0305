namespace Orai_0305
{
    enum FolyadekMertekegyseg : byte
    {
        l,
        dl
    }

    internal class Ital(string nev, FolyadekMertekegyseg mertekegyseg, float mennyiseg, int ar, float gyumolcsTartalom) : Aru<FolyadekMertekegyseg>(nev, mertekegyseg, mennyiseg, ar)
    {
        public float gyumolcsTartalom { get; } = gyumolcsTartalom;

        public override string ToString() => base.ToString() + $", Gyümölcstartalom: {gyumolcsTartalom * 100}%";
    }
}
