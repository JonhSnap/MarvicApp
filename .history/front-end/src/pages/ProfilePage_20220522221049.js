import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
const ProfilePage = () => {
  const user = useSelector((state) => state.auth.login.currentUser);
  console.log(user);
  return (
    <div className="w-[1320px] mx-auto">
      <div>
        <h2>Hồ sơ và chế độ hiển thị</h2>
      </div>
    </div>
  );
};

export default ProfilePage;
