using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete.Repository
{
    /// <summary>
    /// This EF implementation of <see cref="IProductsRepository"/> 
    /// </summary>
    public class EFProductRepository : IProductsRepository
    {
        /// <summary>
        /// EF context
        /// </summary>
        private readonly EFDbContext _context = new EFDbContext();

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<Product> Products
        {
            get { return _context.Products; }
        }

        /// <summary>
        /// Add or update product.
        /// </summary>
        /// <param name="product">Product</param>
        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _context.Products.Add(product);
            } else
            {
                Product dbEntry = _context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a product if it is founded
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product DeleteProduct(int productId)
        {
            Product dbEntry = _context.Products.Find(productId);
            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
