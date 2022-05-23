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
        <div className="w-[1320px] mx-auto">
          <div className="flex justify-center w-10">
            <img
              src="https://trello-members.s3.amazonaws.com/624e70dfe1032520d20044f1/8685ee9f75d8ac6ea68287652c33041f/170.png"
              alt="avt-user"
              className="w"
            />
            <h3>{user.userName}</h3>
            <h3>{user.email}</h3>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;
