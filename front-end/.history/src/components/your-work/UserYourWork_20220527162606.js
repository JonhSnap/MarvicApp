import React from "react";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  const [hoverRef, isHovered] = useHover();
  return (
    <>
      <div className="w-[40px] [h-40px] relative z-0 ">
        {isHovered ? (
          <span className="userhover w-10 h-10  absolute z-10  bg-black text-white text-sm px-2 py-1 t-100 l-0 rounded-lg top-[100%]">
            {user.userName}
          </span>
        ) : (
          ""
        )}
        <div className="absolute top-0 right-0 z-10 w-10 h-10 px-2 py-1 text-sm text-white bg-black rounded-lg userhover t-100 l-0">
          {user.userName}
        </div>
        <img
          ref={hoverRef}
          src={avtUser}
          alt=""
          className="w-full h-full border-2 border-white rounded-full"
        />
      </div>
    </>
  );
};

export default UserYourWork;
