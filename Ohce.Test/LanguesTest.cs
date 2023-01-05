using Ohce.Langues;

namespace Ohce.Test
{
    public class LanguesTest
    {
        public static readonly IEnumerable<object[]> CasTestSalutation = new[]
        {
            new object[] { new LangueFrançaise(), PériodeJournée.Soir, Expressions.Bonsoir },
            new object[] { new LangueAnglaise(), PériodeJournée.Soir, Expressions.GoodEvening },
            new object[] { new LangueFrançaise(), PériodeJournée.Matin, Expressions.Bonjour },
            new object[] { new LangueAnglaise(), PériodeJournée.Matin, Expressions.GoodMorning },
            new object[] { new LangueFrançaise(), PériodeJournée.AprésMidi, Expressions.Bonjour },
            new object[] { new LangueAnglaise(), PériodeJournée.AprésMidi, Expressions.GoodAfternoon },
            new object[] { new LangueFrançaise(), PériodeJournée.Nuit, Expressions.Bonsoir },
            new object[] { new LangueAnglaise(), PériodeJournée.Nuit, Expressions.GoodEvening },
        };

        [Theory]
        [MemberData(nameof(CasTestSalutation))]
        public void TestSalutation(ILangue langue, PériodeJournée période, string salutationAttendue)
        {
            // ETANT DONNE la langue <langue>
            // ET que nous sommes <période>
            // QUAND on salue
            var salutation = langue.Saluer(période);

            // ALORS on obtient <salutationAttendue>
            Assert.Equal(salutationAttendue, salutation);
        }
    }
}
