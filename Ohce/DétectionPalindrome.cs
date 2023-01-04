using System.Text;

namespace Ohce;

public static class DétectionPalindrome
{
    public static string Traiter(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        var builder = new StringBuilder(Expressions.Bonjour);

        builder.Append(miroir);
        if (miroir.Equals(chaîne, StringComparison.CurrentCultureIgnoreCase))
            builder.Append(Expressions.BienDit);

        builder.Append(Expressions.AuRevoir);

        return builder.ToString();
    }
}