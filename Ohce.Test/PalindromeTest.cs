using Ohce.Langues;
using Ohce.Test.Utilities;

namespace Ohce.Test;

public class PalindromeTest
{
    private static readonly string[] PalindromeAvecEtSansMajuscule = new[] { "Radar", "radar" };

    private static readonly ILangue[] LanguesTestées
        = new ILangue[] { new LangueFrançaise(), new LangueAnglaise() };

    private static readonly string[] ChaînesTestéesSalutation = { string.Empty, "radar", "toto" };

    [Fact(DisplayName = "QUAND on saisit une chaîne " +
                        "ALORS celle-ci est renvoyée en miroir")]
    public void TestMiroir()
    {
        // QUAND on saisit une chaîne
        const string chaîne = "toto";
        var résultat = DétectionPalindrome.Traiter(chaîne);

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
        var détection = new DétectionPalindrome(langue);

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
        => new CartesianData(ChaînesTestéesSalutation, LanguesTestées);

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant <langue> " +
                          "QUAND on saisit une chaîne " +
                        "ALORS la salutation de cette langue est envoyée avant toute réponse")]
    [MemberData(nameof(CasTestBonjour))]
    public void TestBonjour(string chaîneTestée, ILangue langue)
    {
        // ETANT DONNE un utilisateur parlant <langue>
        var détectionPalindrom = new DétectionPalindrome(langue);

        // QUAND on saisit une chaîne
        var résultat = détectionPalindrom.TraiterChaîne(chaîneTestée);

        // ALORS la salutation de cette langue est envoyée avant toute réponse
        Assert.StartsWith(langue.Salutation, résultat);
    }

    [Theory(DisplayName = "QUAND on saisit une chaîne " +
                        "ALORS « Au revoir » est envoyé en dernier")]
    [InlineData("")]
    [InlineData("radar")]
    [InlineData("toto")]
    public void TestAuRevoir(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS « Au revoir » est envoyé en dernier
        Assert.EndsWith(Expressions.AuRevoir, résultat);
    }
}