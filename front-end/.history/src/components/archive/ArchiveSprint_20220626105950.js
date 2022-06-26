import React, { useState } from "react";
import ArchiveIssue from "./ArchiveIssue";
import { v4 } from "uuid";

const ArchiveSprint = ({ ArchiveSprint, project }) => {
  const [showIssue, setShowIssue] = useState(true);
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <>
      <div className="flex flex-col mt-4 rounded-lg">
        {showIssue && (
          <div
            id="style-16"
            className="flex animate__animated animate__animated animate__fadeInDown flex-col pt-2 h-auto overflow-y-auto border-2 border-blue-400 rounded-lg p-2    max-h-[280px]"
          >
            {ArchiveSprint.issues.map((item) => (
              <ArchiveIssue
                project={project}
                key={v4()}
                ArchiveIssue={item}
              ></ArchiveIssue>
            ))}
          </div>
        )}
      </div>
    </>
  );
};

export default ArchiveSprint;
