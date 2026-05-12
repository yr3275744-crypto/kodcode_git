#1.
age = int(input("enter your age:"))
if 0 > age  or age > 120:
    print("Invalide")
elif 0 <= age <= 12:
    print("Child")
elif 13 <= age <= 17:
    print("Teen")
else:
    print("Adult")

#2.
character = input("enter an Engkish letter:")
if not "A" <= character <= "z":
    print("Invalid")
elif character in "aeiou":
    print("Vowel")
else:
    print("Consanant")

#3.
age = int(input("enter your age:"))
existence_vip_card = (input("if you have vip card, enter yes. else enter no:"))
if age >= 18 and existence_vip_card == "yes":
    print("You are welcome") 
elif age in [19,20,21]:
    print("You are welcome")
else:
    print("Rejected")

#4.
correct_password = "123456789"
user_password = input("Enter the password:")
if user_password == correct_password:
    print("Access Granted")
elif len(user_password) < 8:
    print("Too short")
else:
    print("Wrong password")

#5.
x = int(input("enter the x value in coordinate:"))
y = int(input("enter the y value in coordinate:"))
if (x == 10 or x == 50) and (y == 20 or y == 80):
    print("On the edge")
elif (10 <= x <= 50) and (20 <= y <= 80):
    print("Inside the rectangle")
else:
    print("Outside the rectangle")

#6.
name = input("Enter your name:")
name_for_greeting = name or "Anonymous"
print(f"Hello {name_for_greeting}")

#8.
num_1 = int(input("Enter a number:"))
num_2 = int(input("Enter a number:"))
num_3 = int(input("Enter a number:"))
positive_amount = bool(num_1 > 0) + bool(num_2 > 0) + bool(num_3 > 0)
print(f"there have {positive_amount} positive numbers.")

#10.
score = int(input("Enter a score:"))
print("A") if 90 <= score <= 100 else print("B") if 80 <= score <= 89 else print("C") if 70 <= score <= 79 else print("F") if score < 70 else print("Invalid")