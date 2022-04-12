import { Likecounter } from "./LikeCounter.js";

export default function Headline(props) {
  return (
    <div>
      <h1>{props.title}</h1>
      <Likecounter />
    </div>
  );
}