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
      comment.id_ParentComment === "00000000-0000-0000-0000-000000000000"
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

  const connection = new HubConnectionBuilder()
    .withUrl(commentURL)
    .configureLogging(LogLevel.Information)
    .build();

  useEffect(() => {
    loadComment();
    connection
      .start()
      .then((res) => {
        connection.on("Add_Comment", () => {
          loadComment();
        });
      })
      .catch((e) => console.log("Connecttion faild", e));
  }, []);
  console.log(comments);
  console.log(rootComments);
  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" />
      <div className="comments-container">
        {rootComments.length > 0 &&
          rootComments.map((rootComment) => (
            <Comment key={rootComment.id} comment={rootComment} />
          ))}
        {/* <h3 key={comment.id}>{comment.content}</h3> */}
      </div>
    </div>
  );
};

export default Comments;