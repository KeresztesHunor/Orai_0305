namespace Orai_0305
{
    internal interface IAru<out TMertekegyseg> where TMertekegyseg : Enum
    {
        TMertekegyseg mertekegyseg { get; }
    }
}
