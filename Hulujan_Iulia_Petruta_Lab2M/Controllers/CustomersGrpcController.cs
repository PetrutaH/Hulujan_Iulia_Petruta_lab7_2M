using Grpc.Net.Client;
using GrpcCustomersService;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
//using LibraryModel.Models;

namespace Hulujan_Iulia_Petruta_Lab2M.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomersGrpcController()
        {
//a se modifica portul corespunzator (vezi in proiectul GrpcCustomerService-> Properties->launchSettings.json)
            channel = GrpcChannel.ForAddress("https://localhost:7127");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new
                CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new CustomerService.CustomerServiceClient(channel);
            Customer customer = client.Get(new CustomerId() { Id = (int)id });
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            Empty response = client.Delete(new CustomerId()
            {
                Id = id
            });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new CustomerService.CustomerServiceClient(channel);
            
            Customer customerGrpc = client.Get(new CustomerId() { Id = (int)id });

            if (customerGrpc == null)
            {
                return NotFound();
            }

            var customerLocal = new Hulujan_Iulia_Petruta_Lab2M.Models.Customer()
            {
                ID = customerGrpc.CustomerId,
                Name = customerGrpc.Name,
                Adress = customerGrpc.Adress,
                BirthDate = DateTime.ParseExact(
            customerGrpc.Birthdate,"yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            return View(customerLocal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hulujan_Iulia_Petruta_Lab2M.Models.Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);

                
                var customerGrpc = new Customer()
                {
                    CustomerId = customer.ID,
                    Name = customer.Name,
                    Adress = customer.Adress,
                    Birthdate = customer.BirthDate.ToString("yyyy-MM-dd") 
                };

                client.Update(customerGrpc);

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
