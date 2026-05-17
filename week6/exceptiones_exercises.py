#1.
def safe_int(s):
    try:
        return int(s)
    except:
        return None


#2.
def safe_divide(a, b):
    try:
        return a / b
    except ZeroDivisionError:
        return "undefined"


#3.
def get_value(d, key):
    try:
        return d[key]
    except KeyError:
        return "missing"


#4.
def pare_ints(values):
    new_list = []
    for value in values:
        try:
            new_list.append(int(value))
        except ValueError:
            continue
    return new_list


#5.
def set_age(age):
    if age < 0 or age > 150:
        raise ValueError
    return age


#6.
def retry(func, n):
    for i in range(n):
        try:
            return func()
        except Exception as e:
            last_except = e
    raise last_except


#7.
def count_errors(funcs):
    exceptions_counter = 0
    
    for func in funcs:
        try:
            func()
        except Exception:
            exceptions_counter += 1
    
    return exceptions_counter


#8.
def load_config(path):
    try:
        with open(path) as f:
            line = f.readline()
            line = int(line)
    except Exception:
        raise RuntimeError("failed to load config") from Exception
