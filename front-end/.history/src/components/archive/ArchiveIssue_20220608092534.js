import React from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { KEY_CURRENT_PROJECT } from "../../util/constants";

const ArchiveIssue = ({ ArchiveIssue }) => {
  const isType2 = ArchiveIssue.id_IssueType === 2;
  const isType3 = ArchiveIssue.id_IssueType === 3;
  const isType4 = ArchiveIssue.id_IssueType === 4;
  const isType1 = ArchiveIssue.id_IssueType === 1;
  const navigate = useNavigate();

  const projects = useSelector((state) => state.projects.projects);
  const keyProject = projects.find(
    (project) => project.id === ArchiveIssue.id_Project
  );

  const handleClickName = (key) => {
    localStorage.setItem(KEY_CURRENT_PROJECT, key);
    navigate(`/projects/board/${key}`);
  };
  console.log("keyProject", keyProject);
  return (
    <div
      className={`flex ${
        ArchiveIssue.isFlagged
          ? "bg-red-50 hover:bg-red-100"
          : "hover:bg-slate-200"
      } items-center justify-between px-3 py-2 rounded-lg cursor-pointer hover:bg-slate-200`}
    >
      <div
        onClick={() => handleClickName(keyProject.key)}
        className="flex items-center"
      >
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
        <div className="flex flex-col items-center justify-start">
          <h2 className="ml-3 font-semibold">{ArchiveIssue.summary}</h2>
          <div className="flex items-center text-xs font-normal">
            <span>({ArchiveIssue.dateStarted}) - </span>
            <p>({ArchiveIssue.dateEnd})</p>
          </div>
        </div>
      </div>
      <div className="flex items-center w-[300px] justify-around">
        {ArchiveIssue.isFlagged ? (
          <span className="inline-block w-5 h-5 text-[#ff2d1a]">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 20 20"
              fill="currentColor"
            >
              <path
                fillRule="evenodd"
                d="M3 6a3 3 0 013-3h10a1 1 0 01.8 1.6L14.25 8l2.55 3.4A1 1 0 0116 13H6a1 1 0 00-1 1v3a1 1 0 11-2 0V6z"
                clipRule="evenodd"
              ></path>
            </svg>
          </span>
        ) : (
          <div className="w-5 h-5"></div>
        )}
        <div className="flex items-center justify-center w-6 h-6 rounded-full bg-yellow-50">
          {ArchiveIssue.story_Point_Estimate}
        </div>
      </div>
    </div>
  );
};

export default ArchiveIssue;
