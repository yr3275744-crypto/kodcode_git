# %%
import pandas as pd
# from ..day1 import independent_ex\

df = pd.read_csv("ecommerce_fulfillment_dirty.csv")
print(df.info())

# %%
duplicat_num = df.duplicated().sum()
df.drop_duplicates(inplace=True)
duplicat_num_after = df.duplicated().sum()
print(duplicat_num, duplicat_num_after)

# %%
print(df.shape[0])
print(df.dropna().shape[0])

# %%
print(df["Shipping_Mode"].unique())
print(df["Customer_Region"].unique())
df["Shipping_Mode"] = df["Shipping_Mode"].str.strip().str.replace("-", " ").str.title()
df["Customer_Region"] = df["Customer_Region"].str.title().str.strip()
print(df["Shipping_Mode"].unique())
print(df["Customer_Region"].unique())

# %%
print(df["Shipping_Cost"].isna().sum())
df["Shipping_Cost"] = df["Shipping_Cost"].str.replace("$", " ").str.strip("USD").str.strip()
df["Shipping_Cost"] = pd.to_numeric(df["Shipping_Cost"])
print(df["Shipping_Cost"].isna().sum())

# %%
# print(df[(df["Shipping_Cost"] < 0)])

# %%
df["Order_Date"] = pd.to_datetime(df["Order_Date"])

# %%
df["Delivery_Date"] = pd.to_datetime(df["Delivery_Date"])
print(df["Delivery_Date"].unique())
print(df["Delivery_Date"].isna().sum())

# %%
print(df["Ship_Date"].unique())
df["Ship_Date"] = pd.to_datetime(df["Ship_Date"])
print(df["Ship_Date"].unique())

# %%
ship_before_order = df[df["Order_Date" ] > df["Ship_Date"]].shape[0]
print(f"Ship before order: {ship_before_order}")

delivery_before_ship = df[df["Delivery_Date" ] < df["Ship_Date"]].shape[0]
print(f"delivery before ship: {delivery_before_ship}")

delivery_before_order = df[df["Delivery_Date" ] < df["Order_Date"]].shape[0]
print(f"delivery before order: {delivery_before_order}")

df.drop(
    df[df["Order_Date" ] > df["Ship_Date"]].index,
    inplace=True
)
df.drop(
    df[df["Delivery_Date" ] < df["Ship_Date"]].index,
    inplace=True
)
df.drop(
    df[df["Delivery_Date" ] < df["Order_Date"]].index,
    inplace=True
)
print(df.shape[0])
print()


# %%
days = (df["Delivery_Date"] - df["Ship_Date"]).dt.days
not_support = df[df["Delivery_Days"] != days]
print(not_support.count())

# %%
print(df.info())
print("duplicated\n", df.duplicated().sum())
print("null\n", df.isna().sum())

# %%
df.to_csv("ecommerce_fulfillment_cleaned.csv")


