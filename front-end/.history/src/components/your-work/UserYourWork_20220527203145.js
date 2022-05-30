import React from "react";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  const [hoverRef, isHovered] = useHover();
  return (
    <>
      <div className=" w-[40px] [h-40px] relative ">
        {isHovered ? (
          <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
            {user.userName}
          </span>
        ) : (
          ""
        )}
        <span className="w-auto absolute z-10  bg-black text-white text-sm px-2 py-1  l-0 rounded-lg top-[100%]">
          {user.userName}
        </span>
        <img
          ref={hoverRef}
          src={avtUser}
          alt=""
          className="w-[40px] h-[40px] border-2 border-white rounded-full"
        />
      </div>
    </>
  );
};

export default UserYourWork;
