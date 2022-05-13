import { HubConnectionBuilder } from "@microsoft/signalr";
import React from "react";

const Comments = ({ commentsUrl }) => {
  const IssueComment = async () => {
    try {
      const connection = new HubConnectionBuilder().withUrl(commentsUrl);
    } catch (error) {}
  };
  return <div>Hello</div>;
};

export default Comments;
