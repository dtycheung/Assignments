
export function DateSelector({userData, onChange, type}) {
    let startpoint = 0;
    if(type ==="end"){
         startpoint = 99;
    }
  return (
    <div className="ag-theme-balham">
              <input
              className="dateselect"
                type="date"
                id="startDate"
                onChange={x=>onChange(x.target.value)}
                min={userData[0]}
                max={userData[99]}
                defaultValue={userData[startpoint]}
              ></input>
    </div>
  );
}