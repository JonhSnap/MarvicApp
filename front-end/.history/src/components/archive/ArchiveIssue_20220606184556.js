import React from "react";

const ArchiveIssue = ({ ArchiveIssue }) => {
  const isType2 = ArchiveIssue.id_IssueType === 2;
  const isType3 = ArchiveIssue.id_IssueType === 3;
  const isType4 = ArchiveIssue.id_IssueType === 4;
  const isType1 = ArchiveIssue.id_IssueType === 1;
  return (
    <div className="flex items-center py-2 cursor-pointer hover:bg-slate-200">
      <div className="">
        {isType2 && (
          <img
            src="http://localhost:3000/static/media/story.29b1ddadbd9c9361c80f.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType3 && (
          <img
            src="http://localhost:3000/static/media/task.b8da2cdd2f57bbd0748a.jpg"
            alt=""
            className="w-6"
          />
        )}
        {isType4 ||
          (isType1 && (
            <img
              src="http://localhost:3000/static/media/bug.28f77bb8e0d6412801e5.jpg"
              alt=""
              className="w-6"
            />
          ))}
      </div>
      <h2 className="ml-3 font-semibold">{ArchiveIssue.summary}</h2>
    </div>
  );
};

export default ArchiveIssue;
