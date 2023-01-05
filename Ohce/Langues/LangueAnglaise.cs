namespace Ohce.Langues
{
    public class LangueAnglaise : ILangue
    {
        /// <inheritdoc />
        public string Félicitations => Expressions.WellSaid;

        /// <inheritdoc />
        public string Salutation => Expressions.Hello;

        /// <inheritdoc />
        public string Acquittance => Expressions.Goodbye;
    }
}
