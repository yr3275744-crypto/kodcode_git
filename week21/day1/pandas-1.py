# %%
import pandas as pd

# %%
scores = pd.Series([85, 90, 78, 92])
print(scores)

# %%
print(type(scores))
print(scores.index)
print(scores.values)

# %%
scores = pd.Series(
    [85, 90, 78],
    index= ["student_a", "student_b", "student_c"]
)
print(scores)

# %%
print(scores["student_b"])

# %%
student = {
    "name": "Daniel",
    "age": 24,
    "course": "Data Engineering"
}
print(student["name"])

# %%
data = {
    "Name": ["Daniel", "Sara", "David"],
    "Age": [24, 27, 22],
    "Score": [85, 91, 78]
}

df = pd.DataFrame(data)
df

# %%
print(type(df))
print(df.columns)
print(df.index)
print(df.shape)

# %%
data = [
    {"Name": "Daniel", "Age": 24, "Score": 85},
    {"Name": "Sara", "Age": 27, "Score": 91},
    {"Name": "David", "Age": 22, "Score": 78}
]

df2 = pd.DataFrame(data)
df2

# %%
df.equals(df2)
print(type(df2))
print(df2.columns)
print(df2.index)
print(df2.shape)

# %%
print(df["Name"])
print(type(df["Name"]))

# %%
print(df[["Name", "Score"]])
print(type(df[["Name"]]))

# %%
print(df.index)
df.index = ["student_1", "student_2", "student_3"]
df

# %%
df.loc["student_1"]

# %%
df.iloc[0]

# %%
df["Passed"] = [True, True, False]
df

# %%
df["Score"] = df["Score"] + 5
df

# %%
df["Score"] > 90

# %%
df[df["Score"] > 90]

# %%
csv_text = """Name,Age,City
Daniel,24,Haifa
Sara,27,Jerusalem
David,22,Tel Aviv
"""

with open("students.csv", "w") as f:
    f.write(csv_text)

# %%
csv_df = pd.read_csv("students.csv")
csv_df


# %%
print(type(csv_df))
print(csv_df.columns)
print(csv_df.index)
print(csv_df.shape)

# %%
json_text = """[
    {"Name": "Daniel", "Age": 24, "City": "Haifa"},
    {"Name": "Sara", "Age": 27, "City": "Jerusalem"},
    {"Name": "David", "Age": 22, "City": "Tel Aviv"}
]
"""

with open("students.json", "w") as f:
    f.write(json_text)

# %%
json_df = pd.read_json("students.json")
json_df

# %%
import requests

response = requests.get("https://jsonplaceholder.typicode.com/todos?_limit=5")
data = response.json()

api_df = pd.DataFrame(data)
api_df

# %%
api_df.head()
api_df.columns
api_df.shape


