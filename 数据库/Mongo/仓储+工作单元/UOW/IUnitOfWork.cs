using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UOW
{
    public interface IUnitOfWork
    {
        public void Commit();
        public void Rollback();
        public void Transaction();
    }
}
