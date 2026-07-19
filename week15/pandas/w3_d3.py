import pandas as pd

data = {
    "id":[1, 2, 1],
    "speed":[258, 582, 258],
    "heading":["58", "85", "58"],
    "pop": "hahaha",
    "time": "2024/04/15"
}
df1 = pd.DataFrame(data, index=data["id"])
df1.drop_duplicates(inplace=True)
print(df1)
df1.drop(columns="pop", inplace=True)
print(df1)
print(df1["heading"])
df1["heading"] = pd.to_numeric(df1["heading"])
print(df1["heading"])
print(df1["time"])
df1["time"] = pd.to_datetime(df1["time"], yearfirst=True)
print(df1["time"])