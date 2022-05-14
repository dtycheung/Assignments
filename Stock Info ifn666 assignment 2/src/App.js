import React from "react";
import { useNewsArticles } from "./api/api";
import { NavBar } from "./component/NavBar";

function App() {
  const { loading, error } = useNewsArticles();
  if (loading) {
    return <p>Loading...</p>;
  } else if (error != null) {
    return <p>{error}</p>;
  }
  return (
    <div className="App">
          <NavBar />
    </div>
  );
}

export default App;
