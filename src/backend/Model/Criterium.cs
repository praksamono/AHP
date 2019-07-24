using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Criterium : ICriterium
    {
        public Guid CriteriumId { get; set; }

        public string CriteriumName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalCriteriumPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public Goal goal { get; set; }

        public List<ICriteriumAlternative> criteriumAlternative { get; set; }

        public Criterium(string name, float x) {
            this.CriteriumId = new Guid();
            this.CriteriumName = name;
            this.GlobalCriteriumPriority = x;
        }
    }
}