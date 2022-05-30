import React from "react";

const AssignItems = ({ assignItem }) => {
  console.log("assignItem", assignItem);
  return (
    <div className="flex items-center w-full px-3 py-2 mb-2 rounded-lg cursor-pointer hover:bg-slate-100">
      <img
        className="w-6 h-6 rounded-lg"
        src={
          assignItem.attachment_Path ||
          "https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
        }
        alt=""
      />
      <div className="flex flex-col items-center ml-3">
        <h3>{assignItem.summary}</h3>
        <span>{assignItem.projectName}</span>
      </div>
    </div>
  );
};

export default AssignItems;
