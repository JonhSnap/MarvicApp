import React from "react";

const YourWorkProject = ({ dataYourWork }) => {
  //   console.log("projects", projects);
  console.log("====================================");
  console.log(dataYourWork);
  console.log("====================================");
  return (
    <div>
      <h2>{dataYourWork.title}</h2>
      <ul>
        {dataYourWork.items.map((dataIssue) => {
          <li>{dataIssue.projectName}</li>;
        })}
      </ul>
    </div>
  );
};

export default YourWorkProject;
