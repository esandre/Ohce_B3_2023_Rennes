namespace Ohce.Test;

public class PalindromeTest
{
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

    [Theory(DisplayName = "QUAND on saisit un palindrome " +
                        "ALORS celui-ci est renvoyé " +
                        "ET « Bien dit » est envoyé ensuite")]
    [InlineData("Radar")]
    [InlineData("radar")]
    public void TestPalindrome(string palindrome)
    {
        // QUAND on saisit un palindrome
        var résultat = DétectionPalindrome.Traiter(palindrome);

        // ALORS celui-ci est renvoyé
        Assert.Contains(palindrome, résultat, StringComparison.CurrentCultureIgnoreCase);

        var endOfPalindrome = résultat.IndexOf(palindrome, StringComparison.CurrentCultureIgnoreCase) 
                              + palindrome.Length;

        var résultatAprèsBienDit = résultat[endOfPalindrome..];

        // ET « Bien dit » est envoyé ensuite
        Assert.StartsWith(Expressions.BienDit, résultatAprèsBienDit);
    }

    [Theory(DisplayName = "QUAND on saisit une chaîne " +
                        "ALORS « Bonjour » est envoyé avant toute réponse")]
    [InlineData("")]
    [InlineData("radar")]
    [InlineData("toto")]
    public void TestBonjour(string chaîneTestée)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîneTestée);

        // ALORS « Bonjour » est envoyé avant toute réponse
        Assert.StartsWith(Expressions.Bonjour, résultat);
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