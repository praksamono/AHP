namespace DAL
{
    public class Alternative
    {
        public int AlternativeId { get; set; }

        public string AlternativeName { get; set; }


        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }

        public Goal goal { get; set; }
    }
}