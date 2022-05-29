import React from "react";

const YourWorkRecent = ({ project }) => {
  console.log("project", project);
  return (
    <div className="w-[240px] h-[170px] border-l-[20px] rounded-lg border-2  border-blue-400 mt-4 cursor-pointer p-4">
      <div className="flex flex-col">
        <div>
          <img
            src="https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            alt=""
            className="w-5 h-5"
          />
          <div>
            <h2 className="text-[#172b4d] text-base font-semibold">
              {project.name}
            </h2>
            <span>Team-managed software</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkRecent;
