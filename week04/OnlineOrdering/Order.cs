using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Order
    {
        private Customer _customer = new Customer();
        private List<Product> _products = new List<Product>();

        public double Total()
        {
            double total = 0;
            int shippingCost;

            foreach (Product product in _products)
            {
                total += product.GetTotal();
            }

            if (_customer.LiveInUS() == true)
            {
                shippingCost = 5;
            }
            else
            {
                shippingCost = 35;
            }
            total += shippingCost;

            return total;
        }

        public string PackingLabel()
        {
            string packingLabel = "";

            foreach (Product product in _products)
            {
                string productName = product.GetProductName();
                string productId = product.GetProductId();
                packingLabel += $"{productName} - {productId}\n";
            }

            return packingLabel;
        }

        public string ShippingLabel()
        {
            string customerName = _customer.GetCustomerName();
            string customerAddress = _customer.GetCustomerAddress();

            return $"{customerName}\n{customerAddress}";
        }

        public void AddCustomer(string customerName, string street, string city, string state, string country)
        {
            _customer.SetCustomer(customerName, street, city, state, country);
        }
        
        public void AddProduct(string productName, string productId, double price, int quantity)
        {
            Product product = new Product(productName, productId, price, quantity);
            _products.Add(product);
        }
    }
}