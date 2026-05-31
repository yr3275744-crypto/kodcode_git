from fastapi import FastAPI
import uvicorn
from datetime import datetime
app = FastAPI()

@app.get("/status")
def get_time():
    return {"time":datetime.now(), "server name":"rude server"}

if __name__ == "__main__":
    uvicorn.run(app)