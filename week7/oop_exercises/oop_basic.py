#1.
class Dog:
    """docstring"""
    def __init__(self, name):
        """docstring"""
        self.name = name
    
    def bark(self):
        """socstring"""
        return f"{self.name} says woof"


#2.
class Rectangke:
    """docstring"""
    def __init__(self, width, height):
        """docstring"""
        self.width = width
        self.height = height
    
    def area(self):
        """docstring"""
        return self.width * self.height


#3.
class Counter:
    """docstring"""
    def __init__(self, count = 0):
        """docstring"""
        self.count = count
    
    def increment(self):
        """docstring"""
        self.count += 1
    
    def value(self):
        return self.count


#4.
class Point:
    """docstring"""
    def __init__(self, val1, val2):
        """docstring"""
        self.val1 = val1
        self.val2 = val2
    
    def __str__(self):
        """return string, 
        what returns will be printed when I print the instance"""
        return f"{self.val1}, {self.val2}"


#5.
class BankAccount:
    """docstring"""
    def __init__(self, balance = 0):
        self.balance = balance
    
    def deposit(self, amount):
        """docstring"""
        self.balance += amount
    
    def withdraw(self, amount):
        """docstring"""
        if self.balance >= amount:
            self.balance -= amount
        else:
            print("The amount is more higher then your balance.")


#6.
class Temperature:
    """docstring"""
    def __init__(self, celsius_valu):
        """docstring"""
        self.celsius_value = celsius_valu
    
    def to_fehrenheit(self):
        return self.celsius_value * 1.8 + 32


#7.
class Student:
    """docstring"""
    school = "Kodcode"
    def __init__(self, name):
        self.name = name

s1 = Student("david")
s2 = Student("gal")
print(s1.school, s1.name)
print(s2.school, s2.name)


#8.
class Player:
    """docstring"""
    players = 0
    def __init__(self):
        """docstring"""
        Player.players += 1

p1 = Player()
p2 = Player()
print(p1.players)


#9.
class Money:
    """docstring"""
    def __init__(self, amount):
        """docstring"""
        self.amount = amount
    
    def is_more_then(self,other):
        """docstring"""
        return True if self.amount > other.amount else False

m1 = Money(50)
m2 = Money(100)
print(m2.is_more_then(m1))


#10.
class Playlist:
    """docstring"""
    def __init__(self,titles = []):
        """docstring"""
        self.titles = titles
    
    def add(self, title):
        """docstring"""
        self.titles.append(title)
    
    def remove(self, title):
        """docstring"""
        self.titles.remove(title)
    
    def count(self):
        """docstring"""
        return len(self.titles)
    
    def __str__(self):
        return ", ".join(self.titles)

