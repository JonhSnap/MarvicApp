import React from "react";

const ArchiveSprint = ({ ArchiveSprint }) => {
  console.log("ArchiveSprint", ArchiveSprint);
  return (
    <div className="flex flex-col">
      <h2>{ArchiveSprint.sprintName}</h2>
    </div>
  );
};

export default ArchiveSprint;
