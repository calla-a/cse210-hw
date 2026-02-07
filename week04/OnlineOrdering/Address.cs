using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;

        // public Address (string street, string city, string state, string country)
        // {
        //     _street = street;
        //     _city = city;
        //     _state = state;
        //     _country = country;
        // }

        public void SetAddress(string street, string city, string state, string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _country = country;
        }

        public bool LiveInUS()
        {
            if ((_country == "USA") || (_country == "US") || (_country == "United States"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetAddress()
        {
            string fullAddress = $"{_street}, {_city}, {_state}, {_country}";
            return fullAddress;
        }
    }
}