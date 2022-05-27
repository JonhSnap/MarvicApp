import React from "react";
import YourWorkIssue from "./YourWorkIssue";

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
            <YourWorkIssue></YourWorkIssue>
          {/* <li>{dataIssue.projectName}</li> */}
        ))}
      </div>
    </div>
  );
};

export default YourWorkProject;
