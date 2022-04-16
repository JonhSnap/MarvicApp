import React from "react";

function Header() {
  return (
    <div className="p-7 flex">
      <button className="py-3 px-6 rounded-lg bg-blue-500 text-white text-sm">
        Login
      </button>
      <button className="py-3 px-6 rounded-lg bg-blue-500 text-white text-sm">
        register
      </button>
      <button className="py-3 px-6 rounded-lg bg-blue-500 text-white text-sm">
        logout
      </button>
    </div>
  );
}

export default Header;
