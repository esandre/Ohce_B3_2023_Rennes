using System.ComponentModel;

namespace Ohce.Test;

[TestClass]
public class PalindromeTest
{
    [TestMethod("QUAND on saisit une chaîne " +
                "ALORS celle-ci est renvoyée en miroir")]
    public void TestMiroir()
    {
        // QUAND on saisit une chaîne
        const string chaîne = "toto";
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS celle-ci est renvoyée en miroir
        const string miroir = "otot";
        StringAssert.Contains(résultat, miroir);
    }

    [DataTestMethod()]
    [DisplayName("QUAND on saisit un palindrome " +
                 "ALORS celui-ci est renvoyé " +
                 "ET « Bien dit » est envoyé ensuite")]
    [DataRow("Radar")]
    [DataRow("radar")]
    public void TestPalindrome(string palindrome)
    {
        // QUAND on saisit un palindrome
        var résultat = DétectionPalindrome.Traiter(palindrome);

        // ALORS celui-ci est renvoyé
        StringAssert.Contains(résultat, palindrome, StringComparison.CurrentCultureIgnoreCase);

        var endOfPalindrome = résultat.IndexOf(palindrome, StringComparison.CurrentCultureIgnoreCase) 
                              + palindrome.Length;

        var résultatAprèsBienDit = résultat[endOfPalindrome..];

        // ET « Bien dit » est envoyé ensuite
        StringAssert.StartsWith(résultatAprèsBienDit, Expressions.BienDit);
    }

    [DataTestMethod()]
    [DisplayName("QUAND on saisit une chaîne " +
                        "ALORS « Bonjour » est envoyé avant toute réponse")]
    [DataRow("")]
    [DataRow("radar")]
    [DataRow("toto")]
    public void TestBonjour(string chaîneTestée)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîneTestée);

        // ALORS « Bonjour » est envoyé avant toute réponse
        StringAssert.StartsWith(résultat, Expressions.Bonjour);
    }

    [DataTestMethod]
    [DisplayName("QUAND on saisit une chaîne " +
                 "ALORS « Au revoir » est envoyé en dernier")]
    [DataRow("")]
    [DataRow("radar")]
    [DataRow("toto")]
    public void TestAuRevoir(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS « Au revoir » est envoyé en dernier
        StringAssert.EndsWith(résultat, Expressions.AuRevoir);
    }
}