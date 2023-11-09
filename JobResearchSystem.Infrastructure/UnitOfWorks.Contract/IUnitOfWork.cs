using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Infrastructure.UnitOfWorks.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<int> Complete();
    }
}
