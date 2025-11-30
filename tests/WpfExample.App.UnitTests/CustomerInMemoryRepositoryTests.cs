using System;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Mvvm.Models;
using WpfExample.App.Repositories;

namespace WpfExample.App.UnitTests
{
    public class CustomerInMemoryRepositoryTests
    {
        private CustomerInMemoryRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CustomerInMemoryRepository();
        }

        [Test]
        public async Task Get_ExistingCustomer_ReturnsCustomer()
        {
            //Arrange
            var expectedCustomer = new Customer
            {
                Id = 1337,
                FirstName = "Test",
                LastName = "Testsson"
            };

            await _sut.AddOrUpdate(expectedCustomer);

            //Act
            var actualCustomer = await _sut.Get(expectedCustomer.Id, CancellationToken.None);

            //Assert
            Assert.IsNotNull(actualCustomer);
            Assert.That(actualCustomer.Id, Is.EqualTo(expectedCustomer.Id));
            Assert.That(actualCustomer.FirstName, Is.EqualTo(expectedCustomer.FirstName));
            Assert.That(actualCustomer.LastName, Is.EqualTo(expectedCustomer.LastName));
        }

        [Test]
        public async Task Get_NonExistingCustomer_ReturnsNull()
        {
            //Arrange
            var customerId = 1337;

            //Act
            var actualCustomer = await _sut.Get(customerId, CancellationToken.None);

            //Assert
            Assert.That(actualCustomer, Is.Null);
        }


        [Test]
        public void Get_CancellationTokenCancelled_ThrowsOperationCancelledException()
        {
            //Arrange
            using var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            //Act & Assert
            Assert.ThrowsAsync<OperationCanceledException>(() => _sut.Get(1, tokenSource.Token));
        }

        [Test]
        public void GetAll_CancellationTokenCancelled_ThrowsOperationCancelledException()
        {
            //Arrange
            using var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            //Act & Assert
            Assert.ThrowsAsync<OperationCanceledException>(() => _sut.GetAll(tokenSource.Token));
        }

        [Test]
        public async Task AddOrUpdate_NewCustomer_AddsCustomer()
        {
            //Arrange
            var expectedCustomer = new Customer
            {
                Id = 1337,
                FirstName = "Test",
                LastName = "Testsson"
            };

            //Act
            var actualCustomer = await _sut.AddOrUpdate(expectedCustomer);

            //Assert
            Assert.IsNotNull(actualCustomer);
            Assert.That(actualCustomer.Id, Is.EqualTo(expectedCustomer.Id));
            Assert.That(actualCustomer.FirstName, Is.EqualTo(expectedCustomer.FirstName));
            Assert.That(actualCustomer.LastName, Is.EqualTo(expectedCustomer.LastName));
        }

        [Test]
        public async Task Delete_CustomerExists_DeletesCustomer()
        {
            //Arrange
            var customer = new Customer
            {
                Id = 1337,
                FirstName = "Test",
                LastName = "Testsson"
            };
            await _sut.AddOrUpdate(customer);

            //Act
            await _sut.Delete(customer.Id);

            //Assert
            var actualCustomer = await _sut.Get(customer.Id, CancellationToken.None);
            Assert.IsNull(actualCustomer);
        }
    }
}
