with open("diary.txt", "w") as f:
    f.writelines(["a\n", "b\n", "c\n"])

print("The diary created successfully!")

with open("diary.txt", "r") as f:
    content = f.read()

print(content)


def add_entry(filename:str, date:str, content:str):
    with open(filename, "a") as f:
        f.writelines([date, ":", content])

add_entry("diary.txt", "18 - 01 - 2024", "hello worled")


def search_diary(filename, keyword):
    with open(filename, "r") as f:
        keyword_lines = [line for line in f if  keyword in line]
    
    return keyword_lines

print(search_diary("diary.txt", "c"))
