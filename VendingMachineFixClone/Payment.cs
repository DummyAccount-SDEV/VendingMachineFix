using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class Payment
    {
        // Available denominations in cents (e.g., 100 = $1.00)
        private static readonly int[] Denominations = { 10000, 5000, 2000, 1000, 500, 100, 25, 10, 5, 1 };
        
        public decimal AmountInserted { get; private set; }
        
        public Payment()
        {
            AmountInserted = 0;
        }

        public void InsertMoney(decimal amount)
        {
            AmountInserted += amount;
        }

        public Dictionary<int, int> CalculateChange(decimal itemPrice)
        {
            if (AmountInserted < itemPrice)
                throw new InvalidOperationException("Insufficient funds");

            var changeAmount = (int)((AmountInserted - itemPrice) * 100); // Convert to cents
            var change = new Dictionary<int, int>();

            foreach (var denomination in Denominations)
            {
                if (changeAmount <= 0) break;

                var count = changeAmount / denomination;
                if (count > 0)
                {
                    change[denomination] = count;
                    changeAmount -= count * denomination;
                }
            }

            return change;
        }

        public string FormatChange(Dictionary<int, int> change)
        {
            var result = new List<string>();
            foreach (var kvp in change)
            {
                var denomination = kvp.Key;
                var count = kvp.Value;
                
                if (denomination >= 100)
                {
                    result.Add($"{count} x ${denomination / 100:0.00}");
                }
                else
                {
                    result.Add($"{count} x {denomination}¢");
                }
            }
            return string.Join(", ", result);
        }

        public void Reset()
        {
            AmountInserted = 0;
        }

        public static string FormatMoney(decimal amount)
        {
            return $"${amount:0.00}";
        }
    }
}
