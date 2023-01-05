using System.Text;
using Ohce.Langues;

namespace Ohce;

public class DétectionPalindrome
{
    private readonly string _félicitations;

    public DétectionPalindrome(ILangue langue)
    {
        _félicitations = langue.Félicitations;
    }

    public static string Traiter(string chaîne) 
        => new DétectionPalindrome(new LangueFrançaise()).TraiterChaîne(chaîne);

    public string TraiterChaîne(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        var builder = new StringBuilder(Expressions.Bonjour);

        builder.Append(miroir);
        if (miroir.Equals(chaîne, StringComparison.CurrentCultureIgnoreCase))
            builder.Append(_félicitations);

        builder.Append(Expressions.AuRevoir);

        return builder.ToString();
    }
}