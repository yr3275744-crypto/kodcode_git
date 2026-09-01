# %%
import numpy as np

# %%
numbers = [10, 20, 30, 40]
arr = np.array(numbers)

print(arr)
print(type(arr))

# %%
print(arr.ndim)
print(arr.shape)
print(arr.size)
print(arr.dtype)

# %%
print(arr[0])
print(arr[1])
print(arr[-1])

# %%
print(arr[1:4])
print(arr[:3])
print(arr[2:])

# %%
matrix = np.array([
    [10, 20, 30],
    [40, 50, 60],
    [70, 80, 90],
])

print(matrix.ndim)
print(matrix.shape)
print(matrix.size)

# %%
print(matrix[0])
print(matrix[0, 1])
print(matrix[2, 2])

# %%
arr = np.array([10, 20, 30, 40])

print(arr + 5)
print(arr * 2)
print(arr / 10)

# %%
prices = np.array([25, 40, 15, 60, 30])

print(prices.sum())
print(prices.min())
print(prices.max())
print(prices.mean())

# %%
arr = np.array([10, 20, 30, 40])
print(arr > 20)

# %%
print(arr[arr > 20])

# %%
delivery_days = np.array([2, 5, 1, 8, 4, 10, 3, 6])
print(delivery_days.shape)
print(delivery_days.size)
print(delivery_days.min())
print(delivery_days.max())
print(delivery_days.mean())
print(delivery_days[2])
print(delivery_days[:4])
print(delivery_days[delivery_days > 5])


