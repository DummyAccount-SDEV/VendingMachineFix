from dataclasses import dataclass
from typing import Dict, List, Optional
from decimal import Decimal
import sys

@dataclass
class Item:
    name: str
    price: Decimal
    quantity: int

class VendingMachine:
    def __init__(self):
        self.items: Dict[str, Item] = {
            'A1': Item('Cola', Decimal('1.50'), 5),
            'A2': Item('Chips', Decimal('1.00'), 5),
            'A3': Item('Candy', Decimal('0.75'), 5),
            'B1': Item('Water', Decimal('1.25'), 5),
            'B2': Item('Energy Drink', Decimal('2.50'), 5),
            'B3': Item('Gum', Decimal('0.50'), 5)
        }
        self.current_balance: Decimal = Decimal('0.00')
        
    def display_items(self) -> None:
        print("\nAvailable Items:")
        print("Code | Item          | Price | Qty")
        print("-" * 35)
        for code, item in self.items.items():
            print(f"{code:4} | {item.name:12} | ${item.price:4.2f} | {item.quantity}")
            
    def insert_money(self, amount: str) -> None:
        try:
            money = Decimal(amount)
            if money <= 0:
                print("Please insert a positive amount.")
                return
            self.current_balance += money
            print(f"Current balance: ${self.current_balance:.2f}")
        except:
            print("Invalid amount. Please enter a valid number.")
            
    def return_change(self) -> None:
        if self.current_balance > 0:
            print(f"Returning change: ${self.current_balance:.2f}")
            self.current_balance = Decimal('0.00')
        
    def select_item(self, code: str) -> bool:
        if code not in self.items:
            print("Invalid item code.")
            return False
            
        item = self.items[code]
        
        if item.quantity <= 0:
            print(f"Sorry, {item.name} is out of stock.")
            return False
            
        if self.current_balance < item.price:
            print(f"Insufficient funds. You need ${item.price - self.current_balance:.2f} more.")
            return False
            
        # Process purchase
        item.quantity -= 1
        self.current_balance -= item.price
        print(f"\nDispensing {item.name}...")
        print(f"Remaining balance: ${self.current_balance:.2f}")
        return True

def main():
    vm = VendingMachine()
    
    while True:
        print("\n=== Vending Machine ===")
        print(f"Current balance: ${vm.current_balance:.2f}")
        print("\nOptions:")
        print("1. Display items")
        print("2. Insert money")
        print("3. Select item")
        print("4. Return change")
        print("5. Exit")
        
        choice = input("\nEnter your choice (1-5): ")
        
        if choice == "1":
            vm.display_items()
        elif choice == "2":
            amount = input("Enter amount to insert (e.g., 1.00): $")
            vm.insert_money(amount)
        elif choice == "3":
            vm.display_items()
            code = input("Enter item code (e.g., A1): ").upper()
            vm.select_item(code)
        elif choice == "4":
            vm.return_change()
        elif choice == "5":
            vm.return_change()
            print("Thank you for using the vending machine!")
            sys.exit(0)
        else:
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main()
