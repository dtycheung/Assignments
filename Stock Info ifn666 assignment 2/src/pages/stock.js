import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-balham.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import { GenTable } from "../component/TableGenerator.js";
import { useAPIData } from "../api/api";


export default function Stocks() {
  const{loading, stocks, error} = useAPIData()

if (loading) {
  return <p>Loading...</p>;
} else if (error != null) {
  return <p>{error}</p>;
}
  return (
    <div className="ag-theme-balham" >

    <GenTable data={stocks}/>
    
    </div>
  );

  
}
