using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Mvvm.Models;

namespace WpfExample.App.Repositories
{
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        private readonly ConcurrentDictionary<int, Customer> _customerById;
        public CustomerInMemoryRepository()
        {
            var donald = CreateDuckCustomer(1, "Donald");
            var huey = CreateDuckCustomer(2, "Della");
            var louie = CreateDuckCustomer(2, "Louie");

            _customerById = new ConcurrentDictionary<int, Customer>()
            {
                [donald.Id] = donald,
                [huey.Id] = huey,
                [louie.Id] = louie
            };            
        }

        public Task<Customer> Get(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _customerById.TryGetValue(id, out var customer);
            return Task.FromResult(customer);
        }

        public Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken) 
        {
            cancellationToken.ThrowIfCancellationRequested();

            IEnumerable<Customer> customers = _customerById.Values.ToList();

            return Task.FromResult(customers);
        }

        public Task<Customer> AddOrUpdate(Customer customer)
        {
            _customerById[customer.Id] = customer;
            return Task.FromResult(customer);
        }

        public Task Delete(int id)
        {
            _customerById.TryRemove(id, out _);
            return Task.CompletedTask;
        }

        private Customer CreateDuckCustomer(int id, string firstName)
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = firstName,
                LastName = "Duck",
                PhoneNumber = "+461234567",
                HomeAddress = new Address
                {
                    Street = "Duckstreet 1",
                    PostalCode = "1337"
                }
            };
            return customer;
        }
    }
}
