import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
const ProfilePage = () => {
  Document.title = "Lý lịch | Marvic";
  const user = useSelector((state) => state.auth.login.currentUser);
  console.log(user);
  return (
    <div className="w-[1320px] mx-auto mt-5">
      <div className="text-center">
        <h2 className="text-4xl">Hồ sơ và chế độ hiển thị</h2>
      </div>
    </div>
  );
};

export default ProfilePage;
