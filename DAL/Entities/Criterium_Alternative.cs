namespace DAL
{
    public class Criterium_Alternative
    {

        public int CriteriumId { get; set; }

        public Criterium criterium { get; set; }

        public int AlternativeId { get; set; }

        public Alternative alternative { get; set; }

    }
}