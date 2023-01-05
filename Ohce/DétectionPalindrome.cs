using System.Text;
using Ohce.Langues;

namespace Ohce;

public class DétectionPalindrome
{
    private readonly ILangue _langue;

    public DétectionPalindrome(ILangue langue)
    {
        _langue = langue;
    }

    public static string Traiter(string chaîne) 
        => new DétectionPalindrome(new LangueFrançaise()).TraiterChaîne(chaîne);

    public string TraiterChaîne(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        var builder = new StringBuilder(_langue.Salutation);

        builder.Append(miroir);
        if (miroir.Equals(chaîne, StringComparison.CurrentCultureIgnoreCase))
            builder.Append(_langue.Félicitations);

        builder.Append(Expressions.AuRevoir);

        return builder.ToString();
    }
}