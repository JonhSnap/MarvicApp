import React, { useMemo, useState } from "react";
import { v4 } from "uuid";
import CreateComponent from "../CreateComponent";
import { faAngleRight, faAngleDown } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import WrapperTask from "../roadmap/WrapperTask";
import {
  ListIssueContext,
  useListIssueContext,
} from "../../contexts/listIssueContext";
import useModal from "../../hooks/useModal";
import EditEpicPopup from "../popup/EditEpicPopup.js";
import Progress from "../progress/Progress";
import { useStageContext } from "../../contexts/stageContext";

const RoadmapItem = ({ item, project, epic }) => {
  const [showIssue, setShowIssue] = useState(false);
  const [showCreateComponent, setShowCreateComponent] = useState(false);
  const [members, setMembers] = useState([]);
  const [{ stages }] = useStageContext();
  const handleshowIssue = () => {
    setShowIssue(!showIssue);
    setShowCreateComponent(false);
  };
  const handleShowCreate = () => {
    setShowCreateComponent(!showCreateComponent);
    setShowIssue(false);
  };
  const [{ issueNormals }] = useListIssueContext();

  const issueCollect = useMemo(() => {
    return issueNormals.filter((item) => item.id_Parent_Issue === epic.id);
  }, [epic, issueNormals]);
  const [showEditEpic, setShowEditEpic, handleCloseEpic] = useModal();

  const stage = useMemo(() => {
    const result = stages.find((item) => item.id === epic.id_Stage);
    if (!result) return null;
    return result;
  }, [stages]);

  const donePercent = useMemo(() => {
    if (issueCollect.length > 0 && stages.length > 0) {
      const doneStage = stages.find((item) => {
        return item?.stage_Name === "Done";
      });

      return (
        (issueCollect.filter((item) => item.id_Stage === doneStage?.id).length /
          issueCollect.length) *
        100
      );
    }
  }, [issueCollect, stages]);
  return (
    <>
      {showEditEpic && (
        <EditEpicPopup
          donePercent={donePercent}
          project={project}
          setShow={setShowEditEpic}
          handleClose={handleCloseEpic}
          issue={epic}
        ></EditEpicPopup>
      )}
      <div
        key={v4()}
        className={`parent w-full px-3 py-1 relative flex flex-col font-semibold   rounded-[5px]  cursor-pointer
        `}
      >
        <div
          className={`w-full px-3 py-1 relative flex flex-col font-semibold  shadow-md rounded-[5px]  cursor-pointer hover:bg-slate-200`}
        >
          <div className="flex items-center">
            <div>
              <FontAwesomeIcon
                size="1x"
                className="inline-block px-2 text-sm transition-all"
                icon={showIssue ? faAngleDown : faAngleRight}
                onClick={handleshowIssue}
              />
            </div>
            <div className="flex items-center justify-between flex-1">
              <div
                className="flex items-center justify-center"
                onClick={() => {
                  setShowEditEpic(true);
                }}
              >
                <div className="inline-block w-5 h-5 mx-2 rounded-md bg-slate-300 "></div>
                <span className="text-base font-semibold text-slate-600 ">
                  {item.summary}
                </span>
              </div>
            </div>
            <div
              className="flex items-center justify-center rounded-lg bg-slate-200 hover:bg-slate-300"
              onClick={handleShowCreate}
            >
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
          <Progress done={Math.floor(donePercent)} />
          {/* <div className="h-2 w-full z-0 bg-[#ddd] rounded-[5px] my-2 relative">
            <div
              className="absolute z-0 top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]"
              style={{ width: "40%" }}
            ></div>
          </div> */}
        </div>
        {showIssue ? (
          <div>
            <WrapperTask
              members={members}
              project={project}
              issueCollect={issueCollect}
            ></WrapperTask>
          </div>
        ) : null}
        {showCreateComponent ? (
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
