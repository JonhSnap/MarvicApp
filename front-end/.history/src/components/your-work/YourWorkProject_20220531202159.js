import React from "react";
import YourWorkIssue from "./YourWorkIssue";
import { v4 } from "uuid";
const YourWorkProject = ({ dataYourWork }) => {
  console.log("dataYourWork", dataYourWork);
  return (
    <div className="w-full">
      <h3>{dataYourWork.title}</h3>
      <div className="w-full overflow-y-auto">
        {dataYourWork.items.map((dataIssue) => (
          <YourWorkIssue dataIssue={dataIssue} key={v4()}></YourWorkIssue>
        ))}
      </div>
    </div>
  );
};

export default YourWorkProject;
