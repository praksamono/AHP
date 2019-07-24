using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Alternative : IAlternative
    {
        public Guid AlternativeId { get; set; }

        public string AlternativeName { get; set; }

        [Range(minimum: -9.0, maximum: 9.0)]
        public float GlobalPriority { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public Goal goal { get; set; }

        public List<ICriteriumAlternative> criteriumAlternatives { get; set; }


        public Alternative(string name, float x)
        {
            this.AlternativeId = new Guid();
            this.AlternativeName = name;
            this.GlobalPriority = x;
        }

    }
}