import React from "react";
import {
  Card,
  CardHeader,
  CardTitle,
  CardImg,
  CardBody,
  CardFooter,
  Button,
  Badge
} from "shards-react";
import PersonCardHeader from "./PersonCardHeader";

const Person = (props) => {
    const FullName = (props.middleName == null) 
        ? props.firstName + " " + props.lastName
        : props.firstName + " " + props.middleName + " " + props.lastName;

    const NumInterests = (props.interests.length > 0)
        ? props.interests.length
        : "No"

    const onMoreClick = e => {
        props.handleMoreClick(props.id);
    };

    return (
      <Card style={{ maxWidth: "300px", margin: "auto", marginBottom: "50px" }}>
        <PersonCardHeader id= { props.id } isStar={ props.isFavorite } />
        <CardImg src="https://place-hold.it/300x200" />
        <CardBody>
          <CardTitle>{ FullName }</CardTitle>
          <p>{ props.address.state }, { props.address.country }</p>
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <div style={{ alignSelf: "flex-end" }}>
              <Badge outline theme="light">
                { NumInterests } interests
              </Badge>  
            </div>
            <Button pill onClick={onMoreClick} style={{ marginRight: "5px" }}>
                More &rarr;
            </Button>
          </div>
        </CardBody>
      </Card>
    );
};

export default Person;
