import React, { ref } from "react";
import useModal from "../../hooks/useModal";
import useTooltip from "../../hooks/useTooltip";
import Tooltip from "../tooltip/Tooltip";

function Profile() {
  const { isHover, coord, nodeRef } = useTooltip();
  const { show, setShow, handleClose } = useModal();

  return (
    <>
      {isHover && <Tooltip coord={coord}>Your profile and settings</Tooltip>}
      <div ref={nodeRef} className="user header-right-option">
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
      <div className="user-profile">Xin chao: Tungpro</div>
    </>
  );
}

export default Profile;
