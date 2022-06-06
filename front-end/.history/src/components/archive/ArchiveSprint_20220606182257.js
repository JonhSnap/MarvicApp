import React from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint }) => {
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <div className="flex flex-col mt-4 border-2 border-blue-500 rounded-lg p-">
      <div>
        <span>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            className="w-6 h-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            strokeWidth="2"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              d="M19 9l-7 7-7-7"
            />
          </svg>
        </span>
        <h2>{ArchiveSprint.sprintName}</h2>
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
