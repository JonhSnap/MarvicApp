import React from "react";
import imgyourwork from "../../img/yourwork.png";
import imgassign from "../../img/assign.png";
import imgstarred from "../../img/starred.png";
import imgproject from "../../img/project.png";
import imgbacklog from "../../img/backlog.png";
import imgsprint from "../../img/sprint.png";
import imgboard from "../../img/board.png";
import imgroadmap from "../../img/roadmap.png";

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
          <p className="mt-2 ml-4">
            <ul>
              <li>
                • Nơi sẽ nhận các công việc từ Backlog, các công việc này sẽ
                được các thành viên chọn lọc và đưa ra quyết định sẽ ưu tiên
                giải quyết trước so với các công việc còn lại. Từ đó sẽ đảm bảo
                các công việc quan trọng luôn được giải quyết đầu tiên. Người
                quản lý có thể bắt đầu và kết thúc Sprint theo khoảng thời gian
                hợp lý (thường thì một Sprint sẽ diễn ra trong 2 tuần).
              </li>
              <li className="mt-1">
                • Chỉ một Sprint được bắt đầu trong 1 thời điểm của Project. Sau
                khi Sprint đang được thực hiện kết thúc thì người dùng có thể
                bắt đầu một Sprint khác.
              </li>
              <li className="mt-1">
                • Nếu Sprint kết thúc mà vẫn còn công việc chưa hoàn thành thì
                công việc này sẽ được hệ thống tạo ra 1 Sprint mới (nếu Sprint
                hiện tại là Sprint duy nhất của dự án) và chuyển những công việc
                này đến Sprint đó, hoặc nếu đã có các Sprint đã được tạo thì
                người dùng có thể chọn nơi chuyến đến một trong các Sprint này
                hay chuyển đến phần mà các công việc chưa thuộc về Sprint nào.
                Các công việc hoàn thành sẽ được chuyển đến nơi Archive của dự
                án.
              </li>
            </ul>
          </p>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">5. Board</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgboard} alt="" />
          </div>
          <p className="mt-2 ml-4">
            Nơi có các Stage của dự án và 3 Stage mặc định của dự án (To do, In
            Progress, Done) và sau khi một Sprint bất kỳ được bắt đầu các công
            việc sẽ được liệt kê ở Stage To do, người quản lý có thể tạo ra thêm
            hay bỏ bớt stage để phù hợp với dự án của mình nhất. Tất cả các
            Developer của dự án có thể thao tác với công việc được giao, và di
            chuyển công việc được giao cho mình đến Stage phù hợp. Ví dụ khi
            công việc đang được thực hiện người Developer sẽ di chuyển đến Stage
            In Progress và khi công việc được hoàn thành thì sẽ được Developer
            di chuyển đến Stage Done
          </p>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">6. Roadmap</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgroadmap} alt="" />
          </div>
          <p className="mt-2 ml-4">
            Là một lộ trình bao gồm danh sách các tính năng, ý tưởng, những công
            việc cần phải làm, từ các dự án nhỏ đến dự án quan trọng và cả những
            nỗ lực cần phải đạt được. Tất nhiên là tất cả đều phải có thời hạn
            hoàn thành. Vì thế, mọi người có thể thực hiện công việc của mình
            theo Lộ trình Sản phẩm và không phải lo lắng điều gì cần làm tiếp
            theo. Roadmap là một công cụ mạnh mẽ để mô tả làm thế nào một sản
            phẩm có thể được phát triển trong bao lâu, và mục tiêu của mỗi giai
            đoạn.
          </p>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-xl font-semibold">7. Archive</h2>
        <div>
          <div className="cursor-pointer hover:scale-150">
            <img src={imgroadmap} alt="" />
          </div>
          <p className="mt-2 ml-4">
            Là một lộ trình bao gồm danh sách các tính năng, ý tưởng, những công
            việc cần phải làm, từ các dự án nhỏ đến dự án quan trọng và cả những
            nỗ lực cần phải đạt được. Tất nhiên là tất cả đều phải có thời hạn
            hoàn thành. Vì thế, mọi người có thể thực hiện công việc của mình
            theo Lộ trình Sản phẩm và không phải lo lắng điều gì cần làm tiếp
            theo. Roadmap là một công cụ mạnh mẽ để mô tả làm thế nào một sản
            phẩm có thể được phát triển trong bao lâu, và mục tiêu của mỗi giai
            đoạn.
          </p>
        </div>
      </div>
    </div>
  );
};

export default TutorialOverview;
