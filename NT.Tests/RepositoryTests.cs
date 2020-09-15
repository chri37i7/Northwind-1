using Microsoft.VisualStudio.TestTools.UnitTesting;

using NT.DataAccess.Repositories;
using NT.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public async Task GetOrderByIdTest()
        {
            // Arrange
            OrderRepository repository;
            IEnumerable<Orders> orders;

            // Act
            repository = new OrderRepository();
            orders = await repository.GetByIdAsync("anton");

            // Assert
            Assert.IsNotNull(orders);
        }

        [TestMethod]
        public async Task GetAllOrdersTest()
        {
            // Arrage
            OrderRepository repository;
            IEnumerable<Orders> orders;

            // Act
            repository = new OrderRepository();
            orders = await repository.GetAllAsync();

            // Assert
            Assert.IsTrue(orders.Count() > 0);
        }
    }
}