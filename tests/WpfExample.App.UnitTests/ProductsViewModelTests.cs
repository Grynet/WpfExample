using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Models;
using WpfExample.App.Presentation.Features.Products;
using WpfExample.App.Repositories;

namespace WpfExample.App.UnitTests
{
    public class ProductsViewModelTests
    {
        private Mock<IProductRepository> _productRepositoryMock;

        private ProductsViewModel _sut;


        [SetUp]
        public void SetUp()
        {
            _productRepositoryMock = new Mock<IProductRepository>();

            _sut = new ProductsViewModel(_productRepositoryMock.Object);
        }

        [Test]
        public async Task LoadCommand_WhenRepositoryReturnsProducts_ShouldPopulateProductsWithMappedViewModels()
        {
            //Arrange
            var expectedProduct = CreateProductStub();
            var expectedProducts = new List<Product> { expectedProduct };

            _productRepositoryMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(expectedProducts);

            //Act
            await _sut.LoadDataCommand.ExecuteAsync(null);

            //Assert
            var actualProducts = _sut.Products;
            Assert.IsNotNull(actualProducts);
            Assert.That(actualProducts.Count, Is.EqualTo(1));
            var actualProductViewModel = actualProducts.First();

            Assert.That(actualProductViewModel.Id, Is.EqualTo(expectedProduct.Id));
            Assert.That(actualProductViewModel.Name, Is.EqualTo(expectedProduct.Name));
            Assert.That(actualProductViewModel.Price, Is.EqualTo(expectedProduct.Price));
            Assert.That(actualProductViewModel.Description, Is.EqualTo(expectedProduct.Description));
        }

        [Test]
        public async Task LoadCommand_WhenRepositoryReturnsNoProducts_ShouldInitializeProductsAsEmptyCollection()
        {
            //Arrange
            _productRepositoryMock.Setup(x => x.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync([]);

            //Act
            await _sut.LoadDataCommand.ExecuteAsync(null);

            //Assert
            var actualProducts = _sut.Products;
            Assert.IsNotNull(actualProducts);
            Assert.That(actualProducts.Count, Is.EqualTo(0));
        }

        #region FactoryMethods
        private Product CreateProductStub()
        {
            var product = new Product
            {
                Id = new Guid("cc2aac7e-0c7e-48da-892e-6ee2c91bb8a5"),
                Name = "A test broom",
                Price = 200,
                Description = "A nice broom"
            };

            return product;
        }
        #endregion
    }
}
