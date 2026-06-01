import requests

req = requests.get("http://127.0.0.1:8000")

data = req.status_code

print(data)