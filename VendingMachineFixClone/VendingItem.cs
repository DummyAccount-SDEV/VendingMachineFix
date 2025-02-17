namespace VendingMachine
{
    public class VendingItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public VendingItem(string name, decimal price, int quantity = 10)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} - {Payment.FormatMoney(Price)}";
        }
    }
}
