# %%
import pandas as pd
df = pd.read_excel("Online_Retail.xlsx")
print(df.shape)
print(df.info())

# %%
print(df.head(3))

# %%
rows_before = df.shape[0]
duplicates_before = df.duplicated().sum()
print(rows_before, duplicates_before)

# %%
df = df.drop_duplicates()
rows_after = df.shape[0]
rows_removed = rows_before - rows_after
print(f"rows after: {rows_after}, rows droped:{rows_removed}")
print(df.duplicated().sum())

# %%
print(df.dropna().shape[0])

# %%
sample = pd.DataFrame({"Rating": [4, None, 5, None, 3]})
sample["Rating"].fillna(0)

# %%
print((df["Quantity"] < 0).sum())
print((df["UnitPrice"] <= 0).sum())

# %%
fixed_to_mine = df.drop(
    df[(df["Quantity"] < 0) & (df["UnitPrice"] >= 0)].index,
    inplace=False
)
print(df.shape[0], fixed_to_mine.shape[0])

# %%
print(df[(df["Quantity"] < 0) & (df["UnitPrice"] >= 0)])

# %%
desc = df["Description"]
has_extra_space = desc.notna() & (desc != desc.str.strip())
print(has_extra_space.sum())

# %%
description_before = df["Description"].copy()
df["Description"] = df["Description"].str.strip()

# %%
missing_before = description_before.isna()
missing_after = df["Description"].isna()

print(missing_before.sum())
print(missing_after.sum())

# %%
newly_missing = df[missing_after & ~missing_before]
description_before[newly_missing.index]

# %%
sample = pd.DataFrame({"Price": ["3.50", "4.00", "N/A", "5.25"]})
print(sample.info())
sample["Price"] = pd.to_numeric(sample["Price"], errors="coerce")
print(sample["Price"].isna().sum())
print(sample.info())

# %%
print(df["InvoiceDate"].dt.year.unique())
print(df["InvoiceDate"].dt.month.head(2))
print(df["InvoiceDate"].dt.day.head(2))

# %%
df[df["Description"].str.lower() == "check"]["Description"].value_counts()

# %%
print(pd.to_numeric(df["CustomerID"], downcast= "integer", errors="coerce").dtype)

# %%
print(df.shape)
print(df.isna().sum())
print(df.duplicated().sum())
print(df.dtypes)
print(df.describe())
print(df["Country"].value_counts().head(5))

# %%
df.to_csv("online_retail_cleaned.csv", index=False)


