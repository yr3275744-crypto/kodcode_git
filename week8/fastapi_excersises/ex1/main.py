from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/ping")
def ping():
    return {"status":"pong"}

@app.get("/greet/{name}")
def greet(name:str) -> dict:
    return {"mesage": f"Hello, {name}!"}

if __name__ == "__main__":
    uvicorn.run(app)