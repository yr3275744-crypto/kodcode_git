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


