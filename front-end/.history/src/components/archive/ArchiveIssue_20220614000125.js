import React from "react";
import { useMembersContext } from "../../contexts/membersContext";
import useModal from "../../hooks/useModal";
import EditIssuePopup from "../popup/EditIssuePopup";

const ArchiveIssue = ({ ArchiveIssue, project }) => {
  const isType2 = ArchiveIssue.id_IssueType === 2;
  const isType3 = ArchiveIssue.id_IssueType === 3;
  const isType4 = ArchiveIssue.id_IssueType === 4;
  const isType1 = ArchiveIssue.id_IssueType === 1;
  const [showEditEpic, setShowEditEpic, handleCloseEpic] = useModal();
  const {
    state: { members },
  } = useMembersContext();
  console.log("ArchiveIssue", ArchiveIssue);
  return (
    <>
      {showEditEpic && (
        <EditIssuePopup
          members={members}
          project={project}
          issue={ArchiveIssue}
          setShow={setShowEditEpic}
        ></EditIssuePopup>
      )}

    <div
      className={`flex ${
        ArchiveIssue.isFlagged
          ? "bg-red-50 hover:bg-red-100"
          : "hover:bg-slate-200"
      } items-center justify-between px-3 py-2 rounded-lg cursor-pointer hover:bg-slate-200`}
    >
      <div
        className="flex items-center"
        onClick={() => {
                    setShowEditEpic(true);
                  }}
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
        <div className="flex flex-col justify-start ml-3">
          <h2 className="font-semibold">{ArchiveIssue.summary}</h2>
          <div className="flex items-center font-normal">
            <span className="text-[10px] mr-1">({ArchiveIssue.dateStarted.slice(0, 10)}) -</span>
            <p className="text-[10px]"> ({ArchiveIssue.dateEnd.slice(0, 10)})</p>
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
    </>
  );
};

export default ArchiveIssue;
