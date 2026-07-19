import pandas as pd

# tracks_speedes = [412, 95, 250, 510]
# series1 = pd.Series(tracks_speedes, index= [1, 2, 3, 4])
# print(series1)


data = {
    "id":[1, 2],
    "speed":[258, 582],
    "heading":[58, 85]
}
df1 = pd.DataFrame(data, index=data["id"])
df1["hhh"] = df1["speed"] * 2
print(df1)
print(df1["hhh"])