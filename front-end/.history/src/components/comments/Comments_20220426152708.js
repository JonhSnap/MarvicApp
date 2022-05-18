import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import React from "react";

const Comments = ({ commentURL }) => {
  console.log(commentURL);
  const issueComment = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl(commentURL)
        .configureLogging(LogLevel.Information)
        .build();
      connection.on("");
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <div className="comments">
      <h3 className="comments-title">Comments</h3>
      <div className="comment-form-title">Write comment</div>
      <CommentForm submitLabel="Write" handleSubmit={addComment} />
      <div className="comments-container">
        {rootComments.map((rootComment) => (
          <Comment
            key={rootComment.id}
            comment={rootComment}
            replies={getReplies(rootComment.id)}
            activeComment={activeComment}
            setActiveComment={setActiveComment}
            addComment={addComment}
            deleteComment={deleteComment}
            updateComment={updateComment}
            currentUserId={currentUserId}
          />
        ))}
      </div>
    </div>
  );
};

export default Comments;
