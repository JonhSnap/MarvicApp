import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logOut } from "../../redux/apiRequest";
import jwt_decode from "jwt-decode";
import axios from "axios";

function Header() {
  const user = useSelector((state) => state.auth.login.currentUser);
  const id = user?._id;
  let axiosJWT = axios.create();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  // const user = useSelector((state) => state.auth.login.currentUser);
  const handleLogOut = () => {
    logOut(dispatch, navigate, id);
  };

  axiosJWT.interceptors.request.use(async (config) => {
    const decoedToken = jwt_decode(user?.accessToken);
  });
  return <div></div>;
}

export default Header;
