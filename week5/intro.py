#1.
print(int(input("enter a number:")) % 2 ==0)

#2.
x, y = 2 , 5
x += y
y = x -y
x -= y

#3.
def sum_digits_3_digits_num(num:int):
    num = 912
    temp_result = num % 10
    num = num // 10
    temp_result += num % 10
    num = num // 10
    temp_result += num
    result = temp_result
    return result

#4.
def calc_bmi(weight: int | float, height: int | float) -> float:
    return round(weight / height ** 2, 2)

#5.
num = 22.33
num_1 = int(num)
num_2 = num % 1
