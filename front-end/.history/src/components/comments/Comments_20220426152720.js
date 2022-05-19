import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React from "react";
import CommentForm from "./CommentForm";

const Comments = ({ commentURL }) => {
  console.log(commentURL);
  const issueComment = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl(commentURL)
        .configureLogging(LogLevel.Information)
        .build();
      connection.on("");
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <div className="comments">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" handleSubmit={addComment} />
      <div className="comments-container"></div>
    </div>
  );
};

export default Comments;
