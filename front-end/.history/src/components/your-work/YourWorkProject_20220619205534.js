import React from "react";
import YourWorkIssue from "./YourWorkIssue";
import { v4 } from "uuid";
const YourWorkProject = ({ dataYourWork }) => {
  return (
    <div className="w-full">
      <h3 className="text-blue-900 font-bold text-base">
        {dataYourWork.title}
      </h3>
      <div className="w-full">
        {dataYourWork.items.map((dataIssue) => (
          <YourWorkIssue dataIssue={dataIssue} key={v4()}></YourWorkIssue>
        ))}
      </div>
    </div>
  );
};

export default YourWorkProject;
