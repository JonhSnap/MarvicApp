import React from "react";

const AssignItems = ({ assignItem }) => {
  const isType2 = assignItem.id_IssueType === 2;
  const isType3 = assignItem.id_IssueType === 3;
  const isType4 = assignItem.id_IssueType === 4;
  const isType1 = assignItem.id_IssueType === 1;
  console.log("assignItem", assignItem);
  return (
    <div
      className={`flex items-center ${
        assignItem.isFlagged ? "bg-red-100" : ""
      } w-full px-3 py-1 mb-2 rounded-lg cursor-pointer hover:bg-slate-100 justify-between pr-10`}
    >
      <div className="flex items-center">
        <img
          className="w-6 h-6 rounded-lg"
          src={
            assignItem.attachment_Path ||
            "https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
          }
          alt=""
        />
        <div className="flex flex-col ml-3">
          <h3 className="text-base font-semibold">{assignItem.summary}</h3>
          <span className="text-sm">{assignItem.projectName}</span>
        </div>
      </div>
      <div className="flex items-center">
        {assignItem.isFlagged ? (
          <span class="inline-block w-5 h-5 text-[#ff2d1a]">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 20 20"
              fill="currentColor"
            >
              <path
                fill-rule="evenodd"
                d="M3 6a3 3 0 013-3h10a1 1 0 01.8 1.6L14.25 8l2.55 3.4A1 1 0 0116 13H6a1 1 0 00-1 1v3a1 1 0 11-2 0V6z"
                clip-rule="evenodd"
              ></path>
            </svg>
          </span>
        ) : null}
      </div>
    </div>
  );
};

export default AssignItems;
