import React from "react";
import avtUser from "../../images/avt-user.png";
import Tooltip from "../tooltip/Tooltip";
import useTooltip from "../../hooks/useTooltip";

const UserYourWork = ({ user }) => {
  const { isHover, coord, nodeRef } = useTooltip();
  return (
    <>
      {isHover && <Tooltip coord={coord}>{user.userName}</Tooltip>}
      <div ref={nodeRef} className="w-[30px] [h-30px] mr-[-10px]">
        <img src={avtUser} alt="" />
      </div>
    </>
  );
};

export default UserYourWork;
