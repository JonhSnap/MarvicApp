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
          <div className="flex justify-between ml-2 hover:bg-slate-200 rounded-lg px-1 items-center">
            <span className="text-xs font-normal">My open issues</span>
            <p className="w-[10px] h-[10px] flex items-center rounded-lg bg-slate-300 text-slate-600">
              {project.access}
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default YourWorkRecent;
