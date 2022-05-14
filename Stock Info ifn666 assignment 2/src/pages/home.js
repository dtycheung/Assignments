import React from "react";
import { Col, Container, Row } from "reactstrap";
import { useNewsArticles } from "../api/api";
import hero from "../Images/hero.jpg";
import logo from "../Images/logo.png";

/**/
export default function Home() {
  const { headlines, loading, error } = useNewsArticles();
  if (loading && error === null) {
    return <p>Loading...</p>;
  } else if (error !== null) {
    return <p>${error}</p>;
  }
  return (
    <div className="quotemainpage">
      <Container className="Container">
        <Row className="Row">
          <h1>Welcome to StockInfo </h1>
        </Row>
        <Row>
          {" "}
          <img
            alt={logo}
            src={hero}
            width="3px"
            height="300px"
          />
        </Row>

        <Row className="Row">
          <h4>
            Welcome to the StockInfo Portal. You may click the Stocks Button to view the
            list of Nasdaq 100 companies or enter a stock symbol on Quote searching bar to
            get detail information of a specific stock. You may check the Price History
            in the Quote page to view the stock price of the most recent one hundred days of
             for a particular stock.{" "}
          </h4>
        </Row>

        <Row className="Row">
          <h2>Quick Stocks News: </h2>

          <Col className="quicknews">
            {headlines.slice(0, 6).map((x) => (
              <Headline
                title={x.title}
                key={x.url}
                description={x.description}
                url={x.url}
              ></Headline>
            ))}
          </Col>
        </Row>
      </Container>
    </div>
  );
}

function Headline(props) {

  return (
    <div>
      <h3><a href={props.url}>{props.title} </a></h3>
      <p>{props.description}</p>
      <hr size="4" width="auto" color="black" />
    </div>
  );
}
