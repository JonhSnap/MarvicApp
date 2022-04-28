import React from "react";
import useClickOutSide from "../../hooks/useClickOutSide";
// import useTooltip from "../../hooks/useTooltip";
// import Tooltip from "../tooltip/Tooltip";

function Profile() {
  // const { isHover, coord, nodeRef } = useTooltip();
  const { show, setShow, nodeRef } = useClickOutSide();

  return (
    <div className="relative">
      {/* {isHover && <Tooltip coord={coord}>Your profile and settings</Tooltip>} */}
      <div
        ref={nodeRef}
        className="user header-right-option"
        onClick={() => setShow(!show)}
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          className="w-6 h-6"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
          strokeWidth={2}
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M5.121 17.804A13.937 13.937 0 0112 16c2.5 0 4.847.655 6.879 1.804M15 10a3 3 0 11-6 0 3 3 0 016 0zm6 2a9 9 0 11-18 0 9 9 0 0118 0z"
          />
        </svg>
      </div>
      {/* {show && ( */}
      <div className="absolute user-profile bg-white shadow-lg  w-[310px] right-0 p-4 rounded-lg flex text-slate-600 border  items-center">
        <div className="flex justify-center w-full border-b-2">
          <h2 className="pb-2 text-[#5e6c84] text-base">Tài Khoản</h2>
          <span className="right-0 block">
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
                d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z"
              />
            </svg>
          </span>
        </div>
      </div>
      {/* )} */}
    </div>
  );
}

export default Profile;
