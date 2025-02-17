from datetime import datetime
import os

LOG_FILE = "vending_activity.txt"

def log_vending_activity(item_name):
    """
    Log a vending machine transaction with timestamp.
    Args:
        item_name (str): Name of the item that was vended
    """
    timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    log_entry = f"{timestamp} - Vended: {item_name}\n"
    
    # Ensure log directory exists
    os.makedirs(os.path.dirname(LOG_FILE) if os.path.dirname(LOG_FILE) else '.', exist_ok=True)
    
    # Append to log file
    with open(LOG_FILE, 'a') as log_file:
        log_file.write(log_entry)

def get_vending_history():
    """
    Retrieve the complete vending history.
    Returns:
        str: Complete log contents or empty string if log doesn't exist
    """
    try:
        with open(LOG_FILE, 'r') as log_file:
            return log_file.read()
    except FileNotFoundError:
        return "No vending history found."
