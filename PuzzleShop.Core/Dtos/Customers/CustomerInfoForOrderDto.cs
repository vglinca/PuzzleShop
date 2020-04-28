using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Dtos.Customers
{
	public class CustomerInfoForOrderDto
	{
        public string ContactEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}
