import React from "react";
import avtUser from "../../images/avt-user.png";
import Tooltip from "../tooltip/Tooltip";
import useTooltip from "../../hooks/useTooltip";

const UserYourWork = ({ user }) => {
  return (
    <>
      <div className="w-[40px] [h-40px] mr-[-10px] ">
        <img
          src={avtUser}
          alt=""
          className="border-2 border-white rounded-full w-full h-full"
        />
      </div>
    </>
  );
};

export default UserYourWork;
