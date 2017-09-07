using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// CRUD methods for product domain model
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// All Products.
        /// </summary>
        IEnumerable<Product> Products { get; }

        /// <summary>
        /// Save product
        /// </summary>
        /// <param name="product">product</param>
        void SaveProduct(Product product);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="productId">product id</param>
        /// <returns>deleted product (founded by id). May be null.</returns>
        Product DeleteProduct(int productId);
    }
}
