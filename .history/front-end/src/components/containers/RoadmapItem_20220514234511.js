import React, { useMemo, useState } from "react";
import { v4 } from "uuid";
import {
  faAngleDown,
  faSquareCheck,
  faTimes,
  faAngleRight,
  faFlag,
  faBolt,
  faCheck,
  faLock,
  faEye,
  faThumbsUp,
  faTimeline,
  faPaperclip,
  faLink,
  faPlus,
  faArrowDownShortWide,
  faArrowDownWideShort,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import WrapperTask from "../roadmap/WrapperTask";
import {
  ListIssueContext,
  useListIssueContext,
} from "../../contexts/listIssueContext";

const RoadmapItem = ({ key, item, project, epic }) => {
  const [showIssue, setShowIssue] = useState(false);
  const [members, setMembers] = useState([]);
  const handleshowIssue = () => {
    setShowIssue(!showIssue);
  };
  const [{ issueNormals }] = useListIssueContext();

  const issueCollect = useMemo(() => {
    return issueNormals.filter((item) => item.id_Parent_Issue === epic.id);
  }, [epic, issueNormals]);
  console.log("issuecolect", issueCollect);

  return (
    <div
      key={v4()}
      className={`w-full p-3 relative flex flex-col font-semibold  shadow-md rounded-[5px] mb-2 cursor-pointer `}
    >
      <div
        // key={v4()}
        className={`w-full p-3 relative flex flex-col font-semibold  shadow-md rounded-[5px] mb-2 cursor-pointer hover:bg-slate-200`}
      >
        <div className="flex items-center">
          <FontAwesomeIcon
            size="1x"
            className="inline-block px-2"
            icon={faAngleRight}
            onClick={handleshowIssue}
          />
          <div className="h-5 w-5 inline-block bg-[#d0c6ff] rounded-[5px] mx-2"></div>
          {item.summary}
        </div>
        <div className="h-2 w-full z-0 bg-[#ddd] rounded-[5px] my-2 relative">
          <div
            className="absolute z-0 top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]"
            style={{ width: "40%" }}
          ></div>
        </div>
        <div className="icon-plus absolute w-[25px] h-[25px] top-1/3 right-2 items-center flex justify-center rounded-lg bg-slate-200 hover:bg-slate-300">
          <span className="">
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
                d="M12 4v16m8-8H4"
              />
            </svg>
          </span>
        </div>
      </div>
      {showIssue ? (
        <div>
          <WrapperTask
            members={members}
            project={project}
            issueCollect={issueCollect}
          ></WrapperTask>
          <CreateComponent project={project} createWhat={"issues"} />
        </div>
      ) : null}
    </div>
  );
};

export default RoadmapItem;