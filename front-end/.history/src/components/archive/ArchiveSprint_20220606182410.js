import React from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint }) => {
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <div className="flex flex-col mt-4 border-2 border-blue-500 rounded-lg p-">
      <div className="flex items-center text-base">
        <span>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="h-5 w-5"
            viewBox="0 0 20 20"
            fill="currentColor"
          >
            <path
              fill-rule="evenodd"
              d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z"
              clip-rule="evenodd"
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
