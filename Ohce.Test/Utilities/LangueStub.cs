using Ohce.Langues;

namespace Ohce.Test.Utilities
{
    internal class LangueStub : ILangue
    {
        /// <inheritdoc />
        public string Félicitations => string.Empty;

        /// <inheritdoc />
        public string Saluer(PériodeJournée période) => string.Empty;

        /// <inheritdoc />
        public string Acquittance => string.Empty;
    }
}
