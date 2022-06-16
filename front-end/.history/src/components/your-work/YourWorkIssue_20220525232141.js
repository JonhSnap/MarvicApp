import React from "react";
import UserYourWork from "./UserYourWork";

const YourWorkIssue = ({ dataIssue }) => {
  console.log("dataIssue", dataIssue);
  const isType = dataIssue.id_IssueType;
  //   dataIssue.id_IssueType === 3
  //               ? "http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
  return (
    <div className="flex p-1 rounded-lg items-center  w-full cursor-pointer hover:bg-slate-200">
      <div>
        {/* dataIssue.id_IssueType === 3 ? */}
        <img
          src={
            "http://localhost:3000/static/media/story.29b1ddadbd9c9361c80f.jpg"
          }
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
          <span className="text-base font-normal text-slate-500">
            {dataIssue.status}
          </span>
          <div className=" mr-5 flex">
            {dataIssue.users.map((user) => (
              <UserYourWork user={user}></UserYourWork>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkIssue;
