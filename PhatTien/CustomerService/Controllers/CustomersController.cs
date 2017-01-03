using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerRepository;

namespace CustomerService.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                return entities.Customers.ToList();
            }
        }

        public Customer Get(Guid id)
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                return entities.Customers.FirstOrDefault(e => e.Id == id);
            }
        }

        public HttpResponseMessage Post([FromBody] IEnumerable<Customer> customers)
        {
            try
            {
                using (CustomerEntities entities = new CustomerEntities())
                {
                    foreach (Customer cus in customers)
                    {
                        cus.Id = Guid.NewGuid();
                    }
                   
                    entities.Customers.AddRange(customers);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, customers);
                    foreach (Customer cus in customers)
                    {
                        message.Headers.Location = new Uri(Request.RequestUri +
                        cus.Id.ToString());
                    }

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
