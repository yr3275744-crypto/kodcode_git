import mysql.connector
import db

def get_summary():
    """docsting"""
    connection = db.get_connection()
    cursor = connection.cursor(dictionary = True)
    
    cursor.execute("SELECT COUNT(*) AS total FROM soldiers")
    total = cursor.fetchone()["total"]

    cursor.execute("SELECT COUNT(*) AS active FROM soldiers WHERE active = True")
    active = cursor.fetchone()["active"]

    cursor.execute("SELECT COUNT(*) AS inactive FROM soldiers WHERE active = False")
    inactive = cursor.fetchone()["inactive"]

    cursor.close()
    connection.close()

    return {"total": total, "active":active, "inactive":inactive}

def count_by_unit():
    """docstring"""
    connection = db.get_connection()
    cursor = connection.cursor(dictionary = True)
    
    cursor.execute("""SELECT unit, COUNT(unit) as unit_soldiers 
                   FROM soldiers GROUP BY unit
                   ORDER BY unit_soldiers DESC""")
    rows = cursor.fetchall()

    cursor.close()
    connection.close()
    return rows

def get_units_with_multiple_soldiers():
    """docstring"""
    connection = db.get_connection()
    cursor = connection.cursor(dictionary = True)
    
    cursor.execute("""SELECT unit, COUNT(unit) as unit_soldiers 
                   FROM soldiers GROUP BY unit
                   HAVING unit_soldiers > 1""")
    rows = cursor.fetchall()

    cursor.close()
    connection.close()
    return rows

def get_missing_data():
    """docstring"""
    connection = db.get_connection()
    cursor = connection.cursor(dictionary = True)
    
    cursor.execute("SELECT * FROM soldiers WHERE ranky IS NULL")
    rows = cursor.fetchall()

    cursor.close()
    connection.close()
    return rows


if __name__ == "__main__":
    print(get_summary())
    print(count_by_unit())
    print(get_missing_data())
    print(get_units_with_multiple_soldiers())