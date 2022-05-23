import React from "react";

const ProfileDetails = ({ value, label }) => {
  return (
    <div className="flex justify-around">
      <div className="flex flex-col ">
        <label
          htmlFor=""
          className="text-base font-semibold ml-[10px] text-slate-500"
        >
          {label}
        </label>
        <input
          type="text"
          className="px-2 py-3 rounded-lg outline-blue-500"
          value={value}
        />
      </div>
      <div className="flex flex-col">
        <span>Ai có thể nhìn thấy nội dung này</span>
        <span className="flex items-center">
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
