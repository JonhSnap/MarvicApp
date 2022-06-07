import React from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint }) => {
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <div className="flex flex-col mt-4 border-2 rounded-lg">
      <div className="flex items-center justify-center w-full py-2 text-2xl text-white rounded-lg cursor-pointer archive-header bg-violet-500 hover:opacity-90">
        <h2 className="ml-4 text-2xl font-semibold">
          {ArchiveSprint.sprintName}
        </h2>
        <span className="ml-3">( {ArchiveSprint.issues.length} Issues)</span>
      </div>
      <div className="flex flex-col">
        {ArchiveSprint.issues.map((item) => (
          <ArchiveIssue key={v4()} ArchiveIssue={item}></ArchiveIssue>
        ))}
      </div>
    </div>
  );
};

export default ArchiveSprint;
