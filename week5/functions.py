#1.
def is_even(n:int|float) -> bool:
    return True if (n % 2 == 0) else False

#2.
def factorial(n:int) -> None:
    """ n must be lerger then 0."""
    counter = 1
    result = 1
    while counter <= n:
        result *= counter
        counter += 1
    return result

#4.
def is_palindrome(s:str) -> bool:
    reversed_s = s[::-1]
    return True if s == reversed_s else False

#5.
def sum_digits(n):
    if n < 10:
        return n
    n_digits = []
    while n > 0:
        n_digits.append(n % 10)
        n //= 10
    result = sum(n_digits)
    if result > 10:
        result = digital_root(result)
    return result

def digital_root(n:int) -> int:
    return sum_digits(n)

#6.
def count_digits(num:int) -> int:
    """ num > 0 is must."""
    digits_num = 0
    while num:
        digits_num += 1
        num //= 10
    return digits_num

#7.
def revers_integer(num: int) -> int:
    if num >= 0:
        flag = 1
    else:
        flag = -1
        num = abs(num)
    reversed_num = 0
    while num:
        last_digit = num % 10
        reversed_num = reversed_num * 10 + last_digit
        num //= 10
    return reversed_num * flag

#8.
def sort_0s_in_arry(arry:list[int]) -> list:
    changes_counter = 0
    for i in range(len(arry)):
        if arry[i - changes_counter] == 0:
            zerro = arry.pop(i - changes_counter)
            arry.append(zerro)
            changes_counter += 1
    return arry

# print(sort_0s_in_arry([0, 0, 5, 1, 0, 1,0, 0, 0, 5])) #for checking

#9.
def statistical_detiles_from_arry(arry:list[int]) -> None:
    if len(arry) == 0:
        return "empty list"
    sum_of_numbers = 0
    minimum = arry[0]
    maximum = minimum
    for num in arry:
        sum_of_numbers += num
        if num < minimum:
            minimum = num
        elif num > maximum:
            maximum = num
    average_of_numbers = sum_of_numbers / len(arry)
    print(f"""the sumof numbers: {sum_of_numbers}
the average: {average_of_numbers}
the minimum value: {minimum}
the maximum value: {maximum}""")

#10.
def reverse_list(list:list) -> list:
    reversed_list = []
    for i in range(len(list)):
        reversed_list.append(list[i*-1 -1])
    return reversed_list

#11.
def unique_values_of_arry(arry:list) -> list:
    unique_values_list = []
    for value in arry:
        if value not in unique_values_list:
            unique_values_list.append(value)
    return unique_values_list
