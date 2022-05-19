import { useState } from "react";
import Picker from "emoji-picker-react";

const CommentForm = ({
  handleSubmit,
  submitLabel,
  hasCancelButton = false,
  handleCancel,
  initialText = "",
  textPlaceholder = "Write comment",
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
      <div className="flex items-center mb-3">
        <textarea
          className="comment-form-textarea mr-2 border-none outline-none rounded-md res h-2"
          placeholder={textPlaceholder}
          value={text}
          onChange={(e) => setText(e.target.value)}
        />
        <span
          className="cursor-pointer"
          onClick={() => setShowPicker((hi) => !hi)}
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            className="h-6 w-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            strokeWidth="2"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
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
