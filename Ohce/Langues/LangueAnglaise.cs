namespace Ohce.Langues
{
    public class LangueAnglaise : ILangue
    {
        /// <inheritdoc />
        public string Félicitations => Expressions.WellSaid;

        /// <inheritdoc />
        public string Saluer(PériodeJournée période)
        {
            if (période == PériodeJournée.Nuit) 
                return Expressions.GoodEvening;

            if (période == PériodeJournée.Soir) 
                return Expressions.GoodEvening;

            if (période == PériodeJournée.Matin) 
                return Expressions.GoodMorning;

            if (période == PériodeJournée.AprésMidi) 
                return Expressions.GoodAfternoon;

            return Expressions.Hello;
        }

        /// <inheritdoc />
        public string Acquittance => Expressions.Goodbye;
    }
}
