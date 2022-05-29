import React from "react";

const YourWorkRecent = ({ project }) => {
  console.log("project", project);
  return (
    <div className="w-[240px] h-[170px] border-l-[20px] rounded-lg border-2  border-blue-400 mt-4 cursor-pointer p-4">
      <div className="flex flex-col">
        <div className="flex items-center ml-[-22px]">
          <img
            src="https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
            alt=""
            className="w-7 h-7 rounded-md mr-3"
          />
          <div className=" leading-3">
            <h2 className="text-[#172b4d] text-base font-semibold">
              {project.name}
            </h2>
            <span className="text-xs font-light">Team-managed software</span>
          </div>
        </div>
        <div className=" mt-4">
          <span className="ml-[12px] text-[12px] cursor-text  text-slate-500 font-semibold">
            QUICK LINKS
          </span>
          <div className="flex justify-between ml-[9px] hover:bg-slate-100 rounded-lg px-1 py-1 mt-2 items-center">
            <span className="text-xs font-normal">My open issues</span>
            <p className="w-[15px] h-[15px] text-center flex items-center rounded-sm bg-slate-200 text-slate-600">
              <span className="ml-1">{project.access}</span>
            </p>
          </div>
          <span className="ml-[9px] block text-xs font-normal px-1 py-1 mt-2 hover:bg-slate-100">
            Done issue
          </span>
        </div>
      </div>
    </div>
  );
};

export default YourWorkRecent;
