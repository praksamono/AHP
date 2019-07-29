using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
