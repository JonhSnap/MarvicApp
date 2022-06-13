import React from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint }) => {
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <div className="flex flex-col mt-4 border-2 border-blue-500 rounded-lg p-">
      <div className="flex items-center justify-center w-full text-2xl cursor-pointer bg-violet-500">
        <h2 className="ml-4 textxl">{ArchiveSprint.sprintName}</h2>
        <span>{ArchiveSprint.issues.length}</span>
      </div>
      <div className="flex flex-col items-center">
        {ArchiveSprint.issues.map((item) => (
          <ArchiveIssue key={v4()}></ArchiveIssue>
        ))}
      </div>
    </div>
  );
};

export default ArchiveSprint;
