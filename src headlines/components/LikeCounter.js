import { useState } from "react";
export function Likecounter() {
  const [count, setCount] = useState(0);
  const mutate = (n) => {
    setCount((oldCount) => oldCount + n);
  };

  return (
    <div>
        <p>{count}</p>
        <button onClick={() => mutate(+1)}>like</button>
        <button onClick={() => mutate(-1)}>dislike</button>
    </div>
  );
}