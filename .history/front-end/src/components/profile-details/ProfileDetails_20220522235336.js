import React from "react";

const ProfileDetails = ({ value, label }) => {
  return (
    <div className="flex justify-around">
      <div className="flex flex-col ">
        <label htmlFor="">{label}</label>
        <input type="text" className="" value={value} />
      </div>
      <div>
        <span>Ai có thể nhìn thấy nội dung này</span>
      </div>
    </div>
  );
};

export default ProfileDetails;
