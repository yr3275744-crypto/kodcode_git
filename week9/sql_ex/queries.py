import mysql.connector
import db
import time

# time.sleep(2)

def get_by_runk(rank:str):
    """docstring"""
    connection = db.get_connection()
    cursor = connection.cursor()
    cursor.execute("SELECT * from soldiers WHERE ranky = %s", (rank,))
    rows = cursor.fetchall()
    cursor.close()
    connection.close()
    return rows

def get_active_sorted(order:str = "asc"):
    """docstring"""
    if order not in ("asc", "desc"):
        order = "asc"

    order = order.upper()
    connection = db.get_connection()
    cursor = connection.cursor()
    cursor.execute(f"SELECT * FROM soldiers WHERE active = TRUE ORDER BY name {order}")
    rows = cursor.fetchall()
    cursor.close()
    connection.close()
    return rows


if __name__ == "__main__":
    print(get_active_sorted("dhydhdh"))