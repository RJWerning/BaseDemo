using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BaseDemo.Models;
using BaseDemo.Contracts;
using BaseDemo.Repository;
using BaseDemo.ViewModels;

namespace BaseDemo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _dataContext;

        public CustomerController() {
            _dataContext = new InMemoryRepository<Customer>();

            if (!_dataContext.Collection().Any()) {
                _dataContext.Insert(new Customer() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Fred Flintstone",
                    PhoneNumber = "555-123-4567"
                });
                _dataContext.Insert(new Customer() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Barney Rubble",
                    PhoneNumber = "444-555-6666"
                });
                _dataContext.Commit();
            }
        }

        public ActionResult Index() {
            var customers = new List<CustomerVm>();
            var recipList = _dataContext.Collection().ToList();
            foreach (var item in recipList) {
                customers.Add(new CustomerVm() {
                    Id = item.Id,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber
                });
            }
            return View(customers);
        }

        public ActionResult AddCustomer() {
            var customer = new CustomerVm();
            return View(customer);
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerVm sender) {
            if (!ModelState.IsValid) {
                return View(sender);
            }

            var value = new Customer() {
                Id = sender.Id,
                Name = sender.Name,
                PhoneNumber = sender.PhoneNumber
            };
            _dataContext.Insert(value);
            _dataContext.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult EditCustomer(string id) {
            var customer = _dataContext.Find(id);
            if (customer == null) {
                return HttpNotFound();
            }

            var customerVm = new CustomerVm(customer);
            return View(customerVm);
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerVm sender) {
            if (!ModelState.IsValid) {
                return View(sender);
            }

            var customer = _dataContext.Find(sender.Id);
            if (customer == null) {
                return HttpNotFound();
            }

            customer.Name = sender.Name;
            customer.PhoneNumber = sender.PhoneNumber;
            _dataContext.Update(customer);
            _dataContext.Commit();
                
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(string id) {
            var customer = _dataContext.Find(id);
            if (customer == null) {
                return HttpNotFound();
            }

            var customerVm = new CustomerVm(customer);

            return View(customerVm);
        }

        [HttpPost]
        [ActionName("DeleteCustomer")]
        public ActionResult ConfirmDeleteCustomer(string id) {
            var customer = _dataContext.Find(id);
            if (customer == null) {
                return HttpNotFound();
            }
            _dataContext.Delete(id);

            return RedirectToAction("Index");
        }
    }
}