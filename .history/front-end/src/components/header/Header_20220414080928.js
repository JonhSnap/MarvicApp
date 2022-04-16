import React from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
function Header() {
  const user = useSelector((state) => state.auth.login.currentUser);
  return (
    <div className="p-7 flex items-center ">
      <Link to="/login">
        <button className="py-3 px-6 rounded-lg bg-blue-500 text-white text-sm mr-5">
          Login
        </button>
      </Link>
      <Link to="/register">
        <button className="py-3 px-6 rounded-lg bg-yellow-500 text-white text-sm mr-5">
          Register
        </button>
      </Link>
      <Link to="/logout">
        <button className="py-3 px-6 rounded-lg bg-red-500 text-white text-sm mr-5">
          Logout
        </button>
      </Link>
    </div>
  );
}

export default Header;
