import os


def safe_read_diary(filename):
    return os.path.isfile(filename)


with open("diary.txt", "w") as f:
    f.writelines(["a\n", "b\n", "c\n"])

print("The diary created successfully!")

with open("diary.txt", "r") as f:
    content = f.read()

print(content)


def add_entry(filename:str, date:str, content:str):
    
    if not safe_read_diary(filename):
        print("the file does not exists.")
        return None
    
    with open(filename, "a") as f:
        f.writelines([date, ":", content])


def search_diary(filename, keyword):
    
    if not safe_read_diary(filename):
        print("the file does not exists.")
        return None
    
    with open(filename, "r") as f:
        keyword_lines = [line for line in f if  keyword in line]
    
    return keyword_lines

