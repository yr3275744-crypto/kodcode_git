#1.
count = 0

def bump():
    global count
    count += 1

def value():
    return count


#2.
def make_counter():
    num = 0
    def counter():
        nonlocal num
        num += 1
        return num
    return counter


#3.
x = "global"
def outer():
    x = "enclosing"
    def inner():
        x = "local"
        print(x)
    inner()
    print(x)
outer()
print(x)


#4.
#the problam: the name "list" is shaowed now. 
#here the corect version:
print(list(range(5)))
