import CommentForm from "./CommentForm";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import { useEffect, useState } from "react";
const Comment = ({
  comment,
  // setActiveComment,
  // activeComment,
  // updateComment,
  // deleteComment,
  // addComment,
  // parentId = null,
  // currentUserId,
}) => {
  const [reply, setReply] = useState([]);
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

  const getReplies = (commentId) => {
    reply
      .filter((rep) => rep.id_ParentComment === commentId)
      .sort(
        (a, b) =>
          new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime()
      );
  };
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
        {comment.countChild > 0 && (
          <div className="replies">
            {reply.length > 0 &&
              reply
                .map((reply) => <Comment comment={reply} key={reply.id} />)
                .sort(
                  (a, b) =>
                    new Date(a.createdAt).getTime() -
                    new Date(b.createdAt).getTime()
                )}
          </div>
        )}
      </div>
    </div>
  );
};

export default Comment;
