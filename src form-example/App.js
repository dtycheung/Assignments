import logo from './logo.svg';
import './App.css';
import {useState} from "react";


function App() {
  const [name, setName] = useState("");
  const [error, setError] = useState(null);
  return (
    <div className="App">
      {error !== null ? <p>Error: Error</p> : null}
      {name !== "" && error == null ? <h1>Hello, {name}</h1> : <h1>Hello</h1>}
      <form
        onSubmit={(event) => {
          event.preventDefault();
          if (error == null) {
            alert(`you are submitting ${name}`);
          }
        }}
      >
        <input
          type="text"
          value={name}
          onChange={(event) => {
            if (!/[0-9]/.test(event.target.value)) {
              setError(null);
            } else {
              setError("name are not allowed to contain numbers.");
            }
            setName(event.target.value);
          }}
        />
        <input type="submit" />
      </form>
    </div>
  );
}

export default App;
