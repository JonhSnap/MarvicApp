import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import { useEffect, useState } from "react";
const Comment = ({
  comment,
  currentUserId,
  setActiveComment,
  activeComment,
  updateComment,
  deleteComment,
  addComment,
  id_ParentComment = null,
  loadComment,
}) => {
  const [reply, setReply] = useState([]);
  const [showReply, setShowReply] = useState(false);
  const fiveMinutes = 300000;
  const timePassed =
    new Date().toISOString() - new Date(comment.create_Date) > fiveMinutes;
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
  const replyId = id_ParentComment ? id_ParentComment : comment.id;
  // const create_Date = new Date(comment.create_Date).toLocaleDateString();
  useEffect(() => {
    const replies = async (commentID) => {
      await axios
        .get(`${BASE_URL}/api/Comments/${commentID}`)
        .then((res) => {
          setReply(res.data);
        })
        .catch((err) => console.log(err));
    };
    if (comment.countChild > 0) {
      replies(comment.id);
    }
  }, [comment]);

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
          <div className="comment-author">{comment.userName}</div>
          <div>{comment.create_Date}</div>
        </div>
        {!isEditting && <div className="comment-text">{comment.content}</div>}
        {isEditting && (
          <CommentForm
            submitLabel="Update"
            hasCancelButton
            initialText={comment.content}
            handleSubmit={(text) => updateComment(text, comment.id)}
            handleCancel={() => setActiveComment(null)}
          />
        )}
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
            handleSubmit={(text) => addComment(text, replyId)}
          />
        )}
        {showReply && comment.countChild > 0 && (
          <div className="replies">
            {reply.length > 0 &&
              reply.map((reply) => (
                <Comment
                  comment={reply}
                  key={reply.id}
                  currentUserId={currentUserId}
                  deleteComment={deleteComment}
                  id_ParentComment={comment.id}
                  activeComment={activeComment}
                  setActiveComment={setActiveComment}
                  addComment={addComment}
                  replies={[]}
                  updateComment={updateComment}
                />
              ))}
          </div>
        )}
        {comment.countChild === 0 ? null : (
          <div className="flex items-center">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              stroke-width="2"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M3 10h10a8 8 0 018 8v2M3 10l6 6m-6-6l6-6"
              />
            </svg>

            <span className="text-slate-600 font-bold">{`${comment.countChild} Phản hồi`}</span>
          </div>
        )}
        {/* <span>{if(comment.countChild}</span> */}
      </div>
    </div>
  );
};

export default Comment;
