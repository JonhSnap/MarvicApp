import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";

const Comments = ({ commentURL }) => {
  const issueComment = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl(commentURL)
        .configureLogging(LogLevel.Information)
        .build();
      console.log("====================================");
      console.log(connection);
      console.log("====================================");
      connection.on("");
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" />
    </div>
  );
};

export default Comments;
