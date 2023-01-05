using Ohce.Langues;

namespace Ohce.Test.Utilities
{
    internal class DétectionPalindromeBuilder
    {
        public static DétectionPalindrome Default 
            => new DétectionPalindromeBuilder().Build();

        private ILangue _langue = new LangueFrançaise();

        public DétectionPalindrome Build()
        {
            return new DétectionPalindrome(_langue);
        }

        public DétectionPalindromeBuilder AyantPourLangue(ILangue langue)
        {
            _langue = langue;
            return this;
        }
    }
}
