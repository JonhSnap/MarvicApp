import React from "react";
import avtUser from "../../images/avt-user.png";

const UserYourWork = ({ user }) => {
  console.log("user", user);
  return (
    <div className="w-[20px] [h-20px]">
      <img src={avtUser} alt="" />
    </div>
  );
};

export default UserYourWork;
