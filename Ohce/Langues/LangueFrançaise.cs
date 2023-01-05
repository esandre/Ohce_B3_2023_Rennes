namespace Ohce.Langues
{
    public class LangueFrançaise : ILangue
    {
        /// <inheritdoc />
        public string Félicitations => Expressions.BienDit;

        /// <inheritdoc />
        public string Salutation => Expressions.Bonjour;

        /// <inheritdoc />
        public string Acquittance => Expressions.AuRevoir;
    }
}
