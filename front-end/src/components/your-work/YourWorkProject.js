import React from "react";
import YourWorkIssue from "./YourWorkIssue";
import { v4 } from "uuid";
const YourWorkProject = ({ dataYourWork }) => {
  return (
    <div className="w-full">
      <h2 className="my-5 text-xl font-semibold text-slate-400">
        IN THE LAST MONTH
      </h2>
      {dataYourWork.items.map((dataIssue) => (
        <YourWorkIssue dataIssue={dataIssue} key={v4()}></YourWorkIssue>
      ))}
    </div>
  );
};

export default YourWorkProject;
