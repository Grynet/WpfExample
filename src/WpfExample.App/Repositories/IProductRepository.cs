using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Mvvm.Models;

namespace WpfExample.App.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> Get(Guid id, CancellationToken cancellationToken);
        public Task<ICollection<Product>> GetAll(CancellationToken cancellationToken);
        public Task AddOrUpdate(Product product);
        public Task Delete(Guid id);
    }
}
