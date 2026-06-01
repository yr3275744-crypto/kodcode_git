import requests

respons = requests.get("https://jsonplaceholder.typicode.com/users/1")

json_response = respons.json()

print(f"Name: {json_response.get("name")}")
print(f"Emaile: {json_response.get("email")}")
if json_response.get("address"):
    print(f"City: {json_response["address"].get("city")}")


respons2 = requests.get("https://jsonplaceholder.typicode.com/posts")
print(len(respons2.json()))

respons3 = requests.get("https://jsonplaceholder.typicode.com/posts?userId=2")
respons3_json = respons3.json()
for v in respons3_json:
    print(v.get("title"))