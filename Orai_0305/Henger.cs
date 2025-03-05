namespace Orai_0305
{
    internal class Henger(float sugar, float magassag) : Kor(sugar)
    {
        public float magassag { get; } = magassag >= 0 ? magassag : throw new ArgumentException("A henger magassága nem lehet kisebb 0-nál.");

        public override float Kerulet => throw new NotSupportedException();

        public override float Terulet => throw new NotSupportedException();

        public float Felszin => base.Terulet * 2 + base.Kerulet * magassag;

        public float Terfogat => base.Terulet * magassag;

        public override string ToString() => $"Sugár: {sugar}, Felszín: {Felszin}, Térfogat: {Terfogat}";
    }
}
