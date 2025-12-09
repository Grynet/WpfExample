using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Models;

namespace WpfExample.App.Repositories
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<Guid, Product> _products;

        public ProductInMemoryRepository()
        {
            var dishWasher = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Electrolux Dishwasher",
                Description = "Washes stuff",
                Price = 5_000
            };

            var broom = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Plastic broom",
                Description = "An amazing broom out of plastic",
                Price = 200
            };

            var coffePot = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Coffee Pot",
                Description = "Has enough for 12 servings",
                Price = 500
            };

            _products = new ConcurrentDictionary<Guid, Product>()
            {
                [dishWasher.Id] = dishWasher,
                [broom.Id] = broom,
                [coffePot.Id] = coffePot,
            };
        }

        public async Task AddOrUpdate(Product product)
        {
            await ArtificalDelay();

            _products.AddOrUpdate(product.Id, addValueFactory: id => product, updateValueFactory: (id, existing) => product);                
        }

        public async Task Delete(Guid id)
        {
            await ArtificalDelay();

            _products.Remove(id, out _);
        }

        public async Task<Product> Get(Guid id, CancellationToken cancellationToken)
        {
            await ArtificalDelay();
            _products.TryGetValue(id, out var product);

            return product;
        }

        public async Task<ICollection<Product>> GetAll(CancellationToken cancellationToken)
        {
            await ArtificalDelay();
            var products = _products.Values;

            return products;
        }

        private Task ArtificalDelay()
        {
            var delayInMs = Random.Shared.Next(500, 1500);
            return Task.Delay(delayInMs);
        }
    }
}
