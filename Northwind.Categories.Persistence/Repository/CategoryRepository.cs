using Microsoft.EntityFrameworkCore;
using Northwind.Categories.Domain.Interface;
using Northwind.Categories.Domain.Entities;
using Northwind.Categories.Persistence.Context;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace Northwind.Categories.Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(NorthwindContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Exists(Expression<Func<Category, bool>> filter)
        {
            return _context.Categories.Any(filter);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetEntityBy(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);

                if (category == null)
                    throw new InvalidOperationException("Category not found.");

                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error obtaining the category.", ex);
                throw;
            }
        }

        public void Remove(Category entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity category cannot be null.");

                var categoryToRemove = _context.Categories.Find(entity.CategoryID);

                if (categoryToRemove == null)
                    throw new InvalidOperationException("The category you want to delete is not found.");

                _context.Categories.Remove(categoryToRemove);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Concurrency conflict: The entity was modified or deleted by another process.", ex);
                throw new InvalidOperationException("Concurrency conflict: The entity was modified or deleted by another process.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error removing the category.", ex);
                throw;
            }
        }

        public void Save(Category entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity category cannot be null.");

                if (Exists(c => c.CategoryID == entity.CategoryID))
                    throw new InvalidOperationException("The category is already registered.");

                _context.Categories.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError("Error adding the category: {0}", dbEx.InnerException?.Message ?? dbEx.Message);
                if (dbEx.InnerException != null)
                {
                    _logger.LogError("Inner exception: {0}", dbEx.InnerException.ToString());
                }
                throw new InvalidOperationException("An error occurred while saving the category. See the inner exception for details.", dbEx);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding the category.", ex);
                throw;
            }
        }

        public void Update(Category entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity category cannot be null.");

                var categoryToUpdate = _context.Categories.Find(entity.CategoryID);

                if (categoryToUpdate == null)
                    throw new InvalidOperationException("The category you want to update is not found.");

                categoryToUpdate.CategoryName = entity.CategoryName;
                categoryToUpdate.Description = entity.Description;
                categoryToUpdate.Picture = entity.Picture;

                _context.Entry(categoryToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating the category.", ex);
                throw;
            }
        }
    }
}
