using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Repositories.Contract;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;
using System.Linq.Expressions;
using System.Reflection;

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

        public virtual async Task<TEntity?> UpdateAsync(int id, object updateCommand)
        {
            var currentEntity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);

            if (currentEntity is null) throw new KeyNotFoundException("Id Key Not Exist");

            currentEntity.DateUpdated = DateTime.Now;

            UpdateObject(currentEntity, updateCommand);

            var count = await _unitOfWork.Complete();

            return count > 0 ? currentEntity : null;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var deletedEntity = await _unitOfWork.GetRepository<TEntity>().DeleteAsync(id);

            if (deletedEntity is null) return false;

            var count = await _unitOfWork.Complete();

            return count > 0 ? true : false;
        }


        /// <summary>
        /// Update the target object from properties of the source object
        /// </summary>
        /// <param name="target">Current object need update.</param>
        /// <param name="source">New object that will update the target object.</param>
        private static void UpdateObject(object target, object source)
        {
            Type targetType = target.GetType();
            Type sourceType = source.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);
                if (targetProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType)
                {
                    object value = sourceProperty.GetValue(source, null);

                    if (value is not null) targetProperty.SetValue(target, value, null);
                }
            }
        }
    }
}
