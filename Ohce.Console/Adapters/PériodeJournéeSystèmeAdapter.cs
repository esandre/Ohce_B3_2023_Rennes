namespace Ohce.Console.Adapters
{
    internal static class PériodeJournéeSystèmeAdapter
    {
        public static PériodeJournée PériodeActuelle
            => DateTime.Now.Hour switch
               {
                   >= 18 => PériodeJournée.Soir,
                   >= 12 => PériodeJournée.AprésMidi,
                   >= 8  => PériodeJournée.Matin,
                   _     => PériodeJournée.Nuit
               };
    }
}
