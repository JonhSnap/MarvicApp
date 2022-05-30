import React from "react";

const YourWorkIssue = ({ dataIssue }) => {
  console.log("dataIssue", dataIssue);
  return (
    <div className="flex p-1 rounded-lg items-center border-2 border-blue-200 w-full cursor-pointer hover:bg-slate-200">
      <div>
        <img
          src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
          alt=""
          className="w-6"
        />
      </div>
      <div className="ml-4 flex justify-between items-center w-full">
        <div className="">
          <h4 className="text-xl font-semibold">{dataIssue.summary}</h4>
          <span className="text-base text-slate-600 font-normal">
            {dataIssue.projectName}
          </span>
        </div>
        <div className="w-[400px] flex justify-between">
          <span className="w-[300px]">{dataIssue.status}</span>
          <div className="">
            <h3>user</h3>
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkIssue;
