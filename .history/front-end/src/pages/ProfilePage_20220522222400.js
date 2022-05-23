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
    <div className="w-full ">
      <div className="text-center w-1320px mx-auto h-[192px] bg-[#a8f1fc]">
        <h2 className="mt-3 text-4xl">Hồ sơ và chế độ hiển thị</h2>
      </div>
    </div>
  );
};

export default ProfilePage;
