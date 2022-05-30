import React from "react";

const AssignItems = ({ assignItem }) => {
  console.log("assignItem", assignItem);
  return (
    <div className="flex items-center">
      <img
        src={
          assignItem.attachment_Path ||
          "https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
        }
        alt=""
      />
    </div>
  );
};

export default AssignItems;
