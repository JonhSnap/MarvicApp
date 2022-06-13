import React from "react";
import YourWorkIssue from "./YourWorkIssue";
import { v4 } from "uuid";
const YourWorkProject = ({ dataYourWork }) => {
  //   console.log("projects", projects);
  console.log("====================================");
  console.log(dataYourWork);
  console.log("====================================");
  return (
    <div>
      <h2>{dataYourWork.title}</h2>
      <div>
        {dataYourWork.items.map((dataIssue) => (
          <YourWorkIssue key={v4()}></YourWorkIssue>
        ))}
      </div>
    </div>
  );
};

export default YourWorkProject;
