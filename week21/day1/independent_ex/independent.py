# %%
import pandas as pd

def load_data():
    try:
        df = pd.read_csv("ecommerce_fulfillment_dirty.csv")
        return df
    except FileNotFoundError:
        print("Error: Online Retail.xlsx was not found.")
        return None
def main():
    df = load_data()
    if df is None:
        return
    # %%
    print(df.info())

    # %%
    print(df.dtypes)
    print(df.describe)

    # %%
    print(df.isna().sum())

    # %%
    print(df.isna().sum() / len(df) * 100)


    # %%
    print(df.duplicated().sum())

    # %%
    musk_ = df.duplicated(keep=False)
    print(df[musk_].sort_values(by= "Order_ID"))

    # %%
    print(df["Product_Category"].unique())
    print(df["Customer_Region"].unique())
    print(df["Customer_Region"].str.lower().unique())
    print(df["Delivery_Status"].unique())

    # %%
    # check numeriks
    print(df.dtypes) # date str, cost str
    print(df.describe()) # negative Delivery_Days
    print(df[df["Delivery_Days"] < 0])

    # %%
    summary = {
        "rows": len(df),
        "colmens": len(df.columns),
        "worth flagging" : ["date - str instead date", "cost - str insted float"],
        "Missing values per affected column": df.isna().sum(),
        "Missing values in percentage" : df.isna().sum() / len(df) * 100,
        "Customer_Region values": df["Customer_Region"].nunique(),
        "wanted Customer_Region values": df["Customer_Region"].str.lower().nunique(),
        "unexpected minimum value": "Delivery_Days"
        
    }
    # result = pd.DataFrame(summary.values(), columns= summary.items())
    return summary

print(main())
