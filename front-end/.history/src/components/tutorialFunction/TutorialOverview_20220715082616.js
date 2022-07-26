import React from "react";
import imgyourwork from "../../img/yourwork.png";

const TutorialOverview = () => {
  return (
    <div>
      <h2 className="text-xl font-semibold">1. Your Work</h2>
      <div>
        <img src={imgyourwork} alt="" />
      </div>
    </div>
  );
};

export default TutorialOverview;
