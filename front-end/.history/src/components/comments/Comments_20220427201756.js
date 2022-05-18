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
  const id_user = user?.id;

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
        connection.on("AddComment", () => {
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

  const addComment = async ({
    content,
    id_ParentComment,
    userId,
    id_Issue,
  }) => {
    const addCommentApi = {
      content: text,
      id_ParentComment: "00000000-0000-0000-0000-000000000000",
      userId: id_user,
      id_Issue: issueComment,
    };
    try {
      await connection.invoke("AddComment", addCommentApi);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="comments w-full max-w-[1320px] mx-auto">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" handleSubmit={addComment} />
      <div className="comments-container">
        {rootComments.length > 0 &&
          rootComments.map((rootComment) => (
            <Comment key={rootComment.id} comment={rootComment} />
          ))}
      </div>
    </div>
  );
};

export default Comments;
