import React, { memo, useEffect, useRef, useState } from "react";
import "../../../src/index.scss";
import { NIL } from "uuid";
import { useListIssueContext } from "../../contexts/listIssueContext";
import { fetchIssue, updateIssues } from "../../reducers/listIssueReducer";
import createToast from "../../util/createToast";
import useModal from "../../hooks/useModal";
import AssineeSelectBox from "../selectbox/AssineeSelectBox";
import { documentHeight } from "../../util/constants";
import Avatar from '@mui/material/Avatar';
import PersonIcon from '@mui/icons-material/Person';
import Tippy from '@tippyjs/react'

function stringToColor(string) {
  let hash = 0;
  let i;

  /* eslint-disable no-bitwise */
  for (i = 0; i < string.length; i += 1) {
    hash = string.charCodeAt(i) + ((hash << 5) - hash);
  }

  let color = '#';

  for (i = 0; i < 3; i += 1) {
    const value = (hash >> (i * 8)) & 0xff;
    color += `00${value.toString(16)}`.slice(-2);
  }
  /* eslint-enable no-bitwise */

  return color;
}

function stringAvatar(name) {
  return {
    sx: {
      bgcolor: stringToColor(name),
    },
    children: `${name.split(' ')[0][0]}${name.split(' ')[1][0]}`,
  };
}
const secondThirdScreen = (documentHeight * 2) / 3;

function MemberComponent({ project, members, issue }) {
  const [assignee, setAssignee] = useState();
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
        result ? setAssignee(result) : setAssignee(null);
      }
    }
  }, [members]);

  return (
    <>
      <div
        ref={nodeRef}
        onClick={handleToggleAssignee}
        className="wrap-assignee relative z-10 wrap-member mr-2"
      >
        {assignee ? (
          <>
            {
              assignee.avatar_Path ?
                <Tippy content={assignee.fullName}>
                  <Avatar sx={{ width: 24, height: 24 }} alt={assignee.userName} src={assignee.avatar_Path} />
                </Tippy>
                :
                <Tippy content={assignee.fullName}>
                  <Avatar style={{ width: 24, height: 24, fontSize: 10 }} {...stringAvatar(assignee.fullName)} />
                </Tippy>
            }
          </>
        ) : (
          <Tippy content='No assignee'>
            <Avatar sx={{ width: 24, height: 24 }}><PersonIcon fontSize='small' /></Avatar>
          </Tippy>
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
            handleChooseAssignee={handleChooseAssignee}
            onClose={handleCloseAssignee}
          />
        )}
      </div>
    </>
  );
}
export default memo(MemberComponent);
