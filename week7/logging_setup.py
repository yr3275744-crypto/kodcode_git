import logging


def loggre(name):
    logger = logging.getLogger(name)
    logger.setLevel(logging.DEBUG)
    file_handler = logging.FileHandler("lll.py")
    stream_handler = logging.StreamHandler()
    formatter = logging.Formatter("%(asctime)s | %(name)s | %(levelname)s | %(message)s")
    file_handler.setFormatter(formatter)
    logger.addHandler(file_handler)
    logger.addHandler(stream_handler)
    return logger


