import { useState } from "react";
import { useSelector } from "react-redux";

const CommentForm = ({
  handleSubmit,
  submitLabel,
  hasCancelButton = false,
  handleCancel,
  initialText = "",
}) => {
  const [text, setText] = useState(initialText);
  const user = useSelector((state) => state.auth.login.currentUser);
  const id_user = user?.id;
  const isTextareaDisabled = text.length === 0;
  const issueComment = "7c2cc804-4aae-4af2-9191-4268fc02edc0";
  const onSubmit = (event) => {
    event.preventDefault();
    handleSubmit(text);
    console.log(text);
    setText("");
  };
  return (
    <form onSubmit={onSubmit}>
      <textarea
        className="comment-form-textarea"
        value={text}
        onChange={(e) => setText(e.target.value)}
      />
      <button className="comment-form-button" disabled={isTextareaDisabled}>
        {submitLabel}
      </button>
      {hasCancelButton && (
        <button
          type="button"
          className="comment-form-button comment-form-cancel-button"
          onClick={handleCancel}
        >
          Cancel
        </button>
      )}
    </form>
  );
};

export default CommentForm;
