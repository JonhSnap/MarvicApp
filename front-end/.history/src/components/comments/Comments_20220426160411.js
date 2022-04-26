import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React, { useState } from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";

const Comments = ({ commentURL }) => {
  const [connection, setConnection] = useState();
  const issueComment = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl(commentURL)
        .configureLogging(LogLevel.Information)
        .build();
      await connection.start();
      await connection.invoke("AddComment");
      setConnection(connection);
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
