import React from "react";
import { AgGridReact } from "ag-grid-react";
import { useState, useEffect } from "react";
import { SelectMenu } from "./SelectMenu";
import { SearchBar } from "./SearchBar";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import { ColDef, ICellRendererParams } from "ag-grid-community";

function linkcomponent(props: ICellRendererParams) {
  return (
    <a href={"http://localhost:3000/quote/?symbol=" + props.value}>
      {props.value}
    </a>
  );
}

export function GenTable({ data }) {
  const [select, setSelect] = useState("");
  const [searchBar, setSearchBar] = useState("");
  const [rowData, setRowData] = useState(data);
  const [rowData2, setRowData2] = useState([]);
  const columns: ColDef[] = [
    {
      headerName: "Symbol",
      field: "symbol",
      cellRenderer: linkcomponent,
      flex: 1,
    },
    { headerName: "Name", field: "name", flex: 1 },
    { headerName: "Sector", field: "sector", flex: 1 },
  ];
  const defaultColDef = {
    sortable: true,
    resizable: true,
  };

  const gridOptions = {
    paginationPageSize: 20,
    pagination: true,
  };

  useEffect(() => {
    (async () => {
      if (select !== "" && select !== "All") {
        setRowData2(rowData.filter((x) => x["sector"] === select));
      } else {
        setRowData2(rowData);
      }
    })();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [select]);

  useEffect(() => {
    if (searchBar !== "") {
      setRowData2(rowData);
      let sym = rowData.filter((x) =>
        x["symbol"].includes(searchBar.toUpperCase())
      );
      let nam = rowData.filter((x) =>
      x["name"].toUpperCase().includes(searchBar.toUpperCase()));
    let newArr = sym.concat(nam); 
    setRowData2(newArr);

    } else {
      setRowData2(rowData);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [searchBar]);

  return (
    <div className="stocktable" 
    style={{ height: "530px", width: "auto" }}>
      <Row style={{ padding: "10px" }}>
        <Col lg={5}>
          <SearchBar onSubmit={setSearchBar} />
        </Col>
        <Col style={{ textAlign: "right", fontSize: "24px" }}>Select: </Col>
        <Col lg={5}>
          <SelectMenu
            data={data}
            onChange={setSelect}
            style={{
              height: "auto",
              width: "75%",
              maxwidth: "700px",
              color: "black",
            }}
          />
        </Col>
      </Row>

      <AgGridReact
        columnDefs={columns}
        rowData={rowData2}
        defaultColDef={defaultColDef}
        reactNext={true}
        gridOptions={gridOptions}
      />
    </div>
  );
}
