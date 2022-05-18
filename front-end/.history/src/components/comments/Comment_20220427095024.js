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
      <div className="comment-image-container w-[60px]">
        <img src="https://trello-members.s3.amazonaws.com/624e70dfe1032520d20044f1/6e3ff6da5660a504bf18929868f3e197/170.png" />
      </div>
      <div className="comment-right-part">
        <div className="comment-content">
          <div className="comment-author">{comment.username || "Tung"}</div>
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
