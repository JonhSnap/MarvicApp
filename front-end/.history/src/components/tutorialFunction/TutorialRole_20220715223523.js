import React from "react";

import img100 from "../../img/100.png";
import img101 from "../../img/101.png";
import img102 from "../../img/102.png";

const TutorialRole = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <div className="mt-4">
        <h2 className="text-xl font-semibold">1. Overview</h2>
        <div className="mt-4 ml-4">
          <h3 className="text-base text-blue-800">A Use Case</h3>
          <img src={img100} alt="" />
        </div>
        <div className="mt-4 ml-4">
          <h3 className="text-base text-blue-800">B Scope Action</h3>
          <img src={img101} alt="" />
          <img className="ml-[2px]" src={img102} alt="" />
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">2. Project</h2>
        <div className="mt-4 ml-4">
          <h3 className="text-base text-blue-800">A Use Case</h3>
          <img src={img100} alt="" />
        </div>
        <div className="mt-4 ml-4">
          <h3 className="text-base text-blue-800">B Scope Action</h3>
          <img src={img101} alt="" />
          <img className="ml-[2px]" src={img102} alt="" />
        </div>
      </div>
    </div>
  );
};

export default TutorialRole;
