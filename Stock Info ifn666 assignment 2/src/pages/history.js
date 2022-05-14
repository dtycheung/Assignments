/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from "react";
import { LineChart } from "../component/LineChart";
import { HistoryTable } from "../component/HistoryTable";
import { useAPIHistory }  from "../api/api";
import { urlQuery } from "../component/urlQuery";
import "bootstrap/dist/css/bootstrap.min.css";
import { DateSelector } from "../component/DateSelector";
import { dataFiltering } from "../component/DateFilter";

export default function History() {
  const { loading, history, error } = useAPIHistory(urlQuery());
  const [search, setSearch] = useState(urlQuery());
  const [histData, setHistData] = useState({});
  const [backupHistData, setBackupHistData] = useState({});
  const [selectedStartDate, setSelectedStartDate] = useState("yyyy-MM-dd");
  const [selectedEndDate, setSelectedEndDate] = useState("yyyy-MM-dd");
  const [dates, setDates] = useState([]);

  useEffect(() => {
    let historyArr = [];
    let forSelectDate = [];
    for (let key in history["Time Series (Daily)"]) {
      historyArr.push({
        date: key,
        open: history["Time Series (Daily)"][key]["1. open"],
        high: history["Time Series (Daily)"][key]["2. high"],
        low: history["Time Series (Daily)"][key]["3. low"],
        close: history["Time Series (Daily)"][key]["4. close"],
        volume: history["Time Series (Daily)"][key]["5. volume"],
      });
      forSelectDate.push(key);
    }
    historyArr = historyArr.reverse();
    setHistData(historyArr);
    setBackupHistData(historyArr);
    setDates(forSelectDate.reverse());
  }, [history]);

  useEffect(() => {
    let newHist = dataFiltering(
      backupHistData,
      selectedStartDate,
      selectedEndDate
    );
    setHistData(newHist);
  }, [selectedStartDate, selectedEndDate]);

  if (loading && error === null) {
    return <p>Loading...</p>;
  } else if (error !== null) {
    setTimeout(function () {
      window.location.href = "/stock";
    }, 5000);
    return <p>{error}, you will be redirected to Stock List in 5 seconds.</p>;
  }
  try {
    console.log(histData[0].date);
  } catch (err) {
    return <p>Incorrect Stock symbol or API failed.</p>;
  }

  return (
    <div className="quotemainpage">
      <h1>Stock History - {search.toUpperCase()}</h1>
      <table className="selectortable" style={{}}>
        <tbody>
          <tr>
            <td>Select a range of date from </td>
            <td>
              <DateSelector
                userData={dates}
                onChange={setSelectedStartDate}
                type="start"
              />
            </td>
            <td>to</td>
            <td>
              {" "}
              <DateSelector
                userData={dates}
                onChange={setSelectedEndDate}
                type="end"
              />
            </td>
          </tr>
        </tbody>
      </table>

      <HistoryTable data={histData} />
      <LineChart userData={histData} />
    </div>
  );
}
