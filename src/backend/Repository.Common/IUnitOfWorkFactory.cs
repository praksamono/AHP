using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();

    }
}
