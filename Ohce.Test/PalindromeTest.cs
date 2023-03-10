using Ohce.Langues;
using Ohce.Test.Utilities;

namespace Ohce.Test;

public class PalindromeTest
{
    private static readonly string[] PalindromeAvecEtSansMajuscule = new[] { "Radar", "radar" };

    private static readonly ILangue[] LanguesTestées
        = new ILangue[] { new LangueFrançaise(), new LangueAnglaise() };

    private static readonly PériodeJournée[] PériodesTestées
        = new PériodeJournée[]
        {
            PériodeJournée.Soir, 
            PériodeJournée.Matin, 
            PériodeJournée.AprésMidi, 
            PériodeJournée.Nuit
        };

    private static readonly string[] ChaînesTestéesSalutationAcquittance = { string.Empty, "radar", "toto" };

    [Fact(DisplayName = "QUAND on saisit une chaîne " +
                        "ALORS celle-ci est renvoyée en miroir")]
    public void TestMiroir()
    {
        // QUAND on saisit une chaîne
        const string chaîne = "toto";
        var résultat = DétectionPalindromeBuilder.Default.TraiterChaîne(chaîne);

        // ALORS celle-ci est renvoyée en miroir
        const string miroir = "otot";
        Assert.Contains(miroir, résultat);
    }

    public static IEnumerable<object[]> CasTestPalindrome
        => new CartesianData(PalindromeAvecEtSansMajuscule, LanguesTestées);

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant <langue> " +
                          "QUAND on saisit un palindrome " +
                          "ALORS celui-ci est renvoyé " +
                          "ET des félicitations en <langue> sont envoyées")]
    [MemberData(nameof(CasTestPalindrome))]
    public void TestPalindrome(string palindrome, ILangue langue)
    {
        // ETANT DONNE un utilisateur parlant <langue>
        var détection = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND on saisit un palindrome
        var résultat = détection.TraiterChaîne(palindrome);

        // ALORS celui-ci est renvoyé
        Assert.Contains(palindrome, résultat, StringComparison.CurrentCultureIgnoreCase);

        var endOfPalindrome = résultat.IndexOf(palindrome, StringComparison.CurrentCultureIgnoreCase) 
                              + palindrome.Length;

        var résultatAprèsBienDit = résultat[endOfPalindrome..];

        // ET des félicitations en <langue> sont envoyées
        Assert.StartsWith(langue.Félicitations, résultatAprèsBienDit);
    }

    public static IEnumerable<object[]> CasTestBonjour
        => new CartesianData(ChaînesTestéesSalutationAcquittance, LanguesTestées, PériodesTestées);

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant <langue> " +
                          "ET que la période de la journée est <periode> " +
                          "QUAND on saisit une chaîne " +
                          "ALORS la salutation de cette langue à ce moment de la journée " +
                          "est envoyée avant toute réponse")]
    [MemberData(nameof(CasTestBonjour))]
    public void TestBonjour(string chaîneTestée, ILangue langue, PériodeJournée période)
    {
        // ETANT DONNE un utilisateur parlant <langue>
        // ET que la période de la journée est <periode>

        var détection = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .AyantPourPériodeDeLaJournée(période)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = détection.TraiterChaîne(chaîneTestée);

        // ALORS la salutation de cette langue à ce moment de la journée est envoyée avant toute réponse
        Assert.StartsWith(langue.Saluer(période), résultat);
    }

    public static IEnumerable<object[]> CasTestAuRevoir
        => new CartesianData(ChaînesTestéesSalutationAcquittance, LanguesTestées);

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant <langue> " + 
                          "QUAND on saisit une chaîne " +
                          "ALORS l'acquittance en <langue> est envoyé en dernier")]
    [MemberData(nameof(CasTestAuRevoir))]
    public void TestAuRevoir(string chaîne, ILangue langue)
    {
        // ETANT DONNE un utilisateur parlant <langue>
        var détection = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = détection.TraiterChaîne(chaîne);

        // ALORS l'acquittance en <langue> est envoyé en dernier
        Assert.EndsWith(langue.Acquittance, résultat);
    }

}