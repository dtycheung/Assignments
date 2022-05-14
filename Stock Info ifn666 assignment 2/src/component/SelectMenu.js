import React, { useState, useEffect } from "react";
import Select from "react-select";

export function industheme(theme) {
  return {
    ...theme,
    borderRadius: 0,
    colors: {
      ...theme.colors,
      primary25: "#b0fbc6",
      primary: "green",
    },
  };
}

export function SelectMenu({ data, onChange, style }) {
  const [stocks, setStocks] = useState([]);
  let sector = [];
  stocks.map((x) => sector.push(x.sector));
  let uniSector = [...new Set(sector)];

  let options2 = [];
  options2.push({value: "All", label: "All"});
  uniSector.map((x) => options2.push({ value: x, label: x }));

  useEffect(() => {
    setStocks(data);
  }, [data]);

 
  return (
    <div style={style}>
      <Select
        theme={industheme}
        options={options2}
        onChange={x=>onChange(x.value)}
        placeholder="Select a Sector"
        isSearchable
        noOptionsMessage={() => "No industry matched."}
      />
    </div>
  );
}