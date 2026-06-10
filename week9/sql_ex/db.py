import mysql.connector
import setup
import time

time.sleep(2)

def get_connection():
    """docstring"""
    return mysql.connector.connect(host="localhost",
                               port=3306,
                               user="root",
                               password="root",
                               database="soldiers_db")


def get_schema() -> list:
    """docstring"""
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column": row[0], "type": row[1]} for row in rows]


def get_all() -> list:
    """docstring"""
    conn = get_connection()
    cursor = conn.cursor(dictionary = True)
    cursor.execute("SELECT * FROM soldiers")
    rows = cursor.fetchall()

    cursor.close()
    conn.close()
    return rows

def get_by_id(soldier_id:int) -> dict | None:
    conn = get_connection()
    cursor = conn.cursor(dictionary = True)
    cursor.execute("SELECT * FROM soldiers WHERE id = %s", (soldier_id,))
    row = cursor.fetchone()

    cursor.close()
    conn.close()
    return row

def create_line(name:str, ranky:str, unit:str, active:bool = True) -> int:
    """docstring"""
    conn = get_connection()
    cursor = conn.cursor()
    
    cursor.execute("INSERT INTO soldiers (name, ranky, unit, active) VALUES (%s, %s, %s, %s)", (name, ranky, unit, active))
    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()
    return new_id

def update_line(soldier_id:int, data:dict):
    """docstring"""
    conn = get_connection()
    cursor = conn.cursor()

    set_parts = [f"{key} = %s" for key in data.keys()]
    set_clause = ", ".join(set_parts)
    values = list(data.values()) + [soldier_id]
    
    cursor.execute(f"UPDATE soldiers SET {set_clause} WHERE id = %s", values)
    conn.commit()

    changed = (cursor.rowcount > 0)

    cursor.close()
    conn.close()
    return changed

def delete_line(soldier_id:int) -> bool:
    """docstring"""
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("DELETE FROM soldiers WHERE id = %s", (soldier_id,))
    conn.commit()

    deleted = cursor.rowcount > 0

    cursor.close()
    conn.close()
    return deleted


if __name__ == "__main__":
    update_line(1, {"Aca":50, "sfsf":"effggg"})