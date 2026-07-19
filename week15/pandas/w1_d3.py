import pandas as pd # the standard nickname for pandas

df = pd.read_csv("tracks.csv")

# print(df.head())
# print(df.head(3))
# print(df.info())
# print(df.describe())
# print(df.shape)


print(df["speed"]) # one column (a Series)
print(df[["id", "speed"]]) # two columns (a smaller DataFrame)
print(df["speed"].mean()) # average of one column
print(df["speed"].max())