import React from "react";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  const { isHover, coord, nodeRef } = useTooltip();
  return (
    <div className="w-[30px] [h-30px]">
      <img src={avtUser} alt="" />
    </div>
  );
};

export default UserYourWork;
