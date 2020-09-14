using Microsoft.VisualStudio.TestTools.UnitTesting;

using NT.DataAccess.Repositories;
using NT.Entities.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public async Task RepositoryTest()
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
    }
}