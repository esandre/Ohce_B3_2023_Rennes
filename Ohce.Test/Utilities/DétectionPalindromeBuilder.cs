using Ohce.Langues;

namespace Ohce.Test.Utilities
{
    internal class DétectionPalindromeBuilder
    {
        public static DétectionPalindrome Default 
            => new DétectionPalindromeBuilder().Build();

        private ILangue _langue = new LangueStub();
        private PériodeJournée _période = PériodeJournée.Default;

        public DétectionPalindrome Build()
        {
            return new DétectionPalindrome(_langue, _période);
        }

        public DétectionPalindromeBuilder AyantPourLangue(ILangue langue)
        {
            _langue = langue;
            return this;
        }

        public DétectionPalindromeBuilder AyantPourPériodeDeLaJournée(PériodeJournée période)
        {
            _période = période;
            return this;
        }
    }
}
