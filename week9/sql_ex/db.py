import mysql.connector
import time

time.sleep(2)
def get_conection():
    return mysql.connector.connect(host="localhost",
                               port=3306,
                               user="root",
                               password="root",
                               database="soldiers_db")


def get_schema() -> list:
    conn = get_conection()
    cursor = conn.cursor()
    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column": row[0], "type": row[1]} for row in rows]

