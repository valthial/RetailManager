using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Models
{
    public class ProductModel
    {
        
        /// <summary>
        /// The unique identifier for a given product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the product that we are saling.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The price of the product.
        /// </summary>
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// The number of the available products that are in the stock.
        /// </summary>
        public int QuantityInStock { get; set; }
 
    }
}
