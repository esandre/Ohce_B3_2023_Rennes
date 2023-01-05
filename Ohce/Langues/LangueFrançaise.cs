namespace Ohce.Langues
{
    public class LangueFrançaise : ILangue
    {
        /// <inheritdoc />
        public string Félicitations => Expressions.BienDit;

        /// <inheritdoc />
        public string Saluer(PériodeJournée période)
        {
            if (période == PériodeJournée.Soir || période == PériodeJournée.Nuit) 
                return Expressions.Bonsoir;
            return Expressions.Bonjour;
        }

        /// <inheritdoc />
        public string Acquittance => Expressions.AuRevoir;
    }
}
