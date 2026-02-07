using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Customer
    {
        private string _customerName;
        private Address _customerAddress = new Address();

        public void SetCustomer(string customerName, string street, string city, string state, string country)
        {
            _customerName = customerName;
            _customerAddress.SetAddress(street, city, state, country);
        }

        public bool LiveInUS()
        {
            return _customerAddress.LiveInUS();
        }

        public string GetCustomerName()
        {
            return _customerName;
        }

        public string GetCustomerAddress()
        {
            return _customerAddress.GetAddress();
        }
    }
}