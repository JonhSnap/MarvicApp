import React, { memo } from "react";
import { v4 } from "uuid";
import { useListIssueContext } from "../../contexts/listIssueContext";
import TaskItemComponent from "./TaskItemComponent";

function WrapperTask({ members, project }) {
  const [{ issueEpics, issueNormals }] = useListIssueContext();
  console.log("wrapper task render");
  return (
    <>
      {issueNormals.length > 0 &&
        issueNormals.map((item) => (
          <TaskItemComponent
            members={members}
            key={v4()}
            project={project}
            issueEpics={issueEpics}
            issue={item}
          />
        ))}
    </>
  );
}

export default memo(WrapperTask);
