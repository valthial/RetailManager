using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Models
{
    public class ProductDisplayModel : INotifyPropertyChanged
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
        private int _quantityInStock;

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set 
            {
                _quantityInStock = value;
                CallPropertyChanged(nameof(QuantityInStock));
            }
        }

        /// <summary>
        /// True means that the product in the cart is taxable 
        /// False for the not taxable products.
        /// </summary>
        public bool IsTaxable { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
