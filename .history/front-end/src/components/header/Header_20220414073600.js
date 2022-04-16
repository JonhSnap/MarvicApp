import React from "react";
import { Link } from "react-router-dom";

function Header() {
  return (
    <div className="p-7 flex items-center ">
      <button className="py-3 px-6 rounded-lg bg-blue-500 text-white text-sm mr-5">
        Login
      </button>
      <button className="py-3 px-6 rounded-lg bg-yellow-500 text-white text-sm mr-5">
        register
      </button>
      <button className="py-3 px-6 rounded-lg bg-red-500 text-white text-sm mr-5">
        logout
      </button>
    </div>
  );
}

export default Header;
