import React from "react";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  const [hoverRef, isHovered] = useHover();
  return (
    <>
      <div ref={hoverRef} className="w-[40px] [h-40px] mr-[-10px] relative ">
        <span className="absolute z-10">
          {isHovered ? `${user.userName}` : ""}
        </span>
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
