import React, { useRef, useState } from "react";

const ProfileDetails = ({ value, label }) => {
  const [showEdit, setShowEdit] = useState(false);
  const handleFocusEdit = () => {
    setShowEdit(true);
  };
  const handleEdit = () => {
    console.log(123);
    setShowEdit(false);
  };
  return (
    <div className="flex items-center justify-around">
      <div className="relative flex flex-col">
        <label
          htmlFor=""
          className="text-base font-semibold ml-[14px] text-slate-500"
        >
          {label}
        </label>
        <input
          type="text"
          className="px-4 py-2 rounded-lg outline-blue-500"
          value={value}
          onFocus={handleFocusEdit}
        />
        {showEdit && (
          <div className="cursor-pointer">
            <div
              onClick={handleEdit}
              className="absolute right-[28px] flex items-center justify-center rounded-lg w-7 h-7 bg-slate-200"
            >
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
                  d="M5 13l4 4L19 7"
                />
              </svg>
            </div>
            <div
              onClick={() => setShowEdit(false)}
              className="absolute right-0 flex items-center justify-center rounded-lg w-7 h-7 bg-slate-200"
            >
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
                  d="M6 18L18 6M6 6l12 12"
                />
              </svg>
            </div>
          </div>
        )}
      </div>
      <div className="flex flex-col select-none">
        <span className="text-sm font-normal">
          Ai có thể nhìn thấy nội dung này
        </span>
        <span className="flex items-center text-slate-400">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            class="h-5 w-5"
            viewBox="0 0 20 20"
            fill="currentColor"
          >
            <path
              fill-rule="evenodd"
              d="M10 18a8 8 0 100-16 8 8 0 000 16zM4.332 8.027a6.012 6.012 0 011.912-2.706C6.512 5.73 6.974 6 7.5 6A1.5 1.5 0 019 7.5V8a2 2 0 004 0 2 2 0 011.523-1.943A5.977 5.977 0 0116 10c0 .34-.028.675-.083 1H15a2 2 0 00-2 2v2.197A5.973 5.973 0 0110 16v-2a2 2 0 00-2-2 2 2 0 01-2-2 2 2 0 00-1.668-1.973z"
              clip-rule="evenodd"
            />
          </svg>
          <p>Bất kỳ ai</p>
        </span>
      </div>
    </div>
  );
};

export default ProfileDetails;
