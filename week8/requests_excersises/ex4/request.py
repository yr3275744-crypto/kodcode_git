import requests

response_posts = requests.get("https://jsonplaceholder.typicode.com/posts")
response_users = requests.get("https://jsonplaceholder.typicode.com/users")

posts_json = response_posts.json()
mapping_json = {}

for post in posts_json:
    user_id = post["userId"]
    user = requests.get(f"https://jsonplaceholder.typicode.com/users/{user_id}")
    user_json = user.json()
    user_name = user_json["name"]
    mapping_json[user_id] = user_name
    post["name"] = user_name
    requests.put(f"https://jsonplaceholder.typicode.com/users/{user_id}", json=post)

for post in posts_json:
    title = post["title"]
    user_name = mapping_json[post["userId"]]
    print(f"Title:{title}\nUser name:{user_name}")