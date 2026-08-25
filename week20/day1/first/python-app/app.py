import time
import requests

counter = 0
while True:
    counter += 1
    print(f"Message #{counter}: Application is running", flush= True)
    time.sleep(2)