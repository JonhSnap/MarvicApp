import React, { useRef, useState, memo, useMemo } from "react";
import { fetchIssue, updateIssues } from "../../reducers/listIssueReducer";
import { issueTypes } from "../../util/constants";

import MemberComponent from "../board/MemberComponent";
import useModal from "../../hooks/useModal";
import { useListIssueContext } from "../../contexts/listIssueContext";
import createToast from "../../util/createToast";
import EditEpicPopup from "../popup/EditEpicPopup";
import { useMembersContext } from "../../contexts/membersContext";
import Stages from "../backlog/Stages";
import { useStageContext } from "../../contexts/stageContext";
import "./Roadmap.scss";
import OptionComponent from "../option/OptionComponent";

function TaskItemComponent({ issue, project, issueEpics }) {
  const [showEdit, setShow, handleClose] = useModal();
  const [, dispatch] = useListIssueContext();
  const [showFlag, setShowFlag] = useState(false);
  const [{ stages }] = useStageContext();
  const [showInputPoint, setShowInputPoint] = useState(false);
  const [valuePointStore, setValuePointStore] = useState("");
  const [showEditEpic, setShowEditEpic, handleCloseEpic] = useModal();
  const [valuePoint, setValuePoint] = useState(
    issue?.story_Point_Estimate || 0
  );

  const stage = useMemo(() => {
    const result = stages.find((item) => item.id === issue.id_Stage);
    if (!result) return null;
    return result;
  }, [stages]);
  const ref = useRef(null);
  const {
    state: { members },
  } = useMembersContext();

  const handleClickParent = (e) => {
    setShowEditEpic(true);
  };

  return (
    <>
      {showEditEpic && (
        <EditEpicPopup
          project={project}
          setShow={setShowEditEpic}
          handleClose={handleCloseEpic}
          issue={issue}
        ></EditEpicPopup>
      )}
      <div
        ref={ref}
        className={`item hover:bg-[#eee] cursor-pointer w-full h-[40px] p-1
            px-4 mt-[-1px] border-solid 
            flex justify-between items-center ${
              issue.isFlagged ? "bg-[#ffe8e6] hover:bg-[#ffb9b3]" : "bg-white"
            }`}
      >
        <div className="flex items-center w-full h-full left-item">
          <img
            className="object-cover w-5 h-5 rounded"
            src={
              issueTypes.find((item) => item.value === issue.id_IssueType)
                ?.thumbnail
            }
            alt=""
          />
          <div className="inline-block mx-1" onClick={handleClickParent}>
            <span className="text-base font-normal text-slate-600 issue-Title">
              {issue?.summary}
            </span>
          </div>
          <div className="flex items-center h-full right-item w-fit">
            <div className="flex items-center justify-center w-auto text-xs font-bold text-blue-600 uppercase whitespace-nowrap ">
              <Stages project={project} issue={issue} stage={stage} />
            </div>
            <MemberComponent
              project={project}
              issue={issue}
              members={members}
            ></MemberComponent>
            <OptionComponent project={project} issue={issue} />
          </div>
        </div>
      </div>
    </>
  );
}
export default memo(TaskItemComponent);
