from fastapi import FastAPI
import uvicorn

app = FastAPI()

@app.get("/")
def get_servies():
    return {"service": "my-api", "version": "1.0"}

@app.get("/users/admin")
def get_admin():
    return {"role": "admin", "access": "full"}

@app.get("/users/{user_id}")
def get_user(user_id:int):
    return {"user_id":user_id, "name":"david", "email":"example@example"}

if __name__ == "__main__":
    uvicorn.run(app)
    