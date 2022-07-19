import React from "react";

import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Typography from "@material-ui/core/Typography";
import Box from "@material-ui/core/Box";

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`wrapped-tabpanel-${index}`}
      aria-labelledby={`wrapped-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box p={3}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}
TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.any.isRequired,
  value: PropTypes.any.isRequired,
};

function a11yProps(index) {
  return {
    id: `wrapped-tab-${index}`,
    "aria-controls": `wrapped-tabpanel-${index}`,
  };
}

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.paper,
  },
}));
const TutorialIntroduce = () => {
  const classes = useStyles();
  const [value, setValue] = React.useState("one");

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  return (
    <div className={`${classes.root}  ml-[-20px] mt-[-12px] `}>
      <h2 className="text-2xl font-bold text-blue-800 uppercase heading-test animate__animated animate__rollIn animate__delay-1s">
        Concepts used in the application
      </h2>
      <AppBar position="static">
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="wrapped label tabs example"
        >
          <Tab
            value="one"
            label="Project Management Lifecycle"
            wrapped
            {...a11yProps("one")}
          />
          <Tab value="two" label="Stages in a project" {...a11yProps("two")} />
        </Tabs>
      </AppBar>
      <TabPanel value={value} index="one">
        <span className="ml-5 animate__animated animate__lightSpeedInLeft">
          • Project Management Life Cycle is a series activities that are
          essential to the accomplishment of the objectives or targets of the
          project. It is a pattern consisting of stages for turning an idea
          reality. Projects can vary in scope and difficulty, but they can be
          applied to the Project Management lifecycle structure project,
          regardless of the size of the project.
        </span>
      </TabPanel>
      <TabPanel value={value} index="two">
        <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft">
          <h4 className="ml-5 font-semibold">
            Process of the Project Management life cycle is divided into 5 main
            part:
          </h4>
          <div className="ml-10">
            <p className="text-blue-600">A. The Initiation Phase:</p>
            <ul>
              <li>
                • Xác định những quy trình cần thiết để bắt đầu một dự án mới.
              </li>
              <li>• Identify the processes required to start a new project.</li>
              <li>• Develop Project Charter</li>
              <li>• Identify stakeholders</li>
            </ul>
            <p className="mt-2 ">
              All information related to the project is noted in the Project
              Charter judgments and minutes of related parties. When the project
              charter is approved, the project is officially started by the
              Project Owner.
            </p>
          </div>
          <div className="mt-3 ml-10">
            <p className="text-blue-600">
              B. Project Planning Stage: The Project Planning Stage The project
              plan covers about 50% of the entire process.
            </p>
            <ul>
              <li>• Xác định scope (phạm vi) của dự án</li>
              <li>• Xác định mục tiêu của dự án.</li>
              <li>
                • Tiến hành brainstorm để liệt kê tất cả các task theo từng
                milestone/ sprint.
              </li>
              <li>
                • Thu hút sự tham gia của toàn bộ member ở buổi brainstorm
              </li>
              <li>
                • Viết ra sơ đồ case của các task còn được gọi là WBS (cấu trúc
                phân tích công việc)
              </li>
              <li>• Việc ước tính chi phí và thời gian sao cho phù hợp.</li>
            </ul>
          </div>
          <div className="mt-3 ml-10">
            <p className="text-blue-600">
              C. Giai đoạn thực hiện (Execution phase)
            </p>
            <ul>
              <li>
                • Các trưởng nhóm và quản lý dự án được đưa vào hoạt động để xây
                dựng các sản phẩm, là người hỗ trợ khách hàng, hoàn thành nhiệm
                vụ, thực hiện các quy trình và hơn thế nữa. Việc giao tiếp trên
                tất cả các phần của dự án là cần thiết và quan trọng đối với sự
                thành công của dự án.
              </li>
              <li>
                • Những điều cần thiết cho giai đoạn thực hiện:
                <ul className="ml-5 ">
                  <li>
                    i. Các cuộc họp thường xuyên:
                    <p className="ml-5">
                      Luôn cập nhật đầy đủ thông tin đến các Member thông qua
                      các cuộc họp trực tuyến được quy định thời gian từ trước
                      dựa vào Sprint hiện tại đang được thực hiện. Đảm bảo việc
                      giao tiệp kịp thời và rõ ràng, ít điểm mù hơn, làm việc
                      theo nhóm tốt hơn và có kế hoạch đối ứng tốt nhất.
                    </p>
                  </li>
                  <li className="mt-3">
                    ii. Minh bạch:
                    <p className="ml-5">
                      Tránh tình trạng làm việc khi chưa nắm rõ bối cảnh chung
                      của dự án, để khi gặp các trở ngại có thể dễ dàng giải
                      quyết. Xác định rõ người chịu trách nhiệm cho nhiệm vụ
                      bằng các mô tả chi tiết cho Issue.
                    </p>
                  </li>
                  <li className="mt-3">
                    iii. Quản trị xung đột
                    <p className="ml-5">
                      Các vấn đề chắc chắn sẽ xảy ra. Giảm thiểu sự cố bằng cách
                      mỗi Issue có người Assignee để hoàn thành nhiệm vụ và 1
                      người có trách nhiệm kiểm tra tiến độ và độ hiệu quả của
                      công việc đó để có thể lên tiếng và nêu lên những lo ngại,
                      tắc nghẽn hoặc bất cứ điều gì có thể gây ra điểm yếu trong
                      chuỗi.
                    </p>
                  </li>
                  <li className="mt-3">
                    iv. Báo cáo tiến độ
                    <p className="ml-5">
                      Cập nhật thường xuyên được chia sẻ trong một Stand-up
                      Meeting, với các đồ thị thống kê các Issue đã giải quyết
                      trong 1 khoảng thời gian nhất định (thường là theo tuần
                      hay tháng).
                    </p>
                  </li>
                </ul>
              </li>
            </ul>
          </div>
          <div className="mt-3 ml-10">
            <p className="text-blue-600">D. Giai đoạn kiểm tra</p>
            <ul>
              <li>
                • Nếu không thể đo lường được khối lượng công việc của dự án,
                thì không thể quản lý theo cách tốt nhất. Giai đoạn này yêu cầu
                kiểm tra để đảm bảo mọi thứ đều phù hợp với những gì đã thống
                nhất trước đó. Các chỉ số liên quản chính là gì? Cần thực hiện
                những gì để đáp ứng thời hạn và các thông số liên quản đó?
              </li>
              <li>
                • Tổ chức các cuộc họp trực tuyến với những người có trách nhiệm
                chính để biết các điểm kiểm tra, đánh giá và báo cáo hiệu suất
                thường kỳ.{" "}
              </li>
            </ul>
          </div>
          <div className="mt-3 ml-10">
            <p className="text-blue-600">
              E. Giai đoạn kết thúc (Project Closure)
            </p>
            <ul>
              <li>
                • Kết thúc dự án cũng quan trọng như bắt đầu. Còn được gọi là
                giai đoạn “theo dõi”, đây là khoảng thời gian khi dự án hoàn
                thành đã sẵn sàng để ra mắt công chúng. Trọng tâm chính ở đây là
                phát hành và phân phối sản phẩm.
              </li>
              <li>
                • Điều quan trọng đối với người quản lý dự án là đánh giá vòng
                đời của dự án từ đầu đến cuối bằng cách:
                <ul className="ml-5 ">
                  <li>
                    i. Điều tra hiệu suất dự án
                    <p className="ml-5">
                      Mọi thành viên có đạt được mục tiêu đã đề ra của họ không?
                      Dự án có được hoàn thành trong ngân sách và thời gian
                      không? Dự án có giải quyết được vấn đề gì không? Giải
                      quyết những câu hỏi này sẽ giúp việc đánh giá xem dự án có
                      thành công hay không.
                    </p>
                  </li>
                  <li className="mt-3">
                    ii. Xem xét hiệu suất của nhóm
                    <p className="ml-5">
                      Hiệu suất của các thành viên trong nhóm có thể được đi sâu
                      hơn vào từng cá nhân để đánh giá sự thành công trong nhóm.
                      Kiểm tra chất lượng, KPI và cuộc họp trực tuyến có tác
                      dụng cung cấp thông tin chi tiết rõ ràng hơn về hiệu suất.
                    </p>
                  </li>
                  <li className="mt-3">
                    iii. Đánh giá và lập hồ sơ kết thúc dự án
                    <p className="ml-5">
                      Một bản trình bày kỹ lưỡng bao gồm các tài liệu hỗ trợ thể
                      hiện sự phát triển của dự án từ khi hình thành đến khi
                      giao hàng đảm bảo hoàn thành đúng cách cho khách hàng và
                      các bên liên quan.
                    </p>
                  </li>
                  <li className="mt-3">
                    iv. Yêu cầu đánh giá
                    <p className="ml-5">
                      Đánh giá cuối cùng của dự án cung cấp một cái nhìn sâu hơn
                      về điểm mạnh và điểm yếu, từ đầu đến cuối. Tìm hiểu thông
                      tin chi tiết và rút ra bài học cho lần sau.
                    </p>
                  </li>
                  <li className="mt-3">
                    v. Vượt quá ngân sách
                    <p className="ml-5">
                      Có thể xác định chính xác tình trạng thất thoát ngân sách
                      cũng như các nguồn lực chưa được sử dụng giúp hiểu rõ hơn
                      về thành công (hoặc thất bại) và giúp quản lý lãng phí.
                    </p>
                  </li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </TabPanel>
    </div>
  );
};

export default TutorialIntroduce;
