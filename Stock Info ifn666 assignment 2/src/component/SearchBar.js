import React, { useState } from "react"
import {Form, Button, FormControl} from 'react-bootstrap' 
export function SearchBar(props){
  const [innerSearch, setInnerSearch] = useState("");
  return(
        <div style={{ height: "auto", width: "100%", maxwidth: "300px" }} >
            <Form className="d-flex">
              <FormControl
                type="search"
                className="me-2"
                aria-label="Search"
                onChange={(e)=>{setInnerSearch(e.target.value)}}
                placeholder="Symbol or Name"
                noOptionsMessage={() => "No result matched."}
              />
              <Button variant="success" onClick={()=> props.onSubmit(innerSearch)}>Search</Button >
            </Form>   
        </div>
    )
}