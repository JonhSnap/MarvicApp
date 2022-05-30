import React from "react";
import { v4 } from "uuid";
import AssignItems from "./AssignItems";

const YourWorkAssign = ({ dataAssign }) => {
  console.log("dataAssign", dataAssign);
  return (
    <div>
      <div className="flex flex-col">
        <h2>{dataAssign.title}</h2>
        {dataAssign.items.map((item) => (
          <div key={v4()}>
            <AssignItems assignItem={item}></AssignItems>
          </div>
        ))}
      </div>
    </div>
  );
};

export default YourWorkAssign;
