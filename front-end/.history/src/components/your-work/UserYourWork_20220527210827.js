import React from "react";
import useHover from "../../hooks/useHover";

const UserYourWork = ({ user }) => {
  return (
    <>
      <h2 className="hover: bg-slate-200">{user.userName}</h2>
    </>
  );
};

export default UserYourWork;
