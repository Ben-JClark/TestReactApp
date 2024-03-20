namespace TestReactApp.Server
{
    public class Shop
    {
        /// <summary>
        /// Calculates the total revenue from all the sales in the Shop
        /// </summary>
        /// <returns>Total trade revenue</returns>
        public int calculateRevenue()
        {
            int total = 0;
            foreach( Trade trade in tradeList )
            {
                total += (trade.sales * trade.price);
            }
            return total;
        }
        public List<Trade> tradeList { get; } = new List<Trade>();
        public void AddTrade(Trade trade)
        {
            tradeList.Add(trade);
        }
        
    }
    public class Trade
    {
        public Trade(string itemSold, int paymentQty)
        {
            this.item = itemSold;
            this.price = paymentQty;
        }
        public string item { get; set; }
        public int price { get; set; }
        public int sales { get; set; } // Qty of trades completed
        public int stock { get; set; } // Qty of trades remaining

    }
}
