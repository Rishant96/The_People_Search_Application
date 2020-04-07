import React from "react";
import {
  CardHeader
} from "shards-react";

const PersonCardHeader = (props) => {
    const starIcon = props.isStar ? "fas fa-star" : "far fa-star";
    return (
        <CardHeader style={{ display: "flex", justifyContent: "space-between" }}>
            <span>
              Person #{props.id}
            </span>
            <i class={ starIcon }></i>
        </CardHeader>
    );
};

export default PersonCardHeader;
