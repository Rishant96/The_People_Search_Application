import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/person";
import { Container, Row, Col } from "shards-react";
import Person from "./Person";

const People = (props) => {
    const [currIndex, setIndex] = useState(0);

    const handleMoreClick = id => {
        setIndex(id);
    };

    useEffect(() => {
        props.fetchAllPeople()
    }, []);

    const peopleCards = [];

    props.peopleList.forEach((person) => {
        if (currIndex != person.id) {
            peopleCards.push(
              <Col sm="6" key={ person.id }>
                <Person {...person} handleMoreClick={handleMoreClick} />
              </Col>
            );
        }
        else {
            peopleCards.push(
              <Col sm="12" key={ person.id }>
                <Person {...person} handleMoreClick={handleMoreClick} />
              </Col>
            );
        }
    });

    return (
      <Container>
        <Row>
          { peopleCards }
        </Row>
      </Container>
    );
};

const mapStateToProps = state => {
    return {
        peopleList: state.person.list
    };
};

const mapActionsToProps = {
    fetchAllPeople: actions.fetchAll
};

export default connect(mapStateToProps, mapActionsToProps)(People);