import { HubConnectionBuilder } from "@microsoft/signalr";
import React from "react";

const Comments = ({ commentsUrl }) => {
  const IssueComment = async () => {
    const connection = new HubConnectionBuilder();
  };
  return <div>Hello</div>;
};

export default Comments;
