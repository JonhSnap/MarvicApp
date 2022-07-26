import React from "react";
import imgyourwork from "../../img/yourwork.png";

const TutorialOverview = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <h2 className="text-xl font-semibold">1. Your Work</h2>
      <div>
        <img src={imgyourwork} alt="" />
        <p className="ml-4">
          Là một công cụ để người dùng truy cập nhanh đến các công việc của mình
          ở các dự án khác nhau giúp việc thao tác trở nên đơn giản và nhanh
          chóng. Công cụ này sẽ thể hiện chính sách các thành viên có trách
          nhiệm tham gia, công việc thuộc về dự án nào.{" "}
        </p>
      </div>
      <div className="mt-2 ml-4">
        <h3 className="text-base font-semibold">
          Tại đây người dùng có thể xem 3 yếu tố:
        </h3>
        <div>
          <ul>
            <li>
              <h3>
                <strong className="text-blue-800">A Worked on:</strong> Những
                công việc mà người dùng đang tham gia có thể là assignee,
                reporter.
              </h3>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default TutorialOverview;
