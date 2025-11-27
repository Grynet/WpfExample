using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Models;

namespace WpfExample.App.Repositories
{
    public interface ICustomerRepository
    {
        public Task<Customer> Get(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken);
        public Task<Customer> AddOrUpdate(Customer customer);
        public Task Delete(int id);
    }
}
