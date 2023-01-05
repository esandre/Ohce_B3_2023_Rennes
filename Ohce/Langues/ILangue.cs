namespace Ohce.Langues
{
    public interface ILangue
    {
        string Félicitations { get; }
        string Saluer(PériodeJournée période);
        string Acquittance { get; }
    }
}
