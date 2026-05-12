#1.
for i in range(1,10):
    if i % 2 == 0:
        continue
    elif i == 7:
        break
    else:
        print(i)

#2.
#I used flag instead while true, recommended by Yaniv.
flag = 1
while flag:
    user_password = input("Enter the password:")
    if user_password == "1234":
        print("Welcome!")
        flag = 0
    else:
        print("Try again")

#3.
#we need while loop because we don't know the number of iterations
flag = 1
product_names = []
while flag:
    product_name_or_exit = input("Enter product name, or 'done' to finish:")
    if product_name_or_exit == "done":
        flag = 0
    else:
        product_names.append(product_name_or_exit)
print(product_names)

#
for i in range(1,4):
    for j in range(1,4):
        print(i, j)
        if j == 2:
            break

#4.
user_string = input("Enter a string:")
aeiou_letters = 0
for character in user_string:
    if character.lower() in "aeiou":
        aeiou_letters += 1
print(f"There are {aeiou_letters} aeiou letters in the string")

#5.
for i in range(1, 6):
    line = ""
    for j in range(1, 6):
        line += str(i * j) + " "
    print(line)

#6.
user_string = input("Enter a string:")
reversed_string = ""
accumulator = len(user_string)
for i in range(len(user_string)):
    reversed_string += user_string[accumulator -1]
    accumulator -= 1
print(reversed_string)

#7.
a_positive_integer = 4573
even_digits = 0
while a_positive_integer:
    if a_positive_integer % 2 == 0:
        even_digits += 1
    a_positive_integer = a_positive_integer // 10
print(even_digits)

#8.
a_string = "abc"
the_new_string = ""
for char in a_string:
    the_new_string += char *2
print(the_new_string)

#9.
the_highest_num = 0
while True:
    num = int(input("Enter a positive number or 0:"))
    if num > the_highest_num:
        the_highest_num = num
    if num == 0:
        break
print(the_highest_num)

#10.
a_string = input("Enter a string:")
flag = 1
for char in a_string:
    if (not char.isalpha()) and (not char.isdigit()):
        flag = 0
if flag == 1:
    print("True")
else:
    print("False")

#11.
num = 123
digits_of_num = []
while num:
    digits_of_num.append(num % 10)
    num = num // 10
counter = len(digits_of_num)
for digit in digits_of_num:
    num += digit * 10 ** (counter -1)
    counter -= 1
print(num)
