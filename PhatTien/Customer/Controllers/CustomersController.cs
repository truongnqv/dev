using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomersDataAccess;

namespace Customer.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            using (PhatTienEntities entities  = new PhatTienEntities())
            {
                return null;
            }
        }
    }
}
