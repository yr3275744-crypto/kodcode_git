from fastapi import FastAPI, HTTPException
import uvicorn
import db

app = FastAPI()

@app.post("/setup")
def run_setup():
    return {"status": "ok"}

@app.get("/schema")
def get_schema():
    columns = db.get_schema()
    return {"columns": columns}

@app.get("/soldiers")
def get_all_soldiers():
    return {"soldiers": []}

if __name__ == "__main__":
    uvicorn.run(app, port=8000)