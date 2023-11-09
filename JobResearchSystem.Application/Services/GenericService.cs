using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Repositories.Contract;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;
using System.Linq.Expressions;

namespace JobResearchSystem.Application.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
            return entityList;
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            return entity; 
        }

        public virtual async Task<TEntity?> CreateAsync(TEntity entity)
        {
            await _unitOfWork.GetRepository<TEntity>().CreateAsync(entity);

            var count = await _unitOfWork.Complete();

            return count > 0 ? entity : null;
        }

        public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            var updatedEntity = await _unitOfWork.GetRepository<TEntity>().UpdateAsync(entity);

            if(updatedEntity is null) return null;

            var count = await _unitOfWork.Complete();

            return count > 0 ? updatedEntity : null;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var deletedEntity = await _unitOfWork.GetRepository<TEntity>().DeleteAsync(id);

            if(deletedEntity is null) return false;

            var count = await _unitOfWork.Complete();

            return count > 0 ? true : false;
        }
    }
}
