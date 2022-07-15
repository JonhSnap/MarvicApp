import React from "react";

import imgyourwork from "../../img/yourwork.png";
import imgassign from "../../img/assign.png";
import imgstarred from "../../img/starred.png";
import imgproject from "../../img/project.png";
import imgbacklog from "../../img/backlog.png";
import imgsprint from "../../img/sprint.png";
import imgboard from "../../img/board.png";
import imgroadmap from "../../img/roadmap.png";
import imgarchive from "../../img/archive.png";
import imgthongke from "../../img/thongke.png";
import imgregisterusecase from "../../img/registerusecase.png";
import imgloginusecase from "../../img/loginusecase.png";
import imglogin from "../../img/login.png";
import imgloginlandau from "../../img/loginlandau.png";

const TutorialWorkflow = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <div>
        <h2 className="text-xl font-semibold">1. register</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgregisterusecase} alt="" />
          </div>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">2. Login</h2>
        <div>
          <ul className="ml-2">
            <li>
              <h3>
                <strong className="text-blue-800">A Use Case diagram: </strong>
              </h3>
              <img src={imgloginusecase} alt="" />
            </li>
            <li className="mt-2">
              <h3>
                <strong className="text-blue-800">
                  B Sau khi người dùng đăng ký tài khoản:
                </strong>
              </h3>
              <img src={imglogin} alt="" />
            </li>
            <li className="mt-2">
              <h3>
                <strong className="text-blue-800">
                  C Đăng nhập lần đầu tiên:{" "}
                </strong>{" "}
              </h3>
              <img src={imgloginlandau} alt="" />
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default TutorialWorkflow;
