FALSE_VALUE = "-1"

#1.
def return_active_users_names_list(users_list):
    names_list = []
    for user in users_list:
        is_active = user[2]
        if user[1] >= 18 and is_active:
            names_list.append(user[0])
    return names_list

users = [
    ["Dan", 25, True],
    ["Noa", 16, True],
    ["Yael", 30, False],
]
print(return_active_users_names_list(users))
      
#2.
def check_is_email(user_email):
    if user_email:
        return user_email 
    else:
        print("Invalid user")
        return FALSE_VALUE

def check_quantity(quantity, stock):
    if quantity <= 0 or quantity > stock:
        print("Invalid quantity")
        return FALSE_VALUE
    else:
        return quantity

def calc_purchase_price(product_price, quantity):
    price = product_price * quantity
    if quantity >= 10:
        price *= 0.9
    if quantity >= 50:
        price *= 0.85
    return price

def update_stock(stock, quantity):
        stock -= quantity
        return stock

def print_current_order(order_user, order_product, order_status, order_quantity, order_total):
    print(f"Order {order_status}: {order_user} bought {order_quantity}x {order_product} for ${order_total}")

def handle_purchase(user_email, product_name, product_price, stock, quantity):
    order_user = check_is_email(user_email)
    order_product = product_name
    order_quantity = check_quantity(quantity, stock)
    order_total = calc_purchase_price(product_price, quantity)
    order_status = "confirmed"
    
    if order_user == FALSE_VALUE or order_quantity == FALSE_VALUE:
        return ()

    print_current_order(order_user,order_product,order_status,order_quantity, order_total)
    
    return order_user, order_product, order_quantity, order_total, order_status


#3.
def check_new_name(new_name):
    if not new_name or len(new_name) < 2:
        print("Error: invalid name")
        return FALSE_VALUE
    return new_name

def check_new_grade(new_grade):
    if new_grade < 0 or new_grade > 100:
        print("Error: grade must be 0-100")
        return FALSE_VALUE
    return new_grade

def add_student(names, grades, new_name, new_grade):
    names.append(new_name)
    grades.append(new_grade)

def calc_stats(grades):
    total = sum(grades)
    average = total / len(grades)
    top_count = sum(1 for grade in grades if grade >= 90)
    failing_count = sum(1 for grade in grades if grade < 56)
    return (total, average, top_count, failing_count)

def print_report(names, grades, average, top_count, failing_count):
    print("=== Student Report ===")
    for i in range(len(names)):
        print(f"  {names[i]}: {grades[i]}")
    print(f"Average: {average:.1f}")
    print(f"Top students: {top_count}")
    print(f"Failing: {failing_count}")

def save_to_file(names, grades):
    with open("students.txt", "w") as f:
        for i in range(len(names)):
            f.write(f"{names[i]},{grades[i]}\n")

def manage_students(names, grades, new_name, new_grade):
    new_name = check_new_name(new_name)
    new_grade = check_new_grade(new_grade)
    if new_name == FALSE_VALUE or new_grade == FALSE_VALUE:
        return names, grades
    add_student(names, grades, new_name, new_grade)
    stats = calc_stats(grades)
    average = stats[1]
    top_count = stats[2]
    failing_count = stats[3]
    print_report(names, grades, average,top_count, failing_count)
    save_to_file(names, grades)

    return names, grades
