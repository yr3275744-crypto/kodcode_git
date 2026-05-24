def create_grades_file(filename):
    
    students = [
    ("Dan", [85, 90, 78]),
    ("MOMO", [92, 88, 95]),
    ("Yoni", [70, 65, 80]),
    ("Avi", [100, 95, 98]),
    ("Sara", [60, 72, 68]),
    ]

    with open(filename, "w") as f:
        for line in students:
            f.write(line[0])
            for val in line[1]:
                f.write("," + str(val))
            f.write("\n")
            

create_grades_file("grades.txt")

def calculate_averages(filename):
    
    averages = {}
    
    with open(filename, "r") as f:
        for line in f:
            line = line.split(",")
            numbers_line = [int(line[i]) for i in range(1, len(line))]
            averages[line[0]] = sum(numbers_line) / len(numbers_line)
    
    return averages


def save_results(averages:dict, output_filename:str):
    
    sorted_averages = dict(sorted(averages.items(), key = lambda x:x[1], reverse = True))

    with open(output_filename, "w") as f:
        f.write("=== Student Results ===\n")
        for k, v in sorted_averages.items():
           f.write(f"{k}:{v}\n") 
        
        the_highest_scor_student = [(k, v) for k, v in sorted_averages.items() if v == max(sorted_averages.values())]
        the_lowest_scor_student = [(k, v) for k, v in sorted_averages.items() if v == min(sorted_averages.values())]
        num_students_who_passed = 0
        for val in sorted_averages.values():
            if val >= 60:
                num_students_who_passed += 1
        
        f.write(f"average of averages: {sum(sorted_averages.values()) / len(sorted_averages)}\n")
        f.write(f"the highest score: {the_highest_scor_student[0][0]} ({the_highest_scor_student[0][1]})\n")
        f.write(f"the lowest score: {the_lowest_scor_student[0][0]} ({the_lowest_scor_student[0][1]})\n")
        f.write(f"The number of students who passed: {num_students_who_passed}")

averages = calculate_averages('grades.txt')
save_results(averages, 'results.txt')