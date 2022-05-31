import React from "react";
import YourWorkIssue from "./YourWorkIssue";
import { v4 } from "uuid";
const YourWorkProject = ({ dataYourWork }) => {
  console.log("dataYourWork", dataYourWork);
  return (
    <div className="w-full">
      <h2 className="my-5 text-xl font-semibold text-slate-400">
        IN THE LAST MONTH
      </h2>
      <div id="style-15" className="w-full h-[400px] overflow-y-auto pb-10">
        {dataYourWork.items.map((dataIssue) => (
          <YourWorkIssue dataIssue={dataIssue} key={v4()}></YourWorkIssue>
        ))}
      </div>
    </div>
  );
};

export default YourWorkProject;
