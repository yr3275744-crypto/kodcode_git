import logging


logging.basicConfig(level = logging.INFO, format = "%(asctime)s | %(levelname)s | %(message)s")
logger = logging.getLogger(__name__)

def adding(a, b, user):
    logger.info("ss", extra={"user_name":user["name"]})
    c =  a+ b
    logger.warning("aa")
    return c

g = adding(4, 4, {"name": "david"})



# logging.basicConfig(level=logging.DEBUG, format="%(asctime)s | %(levelname)s| %(message)s")
# logger = logging.getLogger(__name__)
# def divide(a, b):
#     logger.debug("Starting divide with a=%s, b=%s", a, b)
#     try:
#         result = a / b
#         logger.info("Division completed successfully: result=%s", result)
#         return result
#     except ZeroDivisionError:
#         logger.exception("Division failed because b was zero")
#         return None
# print(divide(10, 2))
# print(divide(10, 0))