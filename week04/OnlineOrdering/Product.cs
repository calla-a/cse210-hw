using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Product
    {
        private string _productName;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product (string productName, string productId, double price, int quantity)
        {
            _productName = productName;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public double GetTotal()
        {
            double total = _price * _quantity;
            return total;
        }

        public string GetProductName()
        {
            return _productName;

        }
        public string GetProductId()
        {
            return _productId;
        }
    }
}