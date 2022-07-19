import React from "react";
import imgyourwork from "../../img/yourwork.png";
import imgassign from "../../img/assign.png";
import imgstarred from "../../img/starred.png";
import imgproject from "../../img/project.png";
import imgbacklog from "../../img/backlog.png";
import imgsprint from "../../img/sprint.png";

const TutorialOverview = () => {
  return (
    <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft pb-3">
      <div>
        <h2 className="text-xl font-semibold">1. Your Work</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgyourwork} alt="" />
          </div>
          <p className="ml-4">
            Là một công cụ để người dùng truy cập nhanh đến các công việc của
            mình ở các dự án khác nhau giúp việc thao tác trở nên đơn giản và
            nhanh chóng. Công cụ này sẽ thể hiện chính sách các thành viên có
            trách nhiệm tham gia, công việc thuộc về dự án nào.{" "}
          </p>
        </div>
        <div className="mt-2 ml-4">
          <h3 className="text-base font-semibold">
            Tại đây người dùng có thể xem 3 yếu tố:
          </h3>
          <div>
            <ul className="ml-2">
              <li>
                <h3>
                  <strong className="text-blue-800">A Worked on:</strong> Những
                  công việc mà người dùng đang tham gia có thể là assignee,
                  reporter.
                </h3>
                <img src={imgyourwork} alt="" />
              </li>
              <li className="mt-2">
                <h3>
                  <strong className="text-blue-800"> B Assignee:</strong>Liệt kê
                  những công việc mà người dùng có trách nhiệm giải quyết.
                </h3>
                <img src={imgassign} alt="" />
              </li>
              <li className="mt-2">
                <h3>
                  <strong className="text-blue-800">C Starred: </strong> Liết kê
                  các dự án quan trọng và được đánh dấu sao.
                </h3>
                <img src={imgstarred} alt="" />
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">2. Project</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgproject} alt="" />
          </div>
          <p className="ml-4">
            Là một công cụ để người dùng truy cập nhanh đến các công việc của
            mình ở các dự án khác nhau giúp việc thao tác trở nên đơn giản và
            nhanh chóng. Công cụ này sẽ thể hiện chính sách các thành viên có
            trách nhiệm tham gia, công việc thuộc về dự án nào.{" "}
          </p>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">3. Backlog</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgbacklog} alt="" />
          </div>
          <p className="ml-4">
            Nơi mà Product Owner sẽ tạo ra các công việc và quản lý các công
            việc theo dạng của công việc. Công việc có thể là Epic, Story hay
            Task, mỗi dạng công việc sẽ có ý nghĩa riêng.
          </p>
        </div>
        <div className="mt-2 ml-4">
          <div>
            <ul className="ml-2">
              <li>
                <h3>
                  <strong className="text-blue-800">A Epic</strong> Là phần công
                  việc có độ phức tạp cao nhất sẽ được thực hiện trong 1 quý hay
                  nhiều tháng.
                </h3>
              </li>
              <li className="mt-2">
                <h3>
                  <strong className="text-blue-800"> B Story:</strong>Là công
                  việc có độ phức tạp xếp sau Epic. Story được tạo ra để chia
                  nhỏ các công việc phải hoàn thành để thỏa mãn yêu cầu đề ra
                  của Epic. Một Epic thì có thể có một hoặc nhiều Story.
                </h3>
              </li>
              <li className="mt-2">
                <h3>
                  <strong className="text-blue-800">C Task: </strong> Là công
                  việc đó độ phức tạp xếp sau Story. Các task khác nhau có thể
                  có độ phức tạp khác nhau tùy theo đánh giá của người quản lý.
                  Task được tạo ra để chia nhỏ các công việc phải hoàn thành để
                  thỏa mãn yêu cầu đề ra của Story. Một Story thì có thể có một
                  hoặc nhiều Task.
                </h3>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">4. Sprint</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgsprint} alt="" />
          </div>
          <p className="ml-4">
            <ul>
              <li>
                • Nơi sẽ nhận các công việc từ Backlog, các công việc này sẽ
                được các thành viên chọn lọc và đưa ra quyết định sẽ ưu tiên
                giải quyết trước so với các công việc còn lại. Từ đó sẽ đảm bảo
                các công việc quan trọng luôn được giải quyết đầu tiên. Người
                quản lý có thể bắt đầu và kết thúc Sprint theo khoảng thời gian
                hợp lý (thường thì một Sprint sẽ diễn ra trong 2 tuần).
              </li>
            </ul>
          </p>
        </div>
      </div>
    </div>
  );
};

export default TutorialOverview;
