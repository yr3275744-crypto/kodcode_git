#1.
def sum_tuple(a_tuple:tuple[int | float]) -> int:
    
    sum_elements = 0
    
    for num in a_tuple:
        sum_elements += num
    
    return sum_elements


#2.
def max_element(a_tuple:tuple[int]) -> int:
    
    max_element = a_tuple[0]
    
    for num in a_tuple:
        if num > max_element:
            max_element = num
    
    return max_element


#3.
def count_occurrences(the_tuple:tuple, value:object) -> int:
    
    count_occurrences = 0
    
    for item in the_tuple:
        if item == value:
            count_occurrences += 1
    
    return count_occurrences


#4.
def reverse_tuple(the_tuple:tuple) -> tuple:
    
    temporary_list = []
    
    for i in range(len(the_tuple) -1, -1, -1):
        temporary_list.append(the_tuple[i])
    
    return tuple(temporary_list)

#5.
def swap_pairs(a_tuple:tuple) -> tuple:
    
    swaped_pairs = []
    
    for i in range(0, len(a_tuple)-1, 2):
        swaped_pairs.append(a_tuple[i+1])
        swaped_pairs.append(a_tuple[i])
    
    return tuple(swaped_pairs)

#6.
def min_and_max(a_tuple:tuple) -> tuple:
    
    min_element = a_tuple[0]
    max_element = a_tuple[0]
    
    for num in a_tuple:
        if num < min_element:
            min_element = num
        elif num > max_element:
            max_element = num
    
    return (min_element, max_element)

#7.
def distance_between_points(tuple1:tuple, tuple2:tuple) -> int:
    
    d = ((tuple1[0] - tuple2[0]) ** 2 + (tuple1[1] - tuple2[1]) ** 2) ** 0.5
    return d


#8.
def merge_and_sort(tuple1:tuple[int], tuple2:tuple[int]) -> tuple:
    
    tuple3 = tuple1 + tuple2
    list_tuple3 = list(tuple3)
    list_tuple3.sort()
    tuple3 = tuple(list_tuple3)
    
    return tuple3


#9.
def freqency_table(a_tuple:tuple) -> tuple:

    dict_items = dict()
    
    for item in a_tuple:
        if item not in dict_items:
            dict_items[item] = 1
        else:
            dict_items[item] += 1
    
    return tuple((key, dict_items[key]) for key in dict_items)


#10.
def rotate_tuple(a_tuple:tuple, k:int) -> tuple:
    return a_tuple[-k:] + a_tuple[:-k]
