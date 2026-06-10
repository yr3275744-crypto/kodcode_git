from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
import uvicorn
import db
import reports

app = FastAPI()

class SoldierIn(BaseModel):
    """docstring"""
    name: str
    ranky: str | None = None
    unit: str | None
    active: bool = True


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

@app.get("/stats/summary")
def get_summary():
    return reports.get_summary()

@app.get("/stats/units")
def get_count_by_unit():
    return reports.count_by_unit()

@app.get("/stats/understaffed")
def get_sum_unit_soldiers():
    return reports.get_units_with_multiple_soldiers()

@app.get("/soldiers/missing-rank")
def get_soldiers_missing_rank():
    return reports.get_missing_data()

@app.post("/soldiers", status_code = 201)
def add_soldier(body:SoldierIn):
    new_id = db.create_line(body.name, body.ranky, body.unit, body.active)
    return {"id":new_id, "message":"Soldier created"}

@app.get("/soldiers/{soldier_id}")
def get_soldier(soldier_id:int):
    soldier = db.get_by_id(soldier_id)
    if soldier:
        return soldier
    else:
        raise HTTPException(status_code = 404, detail = "Soldier not found")

@app.put("/soldiers/{soldier_id}")
def update_soldier(soldier_id:int, body:SoldierIn):
    data = body.model_dump(exclude_none=True)
    success = db.update_line(soldier_id, data)
    if success:
        return {"message": "updated"}
    else:
        raise HTTPException(status_code=404, detail = "Soldier not found")

@app.delete("/suldiers/{soldier_id}")
def delete_soldier(soldier_id:int):
    is_deleted = db.delete_line(soldier_id)
    if is_deleted:
        return {"message":"the soldier deleted successfully"}
    else:
        raise HTTPException(status_code=404, detail="Soldier not found")

if __name__ == "__main__":
    uvicorn.run(app, port=8000)
