using ASP.NETWebApi_Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ASP.NETWebApi_Samples.Controllers
{
    public class CustomerController : ApiController
    {
        //api/customers
        [HttpGet]
        [ResponseType(typeof(IList<Customer>))]
        public async Task<IHttpActionResult> Get()
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id = new Guid("fa2c0554-e2c6-41df-90a2-a537ca68dcdb"),
                Name = "Lukas James"
            });

            customers.Add(new Customer
            {
                Id = new Guid("84c3c465-90ec-4e0a-8057-0905e5c64434"),
                Name = "James Mansion"
            });

            return Ok(customers);
        }

        [HttpGet]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> Get([FromUri]Guid id)
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id = new Guid("fa2c0554-e2c6-41df-90a2-a537ca68dcdb"),
                Name = "Lukas James"
            });

            customers.Add(new Customer
            {
                Id = new Guid("84c3c465-90ec-4e0a-8057-0905e5c64434"),
                Name = "James Mansion"
            });

            var customer = customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Post([FromBody]Customer customerToAdd)
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id = new Guid("fa2c0554-e2c6-41df-90a2-a537ca68dcdb"),
                Name = "Lukas James"
            });

            customers.Add(new Customer
            {
                Id = new Guid("84c3c465-90ec-4e0a-8057-0905e5c64434"),
                Name = "James Mansion"
            });

            Customer customer = new Customer
            {
                Id = customerToAdd.Id,
                Name = customerToAdd.Name
            };

            customers.Add(customer);

            return Ok(true);
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Put([FromUri]Guid id, [FromBody]Customer customerToUpdate)
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id = new Guid("fa2c0554-e2c6-41df-90a2-a537ca68dcdb"),
                Name = "Lukas James"
            });

            customers.Add(new Customer
            {
                Id = new Guid("84c3c465-90ec-4e0a-8057-0905e5c64434"),
                Name = "James Mansion"
            });

            var customer = customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                customer.Name = customerToUpdate.Name;
                return Ok(true);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete([FromUri]Guid id)
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer
            {
                Id = new Guid("fa2c0554-e2c6-41df-90a2-a537ca68dcdb"),
                Name = "Lukas James"
            });

            customers.Add(new Customer
            {
                Id = new Guid("84c3c465-90ec-4e0a-8057-0905e5c64434"),
                Name = "James Mansion"
            });

            var customer = customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                //remove item from the list
                customers.Remove(customers.SingleOrDefault(c => c.Id == id));

                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
