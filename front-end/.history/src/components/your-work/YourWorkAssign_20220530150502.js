import React from "react";
import { v4 } from "uuid";
import AssignItems from "./AssignItems";

const YourWorkAssign = ({ dataAssign }) => {
  return (
    <div>
      <div className="flex flex-col">
        <h2>{dataAssign.title}</h2>
        <div className="h-[200px] mt-3 border border-slate-400 rounded-lg">
          {dataAssign.items.map((item) => (
            <AssignItems key={v4()} assignItem={item}></AssignItems>
          ))}
        </div>
      </div>
    </div>
  );
};

export default YourWorkAssign;
