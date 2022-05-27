import React from "react";
import avtUser from "../../images/avt-user.png";
import Tooltip from "../tooltip/Tooltip";
import useTooltip from "../../hooks/useTooltip";

const UserYourWork = ({ user }) => {
  const { isHover, coord, nodeRef } = useTooltip();
  return (
    <>
      {isHover && <Tooltip coord={coord}>{user.userName}</Tooltip>}
      <div
        ref={nodeRef}
        className="w-[40px] [h-40px] mr-[-10px] border-2 border-white"
      >
        <img src={avtUser} alt="" />
      </div>
    </>
  );
};

export default UserYourWork;
