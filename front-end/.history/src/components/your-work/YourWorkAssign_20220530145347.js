import React from "react";
import { v4 } from "uuid";

const YourWorkAssign = ({ dataAssign }) => {
  console.log("dataAssign", dataAssign);
  return (
    <div>
      <div className="flex flex-col">
        <h2>{dataAssign.title}</h2>
        {dataAssign.items.map((item) => (
            <div v4()></div>
        ))}
      </div>
    </div>
  );
};

export default YourWorkAssign;
