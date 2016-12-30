using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerDataAccess;

namespace CustomerService.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                return entities.Customers.ToList();
            }
        }

        public Customer Get(Guid id)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                return entities.Customers.FirstOrDefault(e => e.Id == id);
            }
        }

        public void Post([FromBody]Customer customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                entities.Customers.Add(Cu);
                entities.SaveChanges();
            }
        }

        
    }
}
