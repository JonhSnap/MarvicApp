import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React from "react";

const Comments = ({ commentURL }) => {
  console.log(commentsUrl);
  const IssueComment = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl(commentsUrl)
        .configureLogging(LogLevel.Information)
        .build();
    } catch (error) {
      console.log(error);
    }
  };
  return <div>Hello</div>;
};

export default Comments;
