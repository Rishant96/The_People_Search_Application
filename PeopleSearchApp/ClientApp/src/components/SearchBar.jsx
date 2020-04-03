import React from "react";
import {
  Nav,
  Navbar,
  NavbarBrand,
  NavItem,
  NavLink,
  FormInput
} from "shards-react";

const SearchBar = (props) => {
    return (
      <Navbar sticky="top" theme="light"
              style={{ marginBottom: "15px",
                       paddingTop: "5px",
                       paddingBottom: "5px" }}>
        <NavbarBrand>PeopleSearchApp</NavbarBrand>
        <Nav>
          <NavItem style={{ width: "100%" }}>
            <FormInput placeholder="Search Name" />
          </NavItem>
        </Nav>
      </Navbar>
    );
};

export default SearchBar;
