using Warehouse;


namespace Warehouse
{

    public class WareHouse
    {

        private List<Stock> _stockOfItems;

        public WareHouse()
        {

        }


        public void WareHouseSimulator()
        {
            _stockOfItems = new List<Stock>();
            Stock item1 = new("Hat", 2);
            Stock item2 = new("Shoes", 3);
            Stock item3 = new("Jacket", 5);

            _stockOfItems.Add(item1);
            _stockOfItems.Add(item2);
            _stockOfItems.Add(item3);
        }


        public void AddToStocks(string itemName, int itemCount)
        {
            if (itemCount < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.", nameof(itemCount));
            }

            if (_stockOfItems == null)
            {
                _stockOfItems = new List<Stock>();
            }

            // Check if item already exists
            var existingStock = _stockOfItems.FirstOrDefault(item => item.ItemName == itemName);

            if (existingStock != null)
            {
                // Check for overflow before updating the quantity
                if (existingStock.Quantity > int.MaxValue - itemCount)
                {
                    throw new OverflowException("Adding this quantity exceeds the maximum allowed stock.");
                }
                existingStock.Quantity += itemCount;
            }
            else
            {
                _stockOfItems.Add(new Stock(itemName, itemCount));
            }
        }

        public bool InStock(string itemName)
        {
            // Checking if _stockOfItems is null
            if (_stockOfItems == null)
            {
                return false;
            }

            return _stockOfItems.Any(item => item.ItemName == itemName && item.Quantity > 0);
        }

        public void TakeFromStock(string itemName, int quantity)
        {
            if (_stockOfItems == null || !_stockOfItems.Any())
            {
                throw new Exception("Item not found in stock");
            }

            var stock = _stockOfItems.FirstOrDefault(item => item.ItemName == itemName);

            if (stock == null)
            {
                throw new Exception("Item not found in stock");
            }

            if (quantity < 0)
            {
                throw new ArgumentException("Cannot take a negative quantity");
            }

            if (quantity > stock.Quantity)
            {
                throw new Exception($"Oversold {stock.ItemName}: Attempted to take {quantity}, but only {stock.Quantity} available.");
            }

            stock.Quantity -= quantity;
        }

        public int StockCount(string itemName)
        {

            if (_stockOfItems == null || !_stockOfItems.Any())
            {
                return 0;
            }

            var matches = _stockOfItems.Where(item => item.ItemName == itemName && item.Quantity > 0);
            int count = 0;

            foreach (var item in matches)
            {
                count += item.Quantity;
            }

            return count;
        }

    }

}

