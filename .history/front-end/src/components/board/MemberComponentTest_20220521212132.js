import React, { memo, useEffect, useRef, useState } from "react";
import "../../../src/index.scss";
import { NIL } from "uuid";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { fetchIssue, updateIssues } from "../../reducers/listIssueReducer";
import createToast from "../../util/createToast";
import useModal from "../../hooks/useModal";
import AssineeSelectBox from "../selectbox/AssineeSelectBox";
import { documentHeight } from "../../util/constants";

const secondThirdScreen = (documentHeight * 2) / 3;

function MemberComponentTest({ project, members, issue }) {
  const [assignee, setAssignee] = useState();
  // const [showAssignee, setShowAssignee] = useState(false);
  const [showAssignee, setShowAssignee, handleCloseAssignee] = useModal();
  const [, dispatch] = useListIssueContext();
  const nodeRef = useRef();
  const [coord, setCoord] = useState({});

  // handle toggle assignee
  const handleToggleAssignee = () => {
    if (showAssignee) return;
    const bounding = nodeRef.current.getBoundingClientRect();
    if (bounding) {
      setShowAssignee(true);
      setCoord(bounding);
    }
  };
  // handle Unassignee
  const handleChooseAssignee = async (idMember) => {
    const issueUpdate = { ...issue };
    if (idMember) {
      issueUpdate.id_Assignee = idMember;
    } else {
      issueUpdate.id_Assignee = NIL;
    }
    issueUpdate.updateDate = new Date();
    await updateIssues(issueUpdate, dispatch);
    await createToast("success", "Change assignee successfully");
    fetchIssue(project.id, dispatch);
  };

  useEffect(() => {
    if (members?.length > 0) {
      if (
        issue.id_Assignee &&
        issue.id_Assignee !== "00000000-0000-0000-0000-000000000000"
      ) {
        const result = members.find((item) => item.id === issue.id_Assignee);
        result ? setAssignee(result) : setAssignee({});
      }
    }
  }, [members]);

  return (
    <>
      <div
        ref={nodeRef}
        onClick={handleToggleAssignee}
        className="wrap-assignee relative z-10 wrap-member w-[22px] h-[22px] mr-2"
      >
        {assignee ? (
          <span
            title={assignee.userName}
            className="pointer-events-none inline-flex items-center justify-center w-full h-full text-white
                text-[12px] bg-orange-400 rounded-full"
          >
            {assignee?.userName?.slice(0, 1)}
          </span>
        ) : (
          <span className="inline-block w-full h-full pointer-events-none text-[#ccc] hover:text-gray-500">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 20 20"
              fill="currentColor"
            >
              <path
                fillRule="evenodd"
                d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z"
                clipRule="evenodd"
              />
            </svg>
          </span>
        )}
        {showAssignee && (
          <AssineeSelectBox
            bodyStyle={{
              top: coord.bottom <= secondThirdScreen ? coord.bottom : null,
              left: coord.left - 30,
              bottom: !(coord.bottom <= secondThirdScreen)
                ? documentHeight - coord.top
                : null,
            }}
            issue={issue}
            members={members}
            // handleChooseAssignee={handleChooseAssignee}
            onClose={handleCloseAssignee}
          />
        )}
      </div>
    </>
  );
}
export default memo(MemberComponentTest);
