import mysql.connector
import time
time.sleep(2)


conn = mysql.connector.connect(host="localhost",
                               port=3306,
                               user="root",
                               password="root",
                               database="soldiers_db")


create_table_sql = """
CREATE TABLE IF NOT EXISTS soldiers (
id INT PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(100) NOT NULL,
ranky VARCHAR(50),
unit VARCHAR(100),
active BOOLEAN DEFAULT TRUE
)
"""

cursor = conn.cursor()
cursor.execute(create_table_sql)
conn.commit()
print("Table created successfully.")
cursor.close()
conn.close()