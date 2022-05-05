import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React, { useState, useEffect } from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";
import axios from "axios";

const Comments = ({ commentURL }) => {
  const [comments, setComments] = useState([]);

  useEffect(() => {
    const loadComment = async () => {
      const res = await axios.get("https://localhost:5001/api/Comments/");
      console.log(res);
    };
  }, []);

  const connection = new HubConnectionBuilder()
    .withUrl(commentURL)
    .configureLogging(LogLevel.Information)
    .build();
  console.log(connection);
  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" />
    </div>
  );
};

export default Comments;
