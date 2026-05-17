#1.
def sum_list(list:list[int]) -> int:
    
    the_sum = 0
    
    for num in list:
        the_sum += num
   
    return the_sum


#2.
def max_element(list:list[int]) -> int:
    
    max_element = list[0]
    
    for num in list:
        if num > max_element:
            max_element = num
    
    return max_element


#3.
def count_occurrences(list:list, value:any) ->int:
    
    occurrences = 0
    
    for item in list:
        if item == value:
            occurrences += 1
    
    return occurrences


def reverse_list(list:list) -> list:
    
    new_list = []

    for i in range(len(list)-1, -1, -1):
        new_list.append(list[i])
    
    return new_list


#5.
def remove_aplicates(list:list) -> list:
    
    new_list = []
    items_set = set()
    
    for item in list:
        if item not in items_set:
            new_list.append(item)
            items_set.add(item)

    return new_list


#6.
def second_largest(list:list[int | float]):
    
    list.sort(reverse= True)
    max_value = list[0]
    
    for i in range(1, len(list)):
        if list[i] != max_value:
            return list[i]
    
    return None


#7.
def merge_sorted_lists(list1:list, list2:list) -> list:

    new_list = list1.copy()
    new_list.extend(list2)
    new_list.sort()

    return new_list


#8.
def rotate_a_list(list:list, k:int) -> list:
    if k > len(list):
        k -= len(list)
    new_list = list[-k:] + list[:k + 1]
    return new_list
