import React from "react";

const ProfileDetails = ({ value, label }) => {
  return (
    <div className="flex flex-col ">
      <label htmlFor="">{label}</label>
      <input type="text" className="px-4 py-2" value={value} />
    </div>
  );
};

export default ProfileDetails;
