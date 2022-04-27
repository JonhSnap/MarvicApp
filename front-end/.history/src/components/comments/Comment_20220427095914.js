import CommentForm from "./CommentForm";

const Comment = ({
  comment,
  replies,
  setActiveComment,
  activeComment,
  updateComment,
  deleteComment,
  addComment,
  parentId = null,
  currentUserId,
}) => {
  return (
    <div key={comment.id} className="comment">
      <div className="comment-image-container w-[60px]"></div>
      <div className="comment-right-part">
        <div className="comment-content">
          <div className="comment-author">{comment.id || "Tung"}</div>
          <div>{comment.create_Date}</div>
        </div>
        <CommentForm
          submitLabel="Update"
          hasCancelButton
          initialText={comment.content}
        />
      </div>
    </div>
  );
};

export default Comment;
