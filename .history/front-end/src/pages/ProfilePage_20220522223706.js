import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
const ProfilePage = () => {
  useEffect(() => {
    document.title = "Lý lịch | Marvic";
  }, []);
  const user = useSelector((state) => state.auth.login.currentUser);
  console.log(user);
  return (
    <div className="w-full">
      <div className="text-center w-full  h-[192px] bg-[#f4f5f7] ">
        <div className="w-[1320px] mx-auto flex justify-center items-center pt-10">
          <div className="w-20">
            <img
              src="https://trello-members.s3.amazonaws.com/624e70dfe1032520d20044f1/8685ee9f75d8ac6ea68287652c33041f/170.png"
              alt="avt-user"
              className="w"
            />
          </div>
          <h3 className="ml-4 text-2xl text-[#0c3953]">{user.userName}</h3>
          <span>@{user.userName}</span>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;
