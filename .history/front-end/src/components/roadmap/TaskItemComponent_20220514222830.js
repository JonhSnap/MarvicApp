import React, { useRef, useState, memo } from "react";
import { fetchIssue, updateIssues } from "../../reducers/listIssueReducer";
import { issueTypes } from "../../util/constants";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
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
import MemberComponent from "../board/MemberComponent";
import OptionComponent from "../option/OptionComponent";
import OptionItemBacklogComponent from "../option/OptionItemBacklogComponent";
import useModal from "../../hooks/useModal";
import EditIssuePopup from "../popup/EditIssuePopup";
import { useListIssueContext } from "../../contexts/listIssueContext";
import createToast from "../../util/createToast";

function TaskItemComponent({ members, issue, project, issueEpics }) {
  const [showEdit, setShow, handleClose] = useModal();
  const [, dispatch] = useListIssueContext();
  const [showFlag, setShowFlag] = useState(false);
  const [showInputPoint, setShowInputPoint] = useState(false);
  const [valuePointStore, setValuePointStore] = useState("");
  const [showEditEpic, setShowEditEpic, handleCloseEpic] = useModal();
  const [valuePoint, setValuePoint] = useState(
    issue?.story_Point_Estimate || 0
  );

  const ref = useRef(null);
  const timer = useRef();

  // handle click item
  const handleClickItem = (e) => {
    if (e.target.matches(".item")) {
      setShow(true);
    }
  };
  // handle blur input poit
  const handleBlurInputPoint = () => {
    if (valuePointStore === valuePoint) {
      setValuePointStore("");
      setShowInputPoint(false);
      return;
    }
    const issueUpdate = { ...issue };
    issueUpdate.story_Point_Estimate = Number(valuePoint);
    updateIssues(issueUpdate, dispatch);
    setShowInputPoint(false);
    createToast("success", "Update point estimate successfully!");
    setTimeout(() => {
      fetchIssue(project.id, dispatch);
    }, 500);
  };
  // handle click parent
  const currentEpic = issueEpics.find(
    (item) => item.id === issue.id_Parent_Issue
  );
  const handleClickParent = (e) => {
    if (e.target.matches(".parent")) {
      setShowEditEpic(true);
    }
  };
  return (
    <>
      <div
        onClick={handleClickItem}
        ref={ref}
        className={`item hover:bg-[#eee] cursor-pointer w-full h-[50px] p-1
            px-4 mt-[-1px] border-solid border-[1px] border-[#ccc]
            flex justify-between items-center ${
              issue.isFlagged ? "bg-[#ffe8e6] hover:bg-[#ffb9b3]" : "bg-white"
            }`}
      >
        <div className="flex items-center h-full left-item">
          <div className="w-5 h-5">
            <img
              className="object-cover w-full h-full rounded"
              src={
                issueTypes.find((item) => item.value === issue.id_IssueType)
                  ?.thumbnail
              }
              alt=""
            />
          </div>
          <div className="inline-block mx-1 ">
            <span>{issue?.summary}</span>
          </div>
        </div>
        <div className="flex items-center h-full right-item w-fit">
          {showFlag && (
            <FontAwesomeIcon color="#EF0000" className="mx-2" icon={faFlag} />
          )}
          <div className="flex items-center justify-center w-auto px-2 py-3 mx-2 text-xs font-bold text-blue-600 uppercase whitespace-nowrap ">
            INPROGESS
          </div>
          <MemberComponent
            project={project}
            issue={issue}
            members={members}
          ></MemberComponent>
        </div>
      </div>
    </>
  );
}
export default memo(TaskItemComponent);
