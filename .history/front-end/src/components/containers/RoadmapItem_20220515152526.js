import React, { useMemo, useState } from "react";
import { v4 } from "uuid";
import CreateComponent from "../CreateComponent";
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
import useModal from "../../hooks/useModal";
import EditIssuePopup from "../popup/EditIssuePopup";

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
  console.log(item);
  const [showEditEpic, setShowEditEpic, handleCloseEpic] = useModal();
  const handleClickParent = (e) => {
    console.log(123);
    if (e.target.matches(".parent")) {
      setShowEditEpic(true);
    }
  };

  const currentEpic = issueCollect.find(
    (items) => items.id === item.id_Parent_Issue
  );

  return (
    <>
      {showEditEpic && (
        <EditIssuePopup
          project={project}
          setShow={setShowEditEpic}
          handleClose={handleCloseEpic}
          issue={currentEpic}
        ></EditIssuePopup>
      )}

      <div
        key={v4()}
        className={`parent w-full p-3 relative flex flex-col font-semibold  shadow-md rounded-[5px] mb-2 cursor-pointer `}
        // onClick={handleClickParent}
      >
        <div
          className={`w-full p-3 relative flex flex-col font-semibold  shadow-md rounded-[5px] mb-2 cursor-pointer hover:bg-slate-200`}
        >
          <div className="flex items-center">
            <FontAwesomeIcon
              size="1x"
              className="inline-block px-2"
              icon={faAngleRight}
            />
            <div
              className="h-5 w-5 inline-block bg-[#d0c6ff] rounded-[5px] mx-2"
              onClick={handleClickParent}
            ></div>
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
            <CreateComponent
              project={project}
              createWhat={"issues"}
              idParent={epic.id}
            />
          </div>
        ) : null}
      </div>
    </>
  );
};

export default RoadmapItem;
