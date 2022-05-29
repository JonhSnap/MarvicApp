import React from "react";

const YourWorkIssue = ({ dataIssue }) => {
  console.log("dataIssue", dataIssue);
  return (
    <div className="flex p-3 items-center">
      <div>
        <img
          src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
          alt=""
          className="w-6"
        />
      </div>
      <div>
        <h4>{dataIssue.summary}</h4>
        <span>{dataIssue.projectName}</span>
      </div>
    </div>
  );
};

export default YourWorkIssue;
