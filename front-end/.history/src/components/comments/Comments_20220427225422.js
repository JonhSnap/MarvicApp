import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React, { useState, useEffect } from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import { useSelector } from "react-redux";

const Comments = ({ commentURL }) => {
  const [comments, setComments] = useState([]);
  const [text, setText] = useState("");
  const [activeComment, setActiveComment] = useState(null);
  const user = useSelector((state) => state.auth.login.currentUser);
  const id_User = user?.id;

  const rootComments = comments.filter(
    (comment) =>
      comment.id_ParentComment === "00000000-0000-0000-0000-000000000000"
  );

  const id_Issue = "7c2cc804-4aae-4af2-9191-4268fc02edc0";
  const loadComment = async () => {
    await axios
      .get(`${BASE_URL}/api/Comments/issue/${id_Issue}`)
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
        connection.on("Comment", () => {
          loadComment();
        });
      })
      .catch((e) => console.log("Connecttion faild", e));
  }, []);

  // const addComment = (text, parentId) => {
  //   createCommentApi(text, parentId).then((comment) => {
  //     setBackendComments([comment, ...backendComments]);
  //     setActiveComment(null);
  //   });
  // };
  const addComment = async (content) => {
    const res = await axios
      .post(`${BASE_URL}/api/Comments}`, {
        content,
        id_User,
        id_Issue,
      })
      .then((comment) => {
        setComments([comment, ...comment]);
      });
    // setActiveComment(null);
  };

  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" handleSubmit={addComment} />
      <div className="comments-container">
        {rootComments.length > 0 &&
          rootComments.map((rootComment) => (
            <Comment
              key={rootComment.id}
              comment={rootComment}
              addComment={addComment}
            />
          ))}
      </div>
    </div>
  );
};

export default Comments;
