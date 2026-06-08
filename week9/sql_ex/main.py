from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
import uvicorn
import db

app = FastAPI()

class SoldierIn(BaseModel):
    """docstring"""
    name: str
    ranky: str | None = None
    unit: str | None


@app.post("/setup")
def run_setup():
    return {"status": "ok"}

@app.get("/schema")
def get_schema():
    columns = db.get_schema()
    return {"columns": columns}

@app.get("/soldiers")
def get_all_soldiers():
    return {"soldiers": db.get_all()}


@app.post("/soldiers", status_code = 201)
def add_soldier(body:SoldierIn):
    new_id = db.create_line(body.name, body.ranky, body.unit)
    return {"id":new_id, "message":"Soldier created"}

@app.put("/soldiers/{soldier_id}")
def update_soldier(soldier_id:int, body:SoldierIn):
    data = body.model_dump(exclude_none=True)
    success = db.update_line(soldier_id, data)
    if success:
        return {"message": "updated"}
    else:
        raise HTTPException(status_code=404, detail = "Soldier not found")

@app.get("/soldiers/{soldier_id}")
def get_soldier(soldier_id:int):
    soldier = db.get_by_id(soldier_id)
    if soldier:
        return soldier
    else:
        raise HTTPException(status_code = 404, detail = "Soldier not found")



if __name__ == "__main__":
    uvicorn.run(app, port=8000)
