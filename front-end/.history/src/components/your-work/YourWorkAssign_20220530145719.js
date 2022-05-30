import React from "react";
import { v4 } from "uuid";
import AssignItems from "./AssignItems";

const YourWorkAssign = ({ dataAssign }) => {
  return (
    <div>
      <div className="flex flex-col">
        <h2>{dataAssign.title}</h2>
        {dataAssign.items.map((item) => (
          <AssignItems key={v4()} assignItem={item}></AssignItems>
        ))}
      </div>
    </div>
  );
};

export default YourWorkAssign;
