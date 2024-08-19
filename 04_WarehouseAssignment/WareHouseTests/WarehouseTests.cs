using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Warehouse;

namespace WarehouseTests
{
    [TestClass]
    public class WareHouseTests
    {

        [TestMethod]
        public void WareHouseSimulator_InitialSetup_SetsStockCorrectly()
        {
            // Arrange
            WareHouse wareHouse = new WareHouse();

            // Act
            wareHouse.WareHouseSimulator();

            // Assert
            Assert.AreEqual(2, wareHouse.StockCount("Hat"));
            Assert.AreEqual(3, wareHouse.StockCount("Shoes"));
            Assert.AreEqual(5, wareHouse.StockCount("Jacket"));
        }

        [TestMethod]
        public void WareHouseSimulator_ResetStock_SetsStockToInitialValues()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.AddToStocks("Hat", 10); // Add some stock before simulation

            // Act
            wareHouse.WareHouseSimulator();

            // Assert
            Assert.AreEqual(2, wareHouse.StockCount("Hat")); // Should be reset to 2
            Assert.AreEqual(3, wareHouse.StockCount("Shoes"));
            Assert.AreEqual(5, wareHouse.StockCount("Jacket"));
        }

        // Test AddToStocks
        [TestMethod]
        public void AddToStocks_DecentPositiveValue_IncreasesStockCount()
        {
            // Arrange
            var wareHouse = new WareHouse();

            // Act
            wareHouse.AddToStocks("Hat", 5);

            // Assert
            Assert.AreEqual(5, wareHouse.StockCount("Hat"));
        }

        [TestMethod]
        public void AddToStocks_ZeroQuantity_DoesNotAddStock()
        {
            // Arrange
            var wareHouse = new WareHouse();

            // Act
            wareHouse.AddToStocks("Hat", 0);

            // Assert
            Assert.AreEqual(0, wareHouse.StockCount("Hat"));
        }

        // Test InStock
        [TestMethod]
        public void InStock_ItemInStock_ReturnsTrue()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.WareHouseSimulator();

            // Act
            var result = wareHouse.InStock("Hat");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InStock_ItemOutOfStock_ReturnsFalse()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.WareHouseSimulator();

            // Act
            wareHouse.TakeFromStock("Hat", 2); // Take all of them
            var result = wareHouse.InStock("Hat");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InStock_ItemNotInStock_ReturnsFalse()
        {
            // Arrange
            var wareHouse = new WareHouse();

            // Act
            var result = wareHouse.InStock("NonExistingItem");

            // Assert
            Assert.IsFalse(result);
        }

        // Test TakeFromStock
        [TestMethod]
        public void TakeFromStock_ValidItem_DecreasesStockCorrectly()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.WareHouseSimulator();

            // Act
            wareHouse.TakeFromStock("Hat", 1);

            // Assert
            Assert.AreEqual(1, wareHouse.StockCount("Hat"));
        }

        [TestMethod]
        public void TakeFromStock_ExceedsStock_ThrowsException()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.AddToStocks("Hat", 5);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => wareHouse.TakeFromStock("Hat", 10));
        }

        [TestMethod]
        public void TakeFromStock_ItemDoesNotExist_ThrowsException()
        {
            // Arrange
            var wareHouse = new WareHouse();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => wareHouse.TakeFromStock("NonExistentItem", 5));
        }


        // Test StockCount
        [TestMethod]
        public void StockCount_ValidItem_ReturnsCorrectQuantity()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.WareHouseSimulator();

            // Act
            var count = wareHouse.StockCount("Hat");

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void StockCount_ItemNotInStock_ReturnsZero()
        {
            // Arrange
            var wareHouse = new WareHouse();

            // Act
            var count = wareHouse.StockCount("NonExistingItem");

            // Assert
            Assert.AreEqual(0, count);
        }


        [TestMethod]
        public void StockCount_ItemInStockWithNegativeQuantity_ReturnsZero()
        { // Arrange
            var wareHouse = new WareHouse();

            // Act & Assert
            // Try to add a negative quantity
            Assert.ThrowsException<ArgumentException>(() => wareHouse.AddToStocks("Hat", -5));

            // Ensure no negative stock is present
            var stockCount = wareHouse.StockCount("Hat");

            // Assert
            Assert.AreEqual(0, stockCount); // Since adding negative quantity is not allowed, stock count should be zero
        }

        // Functional Tests
        [TestMethod]
        public void AddAndRemoveItem_StockCorrectlyAdjusted()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.AddToStocks("Hat", 10);

            // Act
            wareHouse.TakeFromStock("Hat", 5);
            var count = wareHouse.StockCount("Hat");

            // Assert
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void AddItem_ExceedingStock_ThrowsException()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.AddToStocks("Hat", int.MaxValue);

            // Act & Assert
            Assert.ThrowsException<OverflowException>(() => wareHouse.AddToStocks("Hat", int.MaxValue));
        }

        [TestMethod]
        public void ItemLifecycle_AddRemoveItem_StockCountUpdatedCorrectly()
        {
            // Arrange
            var wareHouse = new WareHouse();
            wareHouse.AddToStocks("Hat", 10);

            // Act
            wareHouse.TakeFromStock("Hat", 5);
            wareHouse.AddToStocks("Hat", 3);
            wareHouse.TakeFromStock("Hat", 8);

            // Assert
            Assert.AreEqual(0, wareHouse.StockCount("Hat"));
        }
    }
}