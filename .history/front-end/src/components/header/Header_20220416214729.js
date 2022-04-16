import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logOut } from "../../redux/apiRequest";
import jwt_decode from "jwt-decode";
import axios from "axios";

function Header() {
  return <div></div>;
}

export default Header;
