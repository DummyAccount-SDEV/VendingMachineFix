from vending_logger import log_vending_activity, get_vending_history

# Test logging some vending activities
log_vending_activity("Coca Cola")
log_vending_activity("Snickers Bar")
log_vending_activity("Doritos")

# Display the vending history
print("\nVending Machine Activity Log:")
print(get_vending_history())
