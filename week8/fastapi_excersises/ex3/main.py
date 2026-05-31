from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/calc/{a}/{op}/{b}")
def get_calc(op, a:int, b:int):
    
    try:
        a = int(a)
        b = int(b)
    except ValueError:
        raise ValueError("You must anter numbers.")
    if op == "div" and b == 0:
        return "You can not divide by zero."
    
    actions = {"add": a + b,
                "sub": a - b,
                "mul": a * b,
                "div": a / b}
    if actions.get(op):
        return {"operation":op, "result":actions[op]}
    else:
        return "The operation does not found."

if __name__ == "__main__":
    uvicorn.run(app, host = "127.0.0.1", port = 8000)