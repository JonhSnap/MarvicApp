import CommentForm from "./CommentForm";

const Comment = ({
  comment,
  replies,
  // setActiveComment,
  // activeComment,
  // updateComment,
  // deleteComment,
  // addComment,
  // parentId = null,
  // currentUserId,
}) => {
  // console.log("replies", replies);
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
        {replies.length > 0 && (
          <div className="replies">
            {replies.map((reply) => (
              <Comment comment={reply} key={reply.id} replies={[]} />
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default Comment;
