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
    
    public string TraiterChaîne(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        var builder = new StringBuilder(_langue.Salutation);

        builder.Append(miroir);
        if (miroir.Equals(chaîne, StringComparison.CurrentCultureIgnoreCase))
            builder.Append(_langue.Félicitations);

        builder.Append(_langue.Acquittance);

        return builder.ToString();
    }
}