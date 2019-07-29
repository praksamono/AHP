using DAL;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {

        protected AHPContext context { get; private set; }

        public UnitOfWorkFactory(AHPContext context) {
            this.context = context;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(context);
        }
    }
}
