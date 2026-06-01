import requests

def safe_get(url:str):
    """docstring"""
    respons = requests.get(url)
    status = respons.status_code
    if status == 200:
        return respons.json()
    if status == 404:
        return None
    else:
        raise Exception("http error.")