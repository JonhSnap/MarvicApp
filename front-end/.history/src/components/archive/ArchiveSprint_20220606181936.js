import React from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint }) => {
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <div className="flex flex-col">
      <h2>{ArchiveSprint.sprintName}</h2>
      <div>
        {ArchiveSprint.issues.map((item) => (
          <ArchiveIssue key={v4()}></ArchiveIssue>
        ))}
      </div>
    </div>
  );
};

export default ArchiveSprint;
