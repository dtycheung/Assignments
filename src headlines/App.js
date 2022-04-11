
import React, { useState } from "react";
import { useNewsArticle } from "./api";
import Headline from "./components/Headlines";
import { Searchbar } from "./components/SearchBar";

function App() {
  const [search, setSearch] = useState("");
  const { loading, headlines, error } = useNewsArticle(search);

  if (loading) {
    return <p>Loading...</p>;
  } 

  return (
    <div classname = "App">
      <Searchbar onSubmit={setSearch} />
      {headlines.map((x) => (
        <Headline title={x.title} key={x.url} />
      ))}
    </div>
  );
}

export default App;
