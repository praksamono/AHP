namespace DAL
{
    public class Criterium
    {
        public int CriteriumId { get; set; }

        public string CriteriumName { get; set; }


        public string DateCreated { get; set; }

        public string DateUpdated { get; set; }

        public Goal goal { get; set; }
    }
}