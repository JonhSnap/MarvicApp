import React from "react";

import imgregisterusecase from "../../img/registerusecase.png";
import imgloginusecase from "../../img/loginusecase.png";
import imglogin from "../../img/login.png";
import imgloginlandau from "../../img/loginlandau.png";
import imgforgotpass from "../../img/forgotpass.png";
import imgyourworkflow from "../../img/yourworkflow.png";

import imgyourwork from "../../img/yourwork.png";
import imgassign from "../../img/assign.png";
import imgstarred from "../../img/starred.png";
import imgcreateproject from "../../img/createproject.png";
import imgviducreate from "../../img/viducreate.png";
import imgproject from "../../img/project.png";

const TutorialWorkflow = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <div>
        <h2 className="text-xl font-semibold">1. register</h2>
        <div>
          <div className="">
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
              <span className="mt-4">
                <strong> Lưu ý:</strong>
                Nếu đăng nhập lần thứ 2 trở đi, người dùng sẽ được chuyển đến
                giao diện Your Work.
              </span>
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
              <span className="mt-4">
                Tại đây sẽ có các lựa chọn hiển thị về{" "}
                <strong>Worked on, Assigned to me, Starred.</strong>
              </span>

              <ul className="ml-4">
                <li>
                  <h3>
                    <strong className="text-blue-800"> • Worked on:</strong>{" "}
                    Những công việc mà người dùng đang tham gia có thể là
                    assignee, reporter.
                  </h3>
                  <img src={imgyourwork} alt="" />
                </li>
                <li className="mt-2">
                  <h3>
                    <strong className="text-blue-800"> • Assignee:</strong>Liệt
                    kê những công việc mà người dùng có trách nhiệm giải quyết.
                  </h3>
                  <img src={imgassign} alt="" />
                </li>
                <li className="mt-2">
                  <h3>
                    <strong className="text-blue-800"> • Starred: </strong> Liệt
                    kê các dự án quan trọng và được đánh dấu sao.
                  </h3>
                  <img src={imgstarred} alt="" />
                </li>
              </ul>
              <span className="mt-4">
                <strong> Lưu ý:</strong>
                Nếu người dùng chưa tham gia Project nào thì mặc định 4 màn hình
                này sẽ là trống.
              </span>
            </li>
          </ul>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">3. Tạo project</h2>
        <div>
          <div className="flex justify-around">
            <img src={imgcreateproject} className="img-tutorial-mini" alt="" />
            <div className="mt-8">
              <h2 className="text-base text-blue-800">
                Người dùng thực hiện tạo Project bằng cách
              </h2>
              <ul className="mt-4">
                <li>o Đặt tên</li>
                <li className="mt-3">
                  o Xác định thời gian bắt đầu và kết thúc
                </li>
                <li className="mt-3">
                  o Quyền truy cập của Project (Public, Private, Limited)
                </li>
                <li className="mt-3">o Từ khóa của Project (tên viết tắt).</li>
              </ul>
            </div>
          </div>
          <div className="mt-5">
            <h3>Ví dụ: </h3>
            <img src={imgviducreate} className="img-tutorial-mini" alt="" />
            <ul>
              <li>
                • Sau khi xác định đầy đủ thông tin của Project. Click Create để
                tạo Project hoặc Cancle để hủy.
              </li>
              <li>
                • Sau khi click Create
                <div>
                  <img src={imgproject} className="" alt="" />
                </div>
              </li>
              <li>
                • Tại đây người dùng có thể gắn hoặc gỡ sao cho Project để tiện
                theo dõi.
              </li>
              <li>
                • Hoặc click vào Project để hệ thống dẫn người dùng đến Board
                của Project vừa click.
              </li>
              <li>
                <strong> Lưu ý</strong>
                <ul>
                  <li>
                    • Nếu chưa có Sprint nào của Project được tạo và bắt đầu thì
                    Board sẽ trống.
                  </li>
                  <li>
                    • Mặc định khi Project được tạo ra sẽ có sẵn 3 stage (Todo,
                    Inprogress, Done).
                  </li>
                  <li>
                    • Người tạo ra Project, ban đầu sẽ là người giữ chức vụ
                    Leader và hệ thống sẽ đánh dấu đây là người tạo để giúp
                    tracking lịch sử hoạt động.
                  </li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default TutorialWorkflow;
