import React from "react";

const YourWorkProject = ({ dataYourWork }) => {
  //   console.log("projects", projects);
  console.log("====================================");
  console.log(dataYourWork);
  console.log("====================================");
  return (
    <div>
      <h2>{dataYourWork.title}</h2>
    </div>
  );
};

export default YourWorkProject;
