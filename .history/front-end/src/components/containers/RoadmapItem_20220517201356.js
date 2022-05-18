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
import EditEpicPopup from "../popup/EditEpicPopup.js";

const RoadmapItem = ({ item, project, epic }) => {
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
  const [showEditEpic, setShowEditEpic, handleCloseEpic] = useModal();

  // handle click parent

  return (
    <>
      {showEditEpic && (
        <EditEpicPopup
          project={project}
          setShow={setShowEditEpic}
          handleClose={handleCloseEpic}
          issue={epic}
        ></EditEpicPopup>
      )}
      <div
        key={v4()}
        className={`parent w-full p-3 relative flex flex-col font-semibold  shadow-md rounded-[5px] mb-2 cursor-pointer
        `}
        // onClick={() => {
        //   setShowEditEpic(true);
        // }}
      >
        <div
          className={`w-full p-3 relative flex flex-col font-semibold  shadow-md rounded-[5px] mb-2 cursor-pointer hover:bg-slate-200`}
        >
          <div className="flex items-center justify-between">
            <div>
              <FontAwesomeIcon
                size="1x"
                className="inline-block px-2"
                icon={faAngleRight}
                onClick={handleshowIssue}
              />
            </div>
            <div className="flex items-center justify-between">
              <div>
                <div className="inline-block w-5 h-5 mx-2 rounded-md bg-slate-300 "></div>
                {item.summary}
              </div>
              <div className="flex items-center justify-center rounded-lg bg-slate-200 hover:bg-slate-300">
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
          </div>
          <div className="h-2 w-full z-0 bg-[#ddd] rounded-[5px] my-2 relative">
            <div
              className="absolute z-0 top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]"
              style={{ width: "40%" }}
            ></div>
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
