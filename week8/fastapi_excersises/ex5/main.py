from fastapi import FastAPI
import uvicorn

app = FastAPI()

grades = {
    "1": {"name": "Moshe", "grade": 88},
    "2": {"name": "Yaakov", "grade": 75},
    "3": {"name": "David", "grade": 92}
    }


@app.get("/students")
def students():
    return grades

@app.get("/students/top")
def top_student():
    max_grade = 0
    for student in grades.values():
        if student["grade"] > max_grade:
            max_grade = student["grade"]
    
    top_students = [v for v in grades.values() if v["grade"] == max_grade]

    return top_students[0] if len(top_students) == 1 else top_students

@app.get("/students/average")
def get_average():
    
    the_grades = [grade["grade"] for grade in grades.values()]
    students_avg = sum(the_grades) / len(the_grades)
    
    if not the_grades:
        return 0
    
    else:
        return {"average":students_avg}

@app.get("/students/count")
def count():
    if grades:
        return {"num of students": len(grades)}
    else:
        return "There have 0 grades."

@app.get("/students/{student_id}")
def student(student_id:str):
    return grades.get(student_id, "error, no such student id.")
    

if __name__ == "__main__":
    uvicorn.run(app)