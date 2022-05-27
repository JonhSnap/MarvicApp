import React from "react";

const YourWorkRecent = ({ project }) => {
  console.log("project", project);
  return (
    <div className="w-[240px] h-[170px] border-l-[20px] rounded-lg border-2  border-blue-400 mt-4 cursor-pointer p-4">
      <div className="flex flex-col">
        <h2 className="text-[#172b4d]">{project.name}</h2>
      </div>
    </div>
  );
};

export default YourWorkRecent;
