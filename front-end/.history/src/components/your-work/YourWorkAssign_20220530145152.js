import React from "react";

const YourWorkAssign = ({ dataAssign }) => {
  console.log("dataAssign", dataAssign);
  return (
    <div>
      <div className="flex flex-col">
        <h2>{dataAssign.title}</h2>
      </div>
    </div>
  );
};

export default YourWorkAssign;
