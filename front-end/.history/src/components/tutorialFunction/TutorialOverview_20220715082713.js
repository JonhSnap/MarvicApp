import React from "react";
import imgyourwork from "../../img/yourwork.png";

const TutorialOverview = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft">
      <h2 className="text-xl font-semibold">1. Your Work</h2>
      <div>
        <img src={imgyourwork} alt="" />
      </div>
    </div>
  );
};

export default TutorialOverview;
