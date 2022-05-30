import React from "react";
import UserYourWork from "./UserYourWork";
import { v4 } from "uuid";
import MemberComponent from "../board/MemberComponent";

const YourWorkIssue = ({ dataIssue }) => {
  const isType2 = dataIssue.id_IssueType === 2;
  const isType3 = dataIssue.id_IssueType === 3;
  const isType4 = dataIssue.id_IssueType === 4;

  //   dataIssue.id_IssueType === 3
  //               ? "http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
  return (
    <div className="flex items-center w-full p-1 rounded-lg cursor-pointer hover:bg-slate-200">
      <div>
        {isType2 && (
          <img
            src="http://localhost:3000/static/media/story.29b1ddadbd9c9361c80f.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType3 && (
          <img
            src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType4 && (
          <img
            src="http://localhost:3000/static/media/bug.28f77bb8e0d6412801e5.jpg"
            alt=""
            className="w-6"
          />
        )}
      </div>
      <div className="flex items-center justify-between w-full ml-4">
        <div className="">
          <h4 className="text-xl font-semibold">{dataIssue.summary}</h4>
          <span className="text-base font-normal text-slate-600">
            {dataIssue.projectName}
          </span>
        </div>
        <div className="w-[400px] flex justify-between">
          <span className="text-base font-normal text-slate-500">
            {dataIssue.status}
          </span>
          <div className="flex w-[200px] mr-5 ">
            {dataIssue.users.map((user) => (
              <UserYourWork key={v4()} user={user}></UserYourWork>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkIssue;
