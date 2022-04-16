import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logOut } from "../../redux/apiRequest";

function Header() {
  const user = useSelector((state) => state.auth.login.currentUser);
  const accessToken = user?.accessToken;
  const id = user?._id;

  const dispatch = useDispatch();
  const navigate = useNavigate();
  // const user = useSelector((state) => state.auth.login.currentUser);
  const handleLogOut = () => {
    logOut(dispatch, navigate);
  };
  return (
    <div className="p-7 flex items-center ">
      {user ? (
        <>
          <span className="mr-5">
            Hi, <strong>{user.userName}</strong>
          </span>
          <Link to="/logout">
            <button
              className="py-3 px-6 rounded-lg bg-red-500 text-white text-sm mr-5"
              onClick={handleLogOut}
            >
              Logout
            </button>
          </Link>
        </>
      ) : (
        <>
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
        </>
      )}
    </div>
  );
}

export default Header;
