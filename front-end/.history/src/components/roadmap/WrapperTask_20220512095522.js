import React, { memo } from "react";
import { v4 } from "uuid";
import { useListIssueContext } from "../../contexts/listIssueContext";
import TaskItemComponent from "./TaskItemComponent";

function WrapperTask({ members, project }) {
  const [{ issueEpics, issueNormals }] = useListIssueContext();
  console.log("wrapper task render");
  return <>{issueNormals.length > 0 && issueNormals.map((item) => 123)}</>;
}

export default memo(WrapperTask);
