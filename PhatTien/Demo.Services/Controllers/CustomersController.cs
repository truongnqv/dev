using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.Entities;

namespace Demo.Services.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllCustomer(bool Deleted = false)
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                switch (Deleted)
                {
                    case false:
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Customers.ToList());
                    case true:
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Customers.Where(e => e.Deleted == true).ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for Deleted must be True, False. " + Deleted + " is invalid.");
                }

            }
        }

        [HttpGet]
        public HttpResponseMessage GetCustomerById(Guid id)
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                var entity =  entities.Customers.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with ID = " + id.ToString() + " not found.");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateCustomer([FromBody] IEnumerable<Customer> customers)
        {
            try
            {
                using (CustomerEntities entities = new CustomerEntities())
                {
                    foreach (Customer cus in customers)
                    {
                        cus.Id = Guid.NewGuid();
                        cus.CreatedDate = DateTime.Now;
                        cus.LastModified = DateTime.Now;
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

        [HttpPut]
        public HttpResponseMessage UpdateCustomerById(Guid id, [FromBody] Customer customer)
        {
            try
            {
                using (CustomerEntities entities = new CustomerEntities())
                {
                    var entity = entities.Customers.FirstOrDefault(e => e.Id == id);
                    if (entity != null)
                    {
                        entity.Name = customer.Name;
                        entity.Phone = customer.Phone;
                        entity.Vehicle = customer.Vehicle;
                        entity.VehiclePlate = customer.VehiclePlate;
                        entity.Deleted = customer.Deleted;
                        entity.LastModified = DateTime.Now;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with ID = " + id.ToString() + " not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage RemoveCustomerById(Guid id)
        {
            try
            {
                using (CustomerEntities entities = new CustomerEntities())
                {
                    var entity = entities.Customers.FirstOrDefault(e => e.Id == id);
                    if (entity != null)
                    {
                        entities.Customers.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with ID = " + id.ToString() + " not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
