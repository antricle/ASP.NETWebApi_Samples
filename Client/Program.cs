using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:58154/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //Get(cons).Wait();
            //GetById(cons).Wait();
            //Post(cons).Wait();
            //Put(cons).Wait();
            Delete(cons).Wait();

            Console.ReadKey();
        }

        static async Task Get(HttpClient cons)
        {
            IList<Customer> customers = new List<Customer>();
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/customer");
                if (res.IsSuccessStatusCode)
                {
                    customers = await res.Content.ReadAsAsync<IList<Customer>>();
                }
            }

            foreach (var item in customers)
            {
                Console.WriteLine("ID" + item.Id + "Name" + item.Name);
                Console.WriteLine();
            }
        }

        static async Task GetById(HttpClient cons)
        {
            Customer customer = null;
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/customer/84c3c465-90ec-4e0a-8057-0905e5c64434");
                if (res.IsSuccessStatusCode)
                {
                    customer = await res.Content.ReadAsAsync<Customer>();
                }
            }

            Console.WriteLine("ID" + customer.Id + "Name" + customer.Name);
        }

        static async Task Post(HttpClient cons)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "James Arthur"
            };

            using (cons)
            {
                HttpResponseMessage res = await cons.PostAsJsonAsync("api/customer/", customer);
                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("Customer created");
                }
            }
        }

        static async Task Put(HttpClient cons)
        {
            string updatedName = "John Carpenter";

            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/customer/84c3c465-90ec-4e0a-8057-0905e5c64434");
                if (res.IsSuccessStatusCode)
                {
                    Customer customer = await res.Content.ReadAsAsync<Customer>();

                    customer.Name = updatedName;

                    res = await cons.PutAsJsonAsync("api/customer/84c3c465-90ec-4e0a-8057-0905e5c64434", customer);

                    Console.WriteLine("Customer updated." + "ID" + customer.Id + "Name" + customer.Name);
                }
            }
        }

        static async Task Delete(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/customer/84c3c465-90ec-4e0a-8057-0905e5c64434");
                if (res.IsSuccessStatusCode)
                {
                    res = await cons.DeleteAsync("api/customer/84c3c465-90ec-4e0a-8057-0905e5c64434");

                    Console.WriteLine("Customer deleted.");
                }
            }
        }
    }
}
