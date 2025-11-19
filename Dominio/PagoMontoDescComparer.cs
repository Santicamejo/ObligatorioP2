using Dominio;

public class PagoMontoDescComparer : IComparer<Pago>
{
    public int Compare(Pago? x, Pago? y)
    {
        return x.Monto.CompareTo(y.Monto) * -1;
    }
}
