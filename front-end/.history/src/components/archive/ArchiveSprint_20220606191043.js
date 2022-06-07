import React, { useState } from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint }) => {
  const [showIssue, setShowIssue] = useState(false);
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <>
      <div className="flex flex-col mt-4 rounded-lg">
        <div
          onClick={() => setShowIssue(!showIssue)}
          className="flex items-center justify-center w-full py-2 text-2xl text-white rounded-lg cursor-pointer archive-header bg-violet-500 hover:opacity-90"
        >
          <h2 className="ml-4 text-2xl font-semibold">
            {ArchiveSprint.sprintName}
          </h2>
          <span className="ml-3">( {ArchiveSprint.issues.length} Issues)</span>
        </div>
        {showIssue && (
          <div
            id="style-16"
            className="flex animate__animated animate__animated animate__fadeInDown flex-col pt-2 h-auto overflow-y-auto border-l-2 border-slate-300 shadow-lg pl-2 pb-2 max-h-[280px]"
          >
            {ArchiveSprint.issues.map((item) => (
              <ArchiveIssue key={v4()} ArchiveIssue={item}></ArchiveIssue>
            ))}
          </div>
        )}
      </div>
    </>
  );
};

export default ArchiveSprint;
