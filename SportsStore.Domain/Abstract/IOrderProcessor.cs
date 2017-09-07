using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// This interface contains functions of order processing.
    /// </summary>
    public interface IOrderProcessor
    {
        /// <summary>
        /// Process Order.
        /// </summary>
        /// <param name="cart">Cart.</param>
        /// <param name="shippingDetails">Shipping Details</param>
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
