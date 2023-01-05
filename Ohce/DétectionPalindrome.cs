using System.Text;
using Ohce.Langues;

namespace Ohce;

public class DétectionPalindrome
{
    private readonly ILangue _langue;
    private readonly PériodeJournée _période;

    public DétectionPalindrome(ILangue langue, PériodeJournée période)
    {
        _langue = langue;
        _période = période;
    }
    
    public string TraiterChaîne(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        var builder = new StringBuilder(_langue.Saluer(_période));

        builder.Append(miroir);
        if (miroir.Equals(chaîne, StringComparison.CurrentCultureIgnoreCase))
            builder.Append(_langue.Félicitations);

        builder.Append(_langue.Acquittance);

        return builder.ToString();
    }
}