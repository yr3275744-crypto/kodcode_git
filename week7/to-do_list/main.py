def load_tasks(filename):
    
    tasks = []
    with open(filename , "r") as f:
        for line in f:
            line = line.split("|")
            tasks.append({"id":line[0], "status": line[1], "desc":line[2].strip("\n")})
        
    return tasks


def save_tasks(filename, tasks):
    
    with open(filename , "w") as f:
        for line in tasks:
            f.write(f"{line["id"]}|{line["status"]}|{line["desc"]} \n")
    
    return None


def add_task(filename, description):
    
    tasks = load_tasks(filename)
    id = len(tasks) + 1
    with open(filename, "a") as f:
        f.write(f"{id}|pending|{description}\n")
    
    return None


def complete_task(filename, task_id):

    tasks = load_tasks(filename)
    task_id = str(task_id)
    is_status_chenced = False

    for task in tasks:
        if task["id"] == task_id:
            task["status"] = "done"
            save_tasks(filename, tasks)
            is_status_chenced = True
    
    if is_status_chenced:
        print("done!")
    else:
        print("The task id does not exists.")
    
    return None


def list_tasks(filename):
    
    tasks = load_tasks(filename)
    for task in tasks:
        print(f"{"[v]" if task["status"] == "done" else "[ ]"} {task["id"]} | {task["desc"]}")

    return None

def main():
    FILENAME = "tasks.txt"
    while True:
        print('\n=== To-Do List Manager ===')
        print('1. View Tasks')
        print('2. Add Task')
        print('3. Mark as Completed')
        print('4. Exit')
        
        choice = input('Choice: ')
        
        if choice == '1':
            list_tasks(FILENAME)
        elif choice == '2':
            desc = input('Task description: ')
            add_task(FILENAME, desc)
            print('Task added!')
        elif choice == '3':
            task_id = int(input('Task number: '))
            complete_task(FILENAME, task_id)
        elif choice == '4':
            print('Goodbye!')
            break
        else:
            print('Invalid choice')

if __name__ == '__main__':
    main()