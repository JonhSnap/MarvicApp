import React from "react";

import imgregisterusecase from "../../img/registerusecase.png";
import imgloginusecase from "../../img/loginusecase.png";
import imglogin from "../../img/login.png";
import imgloginlandau from "../../img/loginlandau.png";
import imgforgotpass from "../../img/forgotpass.png";
import imgyourworkflow from "../../img/yourworkflow.png";

const TutorialWorkflow = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <div>
        <h2 className="text-xl font-semibold">1. register</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgregisterusecase} className="img-tutorial" alt="" />
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
              <img src={imgloginusecase} className="img-tutorial" alt="" />
            </li>
            <li className="mt-4">
              <h3>
                <strong className="text-blue-800">
                  B Sau khi người dùng đăng ký tài khoản:
                </strong>
              </h3>
              <img src={imglogin} alt="" className="img-tutorial" />
            </li>
            <li className="mt-4">
              <h3>
                <strong className="text-blue-800">
                  C Đăng nhập lần đầu tiên:{" "}
                </strong>{" "}
              </h3>
              <img src={imgloginlandau} className="img-tutorial" alt="" />
            </li>
            <li className="mt-4">
              <strong> Lưu ý:</strong>
              Nếu đăng nhập lần thứ 2 trở đi, người dùng sẽ được chuyển đến giao
              diện Your Work.
            </li>
            <li className="mt-4">
              <h3>
                <strong className="text-blue-800">D Forgot Password:</strong>{" "}
              </h3>
              <img src={imgforgotpass} className="img-tutorial" alt="" />
            </li>
            <li className="mt-4">
              <h3>
                <strong className="text-blue-800">E Your Work:</strong>{" "}
              </h3>
              <img src={imgyourworkflow} className="img-tutorial" alt="" />
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default TutorialWorkflow;
