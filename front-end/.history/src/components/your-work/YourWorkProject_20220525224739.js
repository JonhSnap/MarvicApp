import React from "react";
import YourWorkIssue from "./YourWorkIssue";
import { v4 } from "uuid";
const YourWorkProject = ({ dataYourWork }) => {
  return (
    <div className="w-full">
      <h2 className="MY-5">IN THE LAST MONTH</h2>
      {dataYourWork.items.map((dataIssue) => (
        <YourWorkIssue dataIssue={dataIssue} key={v4()}></YourWorkIssue>
      ))}
    </div>
  );
};

export default YourWorkProject;
