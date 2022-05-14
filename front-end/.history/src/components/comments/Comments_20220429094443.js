import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React, { useState, useEffect } from "react";
import Comment from "./Comment";
import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import { useSelector } from "react-redux";

const Comments = ({ commentURL }) => {
  const [comments, setComments] = useState([]);
  const [activeComment, setActiveComment] = useState(null);
  const user = useSelector((state) => state.auth.login.currentUser);
  const id_User = user?.id;
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
  const addComment = async (content, id_ParentComment) => {
    await axios
      .post(`${BASE_URL}/api/Comments`, {
        content,
        id_User,
        id_Issue,
        id_ParentComment,
      })
      .then((cmt) => {
        setComments([cmt, ...comments]);
        setActiveComment(null);
      });
  };
  // https://localhost:5001/api/Comments/90c871a8-4f30-4a0a-6276-08da28bd73fd
  const deleteComment = async (commentId) => {
    if (window.confirm("Are you sure that you want to remove comment")) {
      await axios
        .delete(`https://localhost:5001/api/Comments/${commentId}`, {
          "id_User": "e341a8f6-dc1b-4829-94fb-316b6bac99b6"
        })
        .then(() => {
          console.log("delete comment success");
        });
    }
  };

  const updateComment = async (text, commentId) => {
    await axios.put(`${BASE_URL}/api/Comments/${commentId}`, text).then(() => {
      const updateComment = comments.map((comment) => {
        if (comment.id === commentId) {
          return { ...comment, content: text };
        }
        return comment;
      });
      setComments(updateComment);
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
            <Comment
              key={item.id}
              comment={item}
              addComment={addComment}
              currentUserId={id_User}
              deleteComment={deleteComment}
              activeComment={activeComment}
              setActiveComment={setActiveComment}
              updateComment={updateComment}
            />
          ))}
      </div>
    </div>
  );
};

export default Comments;
