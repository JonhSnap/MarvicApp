import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
const ProfilePage = () => {
  const user = useSelector((state) => state.auth.login.currentUser);
  console.log("====================================");
  console.log(user);
  console.log("====================================");
  return <div className="w-[1320px] mx-auto"></div>;
};

export default ProfilePage;
