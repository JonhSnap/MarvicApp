import { useState } from "react";
import Picker from "emoji-picker-react";

const CommentForm = ({
  handleSubmit,
  submitLabel,
  hasCancelButton = false,
  handleCancel,
  initialText = "",
}) => {
  const [text, setText] = useState(initialText);
  const [showPicker, setShowPicker] = useState(false);
  const onEmojiClick = (event, emojiObject) => {
    setText((prevInput) => prevInput + emojiObject.emoji);
    setShowPicker(false);
  };
  const isTextareaDisabled = text.length === 0;
  const onSubmit = (event) => {
    event.preventDefault();
    handleSubmit(text);
    setText("");
  };
  return (
    <form onSubmit={onSubmit}>
      <div className="flex w-[300px]">
        <textarea
          className="comment-form-textarea"
          value={text}
          onChange={(e) => setText(e.target.value)}
        />
        <span onClick={() => setShowPicker(!showPicker)}>
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
              d="M14.828 14.828a4 4 0 01-5.656 0M9 10h.01M15 10h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
            />
          </svg>
        </span>
      </div>
      {showPicker && (
        <Picker
          pickerStyle={{ width: "300px" }}
          onEmojiClick={onEmojiClick}
        ></Picker>
      )}
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
