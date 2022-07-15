import React from "react";
import imgyourwork from "../../img/yourwork.png";

const TutorialOverview = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <h2 className="text-xl font-semibold">1. Your Work</h2>
      <div>
        <img src={imgyourwork} alt="" />
        <p className="ml-3">
          Là một công cụ để người dùng truy cập nhanh đến các công việc của mình
          ở các dự án khác nhau giúp việc thao tác trở nên đơn giản và nhanh
          chóng. Công cụ này sẽ thể hiện chính sách các thành viên có trách
          nhiệm tham gia, công việc thuộc về dự án nào.{" "}
        </p>
      </div>
    </div>
  );
};

export default TutorialOverview;
