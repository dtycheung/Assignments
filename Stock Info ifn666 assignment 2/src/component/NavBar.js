import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import { Navbar, Nav, Form, FormControl, Button } from "react-bootstrap";
import Container from "react-bootstrap/Container";
import logo from "../Images/logo.png";
import Stocks from "../pages/stock";
import Home from "../pages/home";
import History from "../pages/history";
import Quotes from "../pages/quotes";

export function NavBar() {
  return (
    <Router>
      <div>
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
          <Container>
            <Navbar.Brand href="/">
              <img
                alt=""
                src={logo}
                width="100"
                height="30"
                className="d-inline-block align-top"
              />{"  "}IFN666
            </Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
              <Nav className="me-auto" navbarScroll>
                <Nav.Link href="/">Home</Nav.Link>
                <Nav.Link href="/stock">Stock</Nav.Link>{" "}


              </Nav>
              <Form className="d-flex " action="/quote/" method="GET">
                <Button
                  variant="success"
                  type="submit"
                  className="me-2"
                >
                  Quote
                </Button>{" "}
                <FormControl
                  type="search"
                  id="symbol"
                  name="symbol"
                  className="me-2"
                  aria-label="Search"
                  placeholder="Search By Symbol"
                />
              </Form>
              </Navbar.Collapse>

             
          </Container>
        </Navbar>
      </div>

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/stock" element={<Stocks></Stocks>} />
        <Route path="/quote" element={<Quotes />} />
        <Route path="/history" element={<History />} />
      </Routes>
    </Router>
  );
}
