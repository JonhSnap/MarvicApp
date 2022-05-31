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

const RoadmapItem = ({ project, epic, epicSelected, setEpicSelected }) => {
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
        return item?.stage_Name === "DONE";
      });

      return (
        (issueCollect.filter((item) => item.id_Stage === doneStage?.id).length /
          issueCollect.length) *
        100
      );
    }
  }, [issueCollect, stages]);
  // const [{ issueEpics }] = useListIssueContext();
  const handleSelectedEpic = (epicChoose) => {
    setEpicSelected((prev) => {
      if (prev.filter.includes(epicChoose.id)) {
        return {
          ...prev,
          filter: prev.filter.filter((item) => item !== epicChoose.id),
        };
        // return prev.filter.filter((item) => item.id !== epicChoose.id);
      } else {
        return { ...prev, filter: [...prev.filter, epicChoose.id] };
      }
    });
    console.log(epicSelected.filter.includes(epicChoose.id));
  };
  const symbolRoadmap = epicSelected.filter.includes(epic.id);
  console.log(symbolRoadmap);
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
        className={`parent w-full px-3 py-1 relative flex flex-col font-semibold bg shadow-sm  rounded-[5px] mb-1  cursor-pointer
        `}
      >
        <div
          className={`w-full px-3 py-1 relative flex flex-col font-semibold  rounded-[5px]  cursor-pointer hover:bg-slate-200`}
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
              <div className="flex items-center justify-center">
                <div
                  onClick={() => handleSelectedEpic(epic)}
                  className={`inline-block ${
                    epicSelected.filter.includes(epic.id) ? "bg-blue-400" : ""
                  } w-5 h-5 mx-2 rounded-md bg-slate-300 `}
                ></div>
                <span
                  onClick={() => {
                    setShowEditEpic(true);
                  }}
                  className="text-base font-semibold text-slate-600 "
                >
                  {epic.summary}
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
