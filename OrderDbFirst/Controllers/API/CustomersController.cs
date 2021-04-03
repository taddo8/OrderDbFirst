using OrderDbFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace OrderDbFirst.Controllers.API
{
    public class CustomersController : ApiController
    {
        private OrderDBEntities _context;

        public CustomersController()
        {
            _context = new OrderDBEntities();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.CustomerID == id);

            return Ok(customers);
        }

        [HttpPost]
        public IHttpActionResult GetCustomer(Customer customer)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.CustomerID == customer.CustomerID);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok();
        }


    }
}
