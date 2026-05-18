#1.
def remove_doplicates(a_list:list) -> list:
    
    return list(set(a_list))


#2.
def count_unicqe_elements(a_list:list) -> int:
    
    set_elements = set(a_list)
    counter = 0
    
    for element in set_elements:
        counter += 1

    return counter



#3.
def common_elements(list1:list, list2:list) -> list:
    
    set1, set2 = set(list1), set(list2)
    set3 = set1 & set2
    common_elements = list(set3)
    common_elements.sort()
    
    return common_elements


#4.
def xor_elements(list1:list, list2:list) -> list:
    
    set1, set2 = set(list1), set(list2)
    set3 = set1 ^ set2
    xored_elements = list(set3)
    xored_elements.sort()
    
    return xored_elements


#5.
def subset(a:list, b:list) -> bool:
    
    a, b = set(a), set(b)
    
    return a <= b


#6.
def unique_characters(a_string:str) -> bool:
    
    chracters_set = set()
    
    for char in a_string:
        if char not in chracters_set:
            chracters_set.add(char)
        else:
            return False
    
    return True


#7.
def first_repeated_element(a_list:list) -> object:

    elements_set = set()

    for element in a_list:
        if element not in elements_set:
            elements_set.add(element)
        else:
            return element
    
    return None


#8.
def distinct_words(words_string:str) -> int:
    
    return len({word.lower() for word in words_string.split()})


#9.
def pair_sum_exists(integers_list:list[int], target:int) -> bool:

    numbers_set = set()
    
    for num in integers_list:
        if target - num in numbers_set:
            return True
        else:
            numbers_set.add(num)
    return False


#10.
def symmetric_difference(list1:list, list2:list) -> list:
   
    set1, set2 = set(list1), set(list2)
    set3 = set1.union(set2) 
    new_list = []
   
    for value in set3:
        if (value not in set1) or (value not in set2):
            new_list.append(value)
            
    new_list.sort()
    
    return new_list
