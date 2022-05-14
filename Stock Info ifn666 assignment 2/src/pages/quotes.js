import { urlQuery } from "../component/urlQuery";
import { useAPIHistory2 } from "../api/api";
import { useState } from "react";
import { Container } from "reactstrap";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import "../App.css";
import logo from "../Images//logo.png";
import { Button, Form, FormControl } from "react-bootstrap";
export default function Quotes() {
  const [search, setSearch] = useState(urlQuery());
  const { loading, overview, error } = useAPIHistory2(search);

  if (loading && error===null) {
    return <p>Loading...</p>
} else if (error !== null) {
  setTimeout(function () {
    window.location.href = "/stock";
  }, 5000);
  return <p>{error}, you will be redirected to Stock List in 5 seconds.</p>;
}
try{
  console.log(overview[0].companyName)
}catch(err){
  setTimeout(function () {
    window.location.href = "/stock";
  }, 3000);
  return <p>Incorrect Stock symbol or API failed, you will be redirected.</p> 
}
  let details = [overview[0]];
  function dropOrUp(value) {
    if (value < 0) {
      return <Col style={{ color: "red" }}>{formatter.format(value)}</Col>;
    } else {
      return <Col style={{ color: "green" }}>+{formatter.format(value)}</Col>;
    }
  }

  var formatter = new Intl.NumberFormat("en-US", {
    style: "currency",
    currency: "USD",
  });

  return (
    <div className="quotemainpage">
      <Container className="Container">
        <Row className="contentrow">
          <Col sm={9}>
            <p className="detailOfStock">Details of {details[0].companyName}</p>
          </Col>
          <Col sm={3}>
            <img src={details[0].image} alt={logo} height="75px" />
          </Col>
        </Row>

        <Form action="/history/" method="GET">
          <Row className="pricehistorybutton">
            <FormControl
              type="hidden"
              id="symbol"
              name="symbol"
              defaultValue={search}
            />
            <Button variant="success" type="submit">
              Price History
            </Button>
          </Row>
        </Form>
        <Row className="contentrow">
          <Col className="label" sm={2}>
            Latest :{" "}
          </Col>
          <Col xs={4}>{formatter.format(details[0].price)}</Col>
          <Col className="label" sm={2}>
            Changes:{" "}
          </Col>
          {dropOrUp(details[0].changes)}
        </Row>
        <Row className="contentrow">
          <Col className="label" sm={2}>
            Industry:
          </Col>
          <Col>{details[0].industry}</Col>
          <Col className="label" sm={2}>
            Sector:{" "}
          </Col>
          <Col>{details[0].sector}</Col>
        </Row>
        <Row className="contentrow">
          <Col className="label" sm={2}>
            CEO:{" "}
          </Col>
          <Col>{details[0].ceo}</Col>
          <Col className="label" sm={2}>
            Market Capital:{" "}
          </Col>
          <Col>{formatter.format(details[0].mktCap)}</Col>
        </Row>
        <Row className="contentrow">
          <Col className="label">Company Description:</Col>
        </Row>
        <Row className="contentrow">
          <Col xs={12}>
            <p className="demopara">{details[0].description}</p>
          </Col>
        </Row>
      </Container>
    </div>
  );
}
