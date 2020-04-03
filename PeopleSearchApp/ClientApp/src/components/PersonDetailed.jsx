import React, { useState, useEffect } from "react";
import {
  Card,
  CardHeader,
  CardTitle,
  CardImg,
  CardBody,
  CardFooter,
  Button,
  Badge,
  Collapse,
  ListGroup,
  ListGroupItem
} from "shards-react";

const PersonDetailed = (props) => {
    const [toggle, setToggle] = useState(false);

    const FullName = (props.middleName == null) 
        ? props.firstName + " " + props.lastName
        : props.firstName + " " + props.middleName + " " + props.lastName;

    const NumInterests = (props.interests.length > 0)
        ? props.interests.length
        : "No"

    const onLessClick = e => {
        props.handleLessClick(props.id);
    };

    useEffect(() => {
      window.scrollTo(0, 0);
    }, [props.id]);

    const btnToggle = () => {
      setToggle(!toggle);
    }

    const interests = [];
    props.interests.forEach((interest) => {
      interests.push(
        <ListGroupItem>{interest.interest}</ListGroupItem>
      );
    });

    return (
      <Card style={{ maxWidth: "800px", margin: "auto", marginBottom: "30px" }}>
        <CardHeader>Person #{props.id}</CardHeader>
        <div style={{ display: "Flex" }}>
          <div style={{ maxWidth: "300", maxHeight: "200",
                        marginTop: "10px", marginLeft: "10px", marginBottom: "10px" }}>
            <CardImg src="https://place-hold.it/300x200" />
          </div>
          <CardBody>
            <div style={{ display: "flex", justifyContent: "space-between" }}>
              <CardTitle>{ FullName }</CardTitle>
              <span style={{ marginRight: "50px" }}>Age: { props.age }</span>
            </div>
            <p style={{ marginBottom: "0" }}>{ props.address.city }, { props.address.state }</p>
            <p style={{ marginBottom: "0" }}>{ props.address.country } - { props.address.zipCode }</p>
            <br />
            <div>
              <Button size="sm" outline pill theme="light" onClick={btnToggle}
                      style={{ marginBottom: "10px" }}>
                { NumInterests } interests
              </Button>
              <Collapse open={toggle}>
                <ListGroup>
                  {interests}
                </ListGroup>
              </Collapse>
            </div>
          </CardBody>
        </div>
        <CardFooter>
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <div>
            {/*
              <Button theme="danger" style={{ marginLeft: "5px" }}>
                  Delete
              </Button>
              <Button outline theme="success" style={{ marginLeft: "5px" }}>
                  Edit
              </Button>
            */}
            </div>
            <Button pill onClick={onLessClick} style={{ marginRight: "5px" }}>
                &larr; Less
            </Button>
          </div>
        </CardFooter>
      </Card>
    );
};

export default PersonDetailed;
