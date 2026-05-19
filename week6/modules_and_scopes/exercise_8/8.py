import math
def public_names(m):
    return [func for func in dir(m) if func[0] != "_"]
