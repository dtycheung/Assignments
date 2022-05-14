/* eslint-disable no-unused-vars */
import { AgGridReact } from "ag-grid-react";
import { useState } from "react";


export function HistoryTable({ data }) {

  const columns = [
    { headerName: "Date", field: "date", flex: 1  },
    { headerName: "Open", field: "open" , flex: 1 },
    { headerName: "High", field: "high", flex: 1  },
    { headerName: "Low", field: "low", flex: 1  },
    { headerName: "Close", field: "close" , flex: 1 },
    { headerName: "Volume", field: "volume" , flex: 1 },

  ];
  const defaultColDef = { sortable: true};

  return (
    <div
      className="ag-theme-balham"
      style={{ height: "500px", width: "auto", maxwidth: "700px" }}
    >
      <AgGridReact
        columnDefs={columns}
        rowData={data}
        pagination={true}
        paginationPageSize={15}
        defaultColDef={defaultColDef}
      />
    </div>
  );
}
