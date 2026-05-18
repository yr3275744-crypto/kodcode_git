#1.
def sum_values(a_dict:dict[str:int]) -> int:
    
    sum_of_values = 0
    
    for val in a_dict.values():
        sum_of_values +=val
    
    return sum_of_values


#2.
def key_of_max_val(a_dict:dict[str:int]) -> str:
   
    if not a_dict:
        return
   
    max_value = None
    key = ""
    
    for k, v in a_dict.items():
        if not max_value or v > max_value:
            max_value = v
            key = k
   
    return key


#3.
def count_characters(a_string:str) -> dict:
    
    char_dict = {}
    
    for char in a_string:
        if not char_dict.get(char):
            char_dict[char] = 1
        else:
            char_dict[char] += 1
    
    return char_dict


#4.
def invert_a_dictionary(a_dict:dict) -> dict:
    
    swaped_dict = {}
    
    for k, v in a_dict.items():
        swaped_dict[v] = k
    
    return swaped_dict


#5.
def marge_dictionaries(dict1:dict, dict2:dict) -> dict:
    dict3 = dict1.copy()
    dict3.update(dict2)
    return dict3


#6.
def filter_dict_by_val(a_dict:dict[str:int],threshold:int) -> dict:
    new_dict = {k:v for k, v in a_dict.items() if v > threshold}
    return new_dict

#7.
def group_by_first_letter(a_list:list[str]) -> dict:
   
    groped_dict = {}
   
    for word in a_list:
        if word[0] not in groped_dict:
            groped_dict[word[0]] = [word]
        else:
            groped_dict[word[0]].append(word)
   
    return groped_dict


#8.
def word_frequency(words_string:str) -> dict:
   
    words_list = words_string.split()
    words_dict = {}
 
    for word in words_list:
        if word not in words_dict:
            words_dict[word] = 1
        else:
            words_dict[word] += 1
  
    return words_dict


#9.
def common_keys(dict1:dict, dict2:dict) -> list:
    keys_list = [key for key in dict1 if key in dict2]
    keys_list.sort()
    return keys_list


#10.
def most_frequent_value(a_dict:dict) -> object:
    
    count_dict = {}
   
    for v in a_dict.values():
        if not count_dict.get(v):
            count_dict[v] = 1
        else:
            count_dict[v] += 1
   
    max_freqient = max(count_dict.values())
    freqient_values = []

    for k, v in count_dict.items():
        if v == max_freqient:
            freqient_values.append(k)
    
    if len(freqient_values) == 1:
        return freqient_values[0]
    
    return tuple(freqient_values)

