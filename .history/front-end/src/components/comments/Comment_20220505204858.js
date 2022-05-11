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
          setReply(res.data.reverse());
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
        {!isEditting && (
          <div className="comment-text flex-wrap">{comment.content}</div>
        )}
        {isEditting && (
          <CommentForm
            submitLabel="Update"
            hasCancelButton
            initialText={comment.content}
            handleSubmit={(text) => updateComment(text, comment.id)}
            handleCancel={() => setActiveComment(null)}
          />
        )}
        <div className="comment-actions font-semibold text-[#65676B]">
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
            hasCancelButton
            handleSubmit={(text) => addComment(text, replyId)}
            handleCancel={() => setActiveComment(null)}
          />
        )}
        {showReply && comment.countChild > 0 && (
          <div className="transition-all replies">
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
        {comment.countChild === 0
          ? null
          : !showReply && (
              <div className="flex items-center text-sm transition-all">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  className="w-6 h-6"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                  strokeWidth="2"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    d="M3 10h10a8 8 0 018 8v2M3 10l6 6m-6-6l6-6"
                  />
                </svg>

                <span
                  className="ml-2 font-semibold cursor-pointer text-slate-600 hover:underline"
                  onClick={() => setShowReply(true)}
                >{`${comment.countChild} Phản hồi`}</span>
              </div>
            )}
        {/* <span>{if(comment.countChild}</span> */}
      </div>
    </div>
  );
};

export default Comment;
