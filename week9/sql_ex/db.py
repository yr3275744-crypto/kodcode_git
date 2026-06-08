import mysql.connector
import time

time.sleep(2)
def get_conection():
    """docstring"""
    return mysql.connector.connect(host="localhost",
                               port=3306,
                               user="root",
                               password="root",
                               database="soldiers_db")


def get_schema() -> list:
    """docstring"""
    conn = get_conection()
    cursor = conn.cursor()
    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column": row[0], "type": row[1]} for row in rows]


def get_all() -> list:
    """docstring"""
    conn = get_conection()
    cursor = conn.cursor(dictionary = True)
    cursor.execute("SELECT * FROM soldiers")
    rows = cursor.fetchall()

    cursor.close()
    conn.close()
    return rows

def get_by_id(soldier_id:int) -> dict | None:
    conn = get_conection()
    cursor = conn.cursor(dictionary = True)
    cursor.execute("SELECT * FROM soldiers WHERE id = %s", soldier_id)
    row = cursor.fetchone()

    cursor.close()
    conn.close()
    return row

def create_line(name:str, ranky:str, unit:str) -> int:
    """docstring"""
    conn = get_conection()
    cursor = conn.cursor()
    
    cursor.execute("INSERT INTO soldiers (name, ranky, unit) VALUES (%s, %s, %s)", (name, ranky, unit))
    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()
    return new_id