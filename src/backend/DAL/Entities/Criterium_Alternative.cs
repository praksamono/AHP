using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Criterium_Alternative
    {
        [Key]
        public int CriteriumId { get; set; }

        public Criterium criterium { get; set; }

        [Key]
        public int AlternativeId { get; set; }

        public Alternative alternative { get; set; }

        public float LocalPriority { get; set; }
    }
}