import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React, { useState, useEffect } from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";

const Comments = ({ commentURL }) => {
  const [comments, setComments] = useState([]);
  const rootComments = comments.filter(
    (comment) =>
      comment.id_ParentComment ===
      "00000000 - 0000 - 0000 - 0000 - 000000000000"
  );

  const issueComment = "7c2cc804-4aae-4af2-9191-4268fc02edc0";
  const loadComment = async () => {
    await axios
      .get(`${BASE_URL}/api/Comments/issue/${issueComment}`)
      .then((res) => {
        setComments(res.data);
      })
      .catch((err) => alert(err));
  };
  useEffect(() => {
    loadComment();
  }, []);
  console.log(comments);
  console.log(rootComments);

  const connection = new HubConnectionBuilder()
    .withUrl(commentURL)
    .configureLogging(LogLevel.Information)
    .build();
  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" />
      <div className="comments-container">
        {comments.length > 0 &&
          comments.map((comment) => (
            <Comment key={comment.id} comment={comment} />
          ))}
        {/* <h3 key={comment.id}>{comment.content}</h3> */}
      </div>
    </div>
  );
};

export default Comments;
