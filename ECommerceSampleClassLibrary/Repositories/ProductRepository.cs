using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Context;

namespace ECommerceSampleClassLibrary.Repositories
{

   
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ProductCategory entity)
        {
            //ProductCategoryRepository<ProductCategory> _tempRepo = new ProductCategoryRepository<ProductCategory>(new AppDbContext());
            //entity.Category = _tempRepo.Get(new Guid("9b119a33-e9c9-4d2a-b2db-a1563765bf31"));
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ProductCategory> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        public void Delete(ProductCategory entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<ProductCategory> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        public ProductCategory Get(Guid id)
        {
            return _context.Find<ProductCategory>(id);
        }

        public List<ProductCategory> GetAll(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<ProductCategory> entities)
        {
            _context.UpdateRange(entities);
            _context.SaveChanges();
        }

    }
}
