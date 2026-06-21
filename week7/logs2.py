import logging
import json
#question 1
# 1.x
# 2.v
# 3.x
# 4.x
# 5.v
# 6.v
# 7.x


#question 2
#1.info
#2.error
#3.debug
#4.error
#5.warning
#6.info
#


#question 3
#logger.info('User logged in successfully')
#logger.error('ERROR: payment failed')


#question 4
# %(asctime)s: ___תאריך הלוג____________________________________________
# %(levelname)s: ___________רמת הלוג____________________________________
# %(name)s: ________________________שם הלוגר_______________________
# %(message)s: _______________________הודעת הלוג________________________


#question 5
logging.basicConfig(level=logging.INFO, format='%(levelname)s | %(message)s')
logger = logging.getLogger(__name__)
logger.info('Application started')


#question 6
logging.basicConfig(level=logging.DEBUG, format='%(levelname)s | %(message)s')
logger = logging.getLogger(__name__)

def process_payment(user_id, amount):
    logger.info(f'Starting payment for user {user_id}')
    if amount <= 0:
        logger.error('ERROR: Invalid amount')
        return
    if amount > 10000:
        logger.warning('WARNING: Large transaction')
    logger.info(f'Payment of {amount} completed for user {user_id}')


#question 7
logger = logging.getLogger('payments')
logger.setLevel(level = logging.DEBUG)
file_handler = logging.FileHandler("app.log", encoding = "utf8")
formater = logging.Formatter("%(asctime)s | %(levelname)s | %(name)s | %(message)s" )
file_handler.setFormatter(formater)
logger.addHandler(file_handler)

def create_logs():
    logger.info("bla bla")
    logger.debug("how?")
    logger.error("no!")


#question 8.
def read_config(filepath):
    logger.debug("Try to read a file%s",filepath)
    try:
        with open(filepath) as f:
            data = f.read()
        logger.info("The read comlete succesfully.")
        return data
    except FileNotFoundError:
        logger.exception("fail to read the file - file is not found")
        return None


#question 9
def write_structured_log(level, moudule, message, **extra):
    new_dict = {"level":level, "moudule":moudule, "message":message}
    new_dict.update(extra)
    log_json = json.dumps(new_dict)
    print(log_json)


#question 10
#logger.info('done') : חסר פירוט. יש להוסיף מה נעשה.
#logger.error('failed') : חסר פירוט כנ"ל. להוסיף מה נכשל.
#logger.info('user=%s', user_id) : יש יותר פירוט מה המשתמש. 
#אפשר להוסיף מה ההקשר שהמידע נצרך אליו


#question 11
#1: info
#2. error
#3. debug
#4. warning
#5. info
#6. error, and debug


#question 12
logging.basicConfig(level=logging.DEBUG)
logger = logging.getLogger(__name__)
def register_user(email, password, age):
    logger.debug('check the user age, if over 18')
    if age < 18:
        logger.error('the user age is below 18')
        return
    logger.info('the user is valid. email=%s has_password=%s', email, bool(password))
    logger.info('the register user succeeded')


#question 13
