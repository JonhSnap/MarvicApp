import React from "react";

const ProfileDetails = ({ value, label }) => {
  return (
    <div className="flex">
      <label htmlFor="">{label}</label>
      <input type="text" value={value} />
    </div>
  );
};

export default ProfileDetails;
