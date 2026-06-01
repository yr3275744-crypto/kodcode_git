import requests

respons1 = requests.get("http://127.0.0.1:8000/greet")
respons2 = requests.get("http://127.0.0.1:8000/greet?name=Mosh")

print(respons1.text)
print(respons2.text)