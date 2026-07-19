import pandas as pd

data = {
    "id":[1, 2],
    "speed":[258, 582],
    "heading":[58, 85]
}
df1 = pd.DataFrame(data, index=data["id"])
print(df1.describe())
print(df1["speed"].mean())
print(df1["heading"].median())
print(df1["id"].count())