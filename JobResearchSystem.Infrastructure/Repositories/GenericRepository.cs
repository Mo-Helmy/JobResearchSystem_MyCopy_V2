using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Database;
using JobResearchSystem.Infrastructure.Repositories.Contract;
using JobResearchSystem.Infrastructure.Specifications;
using JobResearchSystem.Infrastructure.Specifications.Contract;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JobResearchSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Query Methods
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbContext.Set<T>();

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T?> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
        #endregion

        #region Command Methods
        public async Task<T?> CreateAsync(T entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.IsDeleted = false;

            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<T?> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity is null) return null;

            entity.IsDeleted = true;
            entity.DateDeleted = DateTime.Now;

            return entity;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            var currentEntity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (currentEntity is null) return null;

            entity.DateCreated = currentEntity.DateCreated;

            UpdateObject(currentEntity, entity);

            currentEntity.DateUpdated = DateTime.Now;

            //_dbContext.Entry(entity).State = EntityState.Modified;

            return currentEntity;
        }

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
                    targetProperty.SetValue(target, value, null);
                }
            }
        }

        #endregion


    }
}
