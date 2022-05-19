import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import { useEffect, useState } from "react";
const Comment = ({
  comment,
  currentUserId,
  setActiveComment,
  activeComment,
  // updateComment,
  deleteComment,
  // addComment,
  // parentId = null,
}) => {
  const [reply, setReply] = useState([]);
  const fiveMinutes = 300000;
  const timePassed = new Date() - new Date(comment.create_Date) > fiveMinutes;
  const canReply = Boolean(currentUserId);
  const canEdit = currentUserId === comment.id_User && !timePassed;
  const canDelete = currentUserId === comment.id_User && !timePassed;
  const isReplying =
    activeComment &&
    activeComment.type === "replying" &&
    activeComment.id === comment.id;
  const isEditting =
    activeComment &&
    activeComment.type === "editting" &&
    activeComment.id === comment.id;
  // const create_Date = new Date(comment.create_Date).toLocaleDateString();
  useEffect(() => {
    const replies = async (commentID) => {
      await axios
        .get(`${BASE_URL}/api/Comments/${commentID}`)
        .then((res) => {
          setReply(res.data);
        })
        .catch((err) => alert(err));
    };
    if (comment.countChild > 0) {
      replies(comment.id);
    }
  }, []);

  return (
    <div key={comment.id} className="comment">
      <div className="comment-image-container w-[60px]">
        <img
          src="https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png"
          alt=""
        />
      </div>
      <div className="comment-right-part">
        <div className="comment-content">
          <div className="comment-author">{comment.id_User}</div>
          <div>{comment.create_Date}</div>
        </div>
        <div className="comment-text">{comment.content}</div>
        <div className="comment-actions">
          {canReply && (
            <div
              className="comment-action"
              onClick={() =>
                setActiveComment({ id: comment.id, type: "replying" })
              }
            >
              Reply
            </div>
          )}
          {canEdit && (
            <div
              className="comment-action"
              onClick={() =>
                setActiveComment({ id: comment.id, type: "editting" })
              }
            >
              Edit
            </div>
          )}
          {canDelete && (
            <div
              className="comment-action"
              onClick={() => deleteComment(comment.id)}
            >
              Delete
            </div>
          )}
        </div>
        {isReplying && (
          <CommentForm
            submitLabel="Reply"
            handleSubmit={() => addComment(text, replyId)}
          />
        )}
        {comment.countChild > 0 && (
          <div className="replies">
            {reply.length > 0 &&
              reply.map((reply) => (
                <Comment
                  comment={reply}
                  key={reply.id}
                  currentUserId={currentUserId}
                  deleteComment={deleteComment}
                />
              ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default Comment;
