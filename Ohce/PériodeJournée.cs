namespace Ohce
{
    public class PériodeJournée
    {
        public static readonly PériodeJournée Default = new ();
        public static readonly PériodeJournée Soir = new ();
        public static readonly PériodeJournée Matin = new ();
        public static readonly PériodeJournée AprésMidi = new ();
        public static readonly PériodeJournée Nuit = new ();

        private PériodeJournée()
        {
        }
    }
}
