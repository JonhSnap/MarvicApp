import React from "react";

const YourWorkIssue = ({ dataIssue }) => {
  console.log("dataIssue", dataIssue);
  return (
    <div className="flex">
      <div>
        <img
          src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
          alt=""
          className="w-6"
        />
      </div>
    </div>
  );
};

export default YourWorkIssue;
