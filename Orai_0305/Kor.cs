namespace Orai_0305
{
    internal class Kor(float sugar)
    {
        public float sugar { get; } = sugar >= 0 ? sugar : throw new ArgumentException("A kör sugara nem lehet kisebb 0-nál.");

        public virtual float Kerulet => 2 * sugar * MathF.PI;

        public virtual float Terulet => sugar * sugar * MathF.PI;

        public override string ToString() => $"Sugár: {sugar}, Kerület: {Kerulet}, Terület: {Terulet}";
    }
}
