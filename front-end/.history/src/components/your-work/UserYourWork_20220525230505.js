import React from "react";
import useHover from "../../hooks/useHover";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  console.log("user", user);
  const [ref, value] = useHover();
  return (
    <div className="w-[30px] [h-30px]">
      <img src={avtUser} alt="" />
    </div>
  );
};

export default UserYourWork;
