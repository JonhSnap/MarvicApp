import React from "react";

const YourWorkStarred = ({ dataStarred }) => {
  console.log("dataStarred", dataStarred);
  return (
    <div className="flex items-center px-3 py-1 rounded-lg hover:bg-slate-200">
      <span className="w-6 mr-4">
        <svg
          width="40"
          height="38"
          viewBox="0 0 40 38"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
          className="w-full"
        >
          <path
            d="M18.0979 1.8541C18.6966 0.011477 21.3034 0.0114808 21.9021 1.8541L25.1638 11.8926C25.4316 12.7167 26.1995 13.2746 27.0659 13.2746H37.621C39.5585 13.2746 40.364 15.7538 38.7966 16.8926L30.2574 23.0967C29.5564 23.606 29.2631 24.5088 29.5308 25.3328L32.7925 35.3713C33.3912 37.2139 31.2823 38.7462 29.7148 37.6074L21.1756 31.4033C20.4746 30.894 19.5254 30.894 18.8244 31.4033L10.2852 37.6074C8.71774 38.7462 6.60878 37.2139 7.20748 35.3713L10.4692 25.3328C10.7369 24.5088 10.4436 23.606 9.74265 23.0967L1.20338 16.8926C-0.364047 15.7538 0.441508 13.2746 2.37895 13.2746H12.9341C13.8005 13.2746 14.5684 12.7167 14.8362 11.8926L18.0979 1.8541Z"
            fill="#FFC400"
          />
        </svg>
      </span>
      <div>
        <img
          src="https://images.unsplash.com/photo-1562577309-4932fdd64cd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8ZGlnaXRhbCUyMG1hcmtldGluZ3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
          alt=""
          className="w-6"
        />
      </div>
    </div>
  );
};

export default YourWorkStarred;