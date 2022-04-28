import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React, { useState, useEffect } from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import { useSelector } from "react-redux";

const Comments = ({ commentURL }) => {
  const [comments, setComments] = useState([]);
  comments.sort(
    (a, b) => new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime()
  );

  const [activeComment, setActiveComment] = useState(null);
  const user = useSelector((state) => state.auth.login.currentUser);
  const id_User = user?.id;
  // const commentID = "416f9754-e18f-4233-551f-08da2862345c";
  const id_Issue = "7c2cc804-4aae-4af2-9191-4268fc02edc0";
  // const loadComment = async () => {
  //   await axios
  //     .get(`${BASE_URL}/api/Comments/issue/${id_Issue}`)
  //     .then((res) => {
  //       setComments(res.data);
  //     })
  //     .catch((err) => alert(err));
  // };

  const connection = new HubConnectionBuilder()
    .withUrl(commentURL)
    .configureLogging(LogLevel.Information)
    .build();
  useEffect(() => {
    const loadComment = async () => {
      await axios
        .get(`${BASE_URL}/api/Comments/issue/${id_Issue}`)
        .then((res) => {
          setComments(res.data);
        })
        .catch((err) => alert(err));
    };
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
  const addComment = async (content) => {
    await axios
      .post(`${BASE_URL}/api/Comments`, {
        content,
        id_User,
        id_Issue,
      })
      .then((cmt) => {
        setComments([cmt, ...comments]);
        setActiveComment(null);
      });
  };

  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" handleSubmit={addComment} />
      <div className="comments-container">
        {comments.length > 0 &&
          comments.map((item) => (
            <Comment key={item.id} comment={item} addComment={addComment} />
          ))}
      </div>
    </div>
  );
};

export default Comments;
