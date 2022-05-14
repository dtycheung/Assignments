/* eslint-disable react-hooks/exhaustive-deps */
import { Line } from "react-chartjs-2";
import React, { useEffect, useState } from "react";
import { Chart as chartJS } from "chart.js/auto";

export function LineChart({ userData }) {
  const [chartData, setChartData] = useState({
    labels: userData.map((data) => data.date),
    datasets: [
      {
        type: "line",
        label: "Close",
        data: userData.map((data) => data.close),
        backgroundColor: ["red"],
        borderWidth: 1,
      },{
        type: "line",
        label: "Open",
        data: userData.map((data) => data.open),
        backgroundColor: ["blue"],
        borderWidth: 1,
      },{
        type: "line",
        label: "High",
        data: userData.map((data) => data.high),
        backgroundColor: ["green"],
        borderColor: ["black"],
        borderWidth: 1,
      },{
        type: "line",
        label: "Low",
        data: userData.map((data) => data.low),
        backgroundColor: ["orange"],
        borderColor: ["black"],
        borderWidth: 1,
      },
    ],
  });


  useEffect(() => {
    //setChartData({})
    setChartData({
      labels: userData.map((data) => data.date),
      datasets: [
        {
          type: "line",
          label: "Close",
          data: userData.map((data) => data.close),
          backgroundColor: ["red"],
          borderColor:["pink"],
          color: ["black"],
          borderWidth: 1,
        },{
          type: "line",
          label: "Open",
          data: userData.map((data) => data.open),
          backgroundColor: ["blue"],
          borderColor: ["black"],
          borderWidth: 1,
        },{
          type: "line",
          label: "High",
          data: userData.map((data) => data.high),
          backgroundColor: ["green"],
          borderColor: ["black"],
          borderWidth: 1,
        },{
          type: "line",
          label: "Low",
          data: userData.map((data) => data.low),
          backgroundColor: ["orange"],
          borderColor: ["black"],
          borderWidth: 1,
        },
      ],
    });
  }, [userData]);

  return (
    <div className="ag-theme-balham">
      <Line data={chartData} />
    </div>
  );
}
