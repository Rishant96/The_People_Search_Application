import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/person";
import { Container, Row, Col } from "shards-react";
import Person from "./Person";
import PersonDetailed from "./PersonDetailed";
import SearchBar from "./SearchBar";

const People = (props) => {
    const [currIndex, setIndex] = useState(0);

    const handleMoreClick = id => {
        setIndex(id);
    };

    const handleLessClick = id => {
        setIndex(0);
    };

    useEffect(() => {
        props.fetchAllPeople()
    }, []);


    const peopleCards = [];

    const peopleList = props.peopleList.sort((a, b) => {
        if (a.isFavorite || b.isFavorite) {
            if (a.isFavorite && b.isFavorite) {
                return a.firstName - b.firstName;
            }
            else if (a.isFavorite) {
                return -1;
            }
            else {
                return 1;
            }
        }
        else {
            return a.firstName - b.firstName;
        }
    });

    peopleList.forEach((person) => {
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
                <PersonDetailed {...person} handleLessClick={handleLessClick} />
              </Col>
            );
        }
    });

    return (
      <Container>
        <SearchBar />
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