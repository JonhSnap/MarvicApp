import React from "react";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  const [hoverRef, isHovered] = useHover();
  return (
    <>
      <div className="w-[40px] [h-40px]  relative ">
        <div className="w-full h-full ">
          {isHovered ? (
            <span className="userhover w-10 h-10  absolute z-10  bg-black text-white text-sm px-2 py-1 t-100 l-0 rounded-lg top-[100%]">
              {user.userName}
            </span>
          ) : (
            ""
          )}

          <img
            ref={hoverRef}
            src={avtUser}
            alt=""
            className="w-full h-full border-2 border-white rounded-full"
          />
        </div>
      </div>
    </>
  );
};

export default UserYourWork;
