import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React from "react";

const Comments = ({ commentURL }) => {
  console.log(commentURL);
  const IssueComment = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl(commentURL)
        .configureLogging(LogLevel.Information)
        .build();
    } catch (error) {
      console.log(error);
    }
  };
  return <div>Hello</div>;
};

export default Comments;
