using Ohce.Langues;

namespace Ohce.Test.Utilities
{
    internal class DetectionPalindromeGenerator
    {
        private DétectionPalindromeBuilder _prototypeBuilder = new ();

        public IEnumerable<DétectionPalindrome> Generate(int nb)
        {
            for (var i = 0; i < nb; i++)
            {
                yield return _prototypeBuilder.Build();
            }
        }

        public DetectionPalindromeGenerator AyantPourLangue(ILangue langue)
        {
            _prototypeBuilder = _prototypeBuilder.AyantPourLangue(langue);
            return this;
        }
    }
}
