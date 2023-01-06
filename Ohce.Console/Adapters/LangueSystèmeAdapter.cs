using System.Globalization;
using Ohce.Langues;

namespace Ohce.Console.Adapters
{
    internal class LangueSystèmeAdapter : ILangue
    {
        private static readonly IDictionary<string, ILangue> LanguesDisponibles
            = new Dictionary<string, ILangue>
            {
                { "fr-FR", new LangueFrançaise() },
                { "en-GB", new LangueAnglaise() }
            };

        private readonly ILangue _langue;

        public LangueSystèmeAdapter()
        {
            var culture = CultureInfo.CurrentCulture;
            var cultureCode = culture.Name;

            if (LanguesDisponibles.ContainsKey(cultureCode))
                _langue = LanguesDisponibles[cultureCode];
            else _langue = new LangueFrançaise();
        }

        /// <inheritdoc />
        public string Félicitations => _langue.Félicitations;

        /// <inheritdoc />
        public string Saluer(PériodeJournée période) => _langue.Saluer(période);

        /// <inheritdoc />
        public string Acquittance => _langue.Acquittance;
    }
}
