import React from "react";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Typography from "@material-ui/core/Typography";
import Box from "@material-ui/core/Box";
import "../scss/TutorialTestPage.scss";

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`vertical-tabpanel-${index}`}
      aria-labelledby={`vertical-tab-${index}`}
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
    id: `vertical-tab-${index}`,
    "aria-controls": `vertical-tabpanel-${index}`,
  };
}

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.paper,
    display: "flex",
    height: 500,
  },
  tabs: {
    borderRight: `1px solid ${theme.palette.divider}`,
    width: "300px",
  },
}));
const TutorialTest = () => {
  const classes = useStyles();
  const [value, setValue] = React.useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <>
      <div className="w-[1320px] mx-auto">
        <div className="flex justify-center w-full text-4xl h-[60px]">
          <h1 class="jt --debug">
            <span class="jt__row">
              <span class="jt__text">WELCOME MARVIC APP</span>
            </span>
            <span class="jt__row jt__row--sibling" aria-hidden="true">
              <span class="jt__text">WELCOME MARVIC APP</span>
            </span>
            <span class="jt__row jt__row--sibling" aria-hidden="true">
              <span class="jt__text">WELCOME MARVIC APP</span>
            </span>
            <span class="jt__row jt__row--sibling" aria-hidden="true">
              <span class="jt__text">WELCOME MARVIC APP</span>
            </span>
          </h1>
        </div>
        <h2 className="text-2xl text-blue-600 uppercase">Welcome</h2>
        <div className={classes.root}>
          <Tabs
            orientation="vertical"
            variant="scrollable"
            value={value}
            onChange={handleChange}
            aria-label="Vertical tabs example"
            className={classes.tabs}
          >
            <Tab label="I.	Giới thiệu tổng quan" {...a11yProps(0)} />
            <Tab
              label="II.	Study các hiện trạng của các app cùng phân khúc. "
              {...a11yProps(1)}
            />
            <Tab label="Item Three" {...a11yProps(2)} />
            <Tab label="Item Four" {...a11yProps(3)} />
            <Tab label="Item Five" {...a11yProps(4)} />
            <Tab label="Item Six" {...a11yProps(5)} />
            <Tab label="Item Seven" {...a11yProps(6)} />
          </Tabs>
          <TabPanel
            value={value}
            index={0}
            className="w-[900px] h-[500px] overflow-y-auto have-y-scroll"
          >
            <div className="flex flex-col">
              <h2 className="text-2xl font-bold uppercase heading-test">
                1. Các khái niệm được dùng trong ứng dụng
              </h2>
              <div className="ml-5">
                <h3 className="text-base font-semibold ">
                  1.1 Vòng đời Quản lý dự án (Project Management Life Cycle) là
                  gì?
                </h3>
                <span className="ml-5">
                  • Project Management Life Cycle (Vòng đời quản lý dự án) là
                  một chuỗi các hoạt động thiết yếu để hoàn thành các mục tiêu
                  hoặc chỉ tiêu của dự án. Nó là một khuôn mẫu bao gồm các giai
                  đoạn để biến một ý tưởng thành hiện thực. Các dự án có thể có
                  phạm vi và mức độ khó khác nhau, nhưng chúng có thể được áp
                  dụng tới cấu trúc vòng đời của Quản lý dự án, bất kể quy mô
                  của dự án là gì.
                </span>
              </div>
              <div className="mt-5 ml-5">
                <h3 className="text-base font-semibold ">
                  1.2 Các giai đoạn trong 1 dự án (Project Management Life Cycle
                  Phases):
                </h3>
                <h4 className="ml-5 font-semibold">
                  Process (Quy trình) của vòng đời Quản lý Dự án được chia thành
                  5 phần chính:
                </h4>
                <div className="ml-10">
                  <p className="text-blue-600">
                    A. Giai đoạn Khởi tạo (The Initiation Phase):
                  </p>
                  <ul>
                    <li>
                      • Xác định những quy trình cần thiết để bắt đầu một dự án
                      mới.
                    </li>
                    <li>• Xác định những gì dự án sẽ đạt được.</li>
                    <li>• Xây dựng Điều lệ Dự án</li>
                    <li>• Xác định các bên liên quan</li>
                  </ul>
                  <p className="mt-2 ">
                    Tất cả các thông tin liên quan đến dự án được note vào Điều
                    lệ dự án và các biên bản của các bên liên quan. Khi điều lệ
                    dự án được phê duyệt, dự án chính thức được bắt đầu bởi
                    Project Owner.
                  </p>
                </div>
                <div className="mt-3 ml-10">
                  <p className="text-blue-600">
                    B. Giai đoạn lập kế hoạch (Project Planning Stage):Giai đoạn
                    Lập kế hoạch dự án bao gồm khoảng 50% của toàn bộ quá trình.
                  </p>
                  <ul>
                    <li>• Xác định scope (phạm vi) của dự án</li>
                    <li>• Xác định mục tiêu của dự án.</li>
                    <li>
                      • Tiến hành brainstorm để liệt kê tất cả các task theo
                      từng milestone/ sprint.
                    </li>
                    <li>
                      • Thu hút sự tham gia của toàn bộ member ở buổi brainstorm
                    </li>
                    <li>
                      • Viết ra sơ đồ case của các task còn được gọi là WBS (cấu
                      trúc phân tích công việc)
                    </li>
                    <li>
                      • Việc ước tính chi phí và thời gian sao cho phù hợp.
                    </li>
                  </ul>
                </div>
                <div className="mt-3 ml-10">
                  <p className="text-blue-600">
                    C. Giai đoạn thực hiện (Execution phase)
                  </p>
                  <ul>
                    <li>
                      • Các trưởng nhóm và quản lý dự án được đưa vào hoạt động
                      để xây dựng các sản phẩm, là người hỗ trợ khách hàng, hoàn
                      thành nhiệm vụ, thực hiện các quy trình và hơn thế nữa.
                      Việc giao tiếp trên tất cả các phần của dự án là cần thiết
                      và quan trọng đối với sự thành công của dự án.
                    </li>
                    <li>
                      • Những điều cần thiết cho giai đoạn thực hiện:
                      <ul className="ml-5 ">
                        <li>
                          i. Các cuộc họp thường xuyên:
                          <p className="ml-5">
                            Luôn cập nhật đầy đủ thông tin đến các Member thông
                            qua các cuộc họp trực tuyến được quy định thời gian
                            từ trước dựa vào Sprint hiện tại đang được thực
                            hiện. Đảm bảo việc giao tiệp kịp thời và rõ ràng, ít
                            điểm mù hơn, làm việc theo nhóm tốt hơn và có kế
                            hoạch đối ứng tốt nhất.
                          </p>
                        </li>
                        <li className="mt-3">
                          ii. Minh bạch:
                          <p className="ml-5">
                            Tránh tình trạng làm việc khi chưa nắm rõ bối cảnh
                            chung của dự án, để khi gặp các trở ngại có thể dễ
                            dàng giải quyết. Xác định rõ người chịu trách nhiệm
                            cho nhiệm vụ bằng các mô tả chi tiết cho Issue.
                          </p>
                        </li>
                        <li className="mt-3">
                          iii. Quản trị xung đột
                          <p className="ml-5">
                            Các vấn đề chắc chắn sẽ xảy ra. Giảm thiểu sự cố
                            bằng cách mỗi Issue có người Assignee để hoàn thành
                            nhiệm vụ và 1 người có trách nhiệm kiểm tra tiến độ
                            và độ hiệu quả của công việc đó để có thể lên tiếng
                            và nêu lên những lo ngại, tắc nghẽn hoặc bất cứ điều
                            gì có thể gây ra điểm yếu trong chuỗi.
                          </p>
                        </li>
                        <li className="mt-3">
                          iv. Báo cáo tiến độ
                          <p className="ml-5">
                            Cập nhật thường xuyên được chia sẻ trong một
                            Stand-up Meeting, với các đồ thị thống kê các Issue
                            đã giải quyết trong 1 khoảng thời gian nhất định
                            (thường là theo tuần hay tháng).
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
                      • Nếu không thể đo lường được khối lượng công việc của dự
                      án, thì không thể quản lý theo cách tốt nhất. Giai đoạn
                      này yêu cầu kiểm tra để đảm bảo mọi thứ đều phù hợp với
                      những gì đã thống nhất trước đó. Các chỉ số liên quản
                      chính là gì? Cần thực hiện những gì để đáp ứng thời hạn và
                      các thông số liên quản đó?
                    </li>
                    <li>
                      • Tổ chức các cuộc họp trực tuyến với những người có trách
                      nhiệm chính để biết các điểm kiểm tra, đánh giá và báo cáo
                      hiệu suất thường kỳ.{" "}
                    </li>
                  </ul>
                </div>
                <div className="mt-3 ml-10">
                  <p className="text-blue-600">
                    E. Giai đoạn kết thúc (Project Closure)
                  </p>
                  <ul>
                    <li>
                      • Kết thúc dự án cũng quan trọng như bắt đầu. Còn được gọi
                      là giai đoạn “theo dõi”, đây là khoảng thời gian khi dự án
                      hoàn thành đã sẵn sàng để ra mắt công chúng. Trọng tâm
                      chính ở đây là phát hành và phân phối sản phẩm.
                    </li>
                    <li>
                      • Điều quan trọng đối với người quản lý dự án là đánh giá
                      vòng đời của dự án từ đầu đến cuối bằng cách:
                      <ul className="ml-5 ">
                        <li>
                          i. Điều tra hiệu suất dự án
                          <p className="ml-5">
                            Mọi thành viên có đạt được mục tiêu đã đề ra của họ
                            không? Dự án có được hoàn thành trong ngân sách và
                            thời gian không? Dự án có giải quyết được vấn đề gì
                            không? Giải quyết những câu hỏi này sẽ giúp việc
                            đánh giá xem dự án có thành công hay không.
                          </p>
                        </li>
                        <li className="mt-3">
                          ii. Xem xét hiệu suất của nhóm
                          <p className="ml-5">
                            Hiệu suất của các thành viên trong nhóm có thể được
                            đi sâu hơn vào từng cá nhân để đánh giá sự thành
                            công trong nhóm. Kiểm tra chất lượng, KPI và cuộc
                            họp trực tuyến có tác dụng cung cấp thông tin chi
                            tiết rõ ràng hơn về hiệu suất.
                          </p>
                        </li>
                        <li className="mt-3">
                          iii. Đánh giá và lập hồ sơ kết thúc dự án
                          <p className="ml-5">
                            Một bản trình bày kỹ lưỡng bao gồm các tài liệu hỗ
                            trợ thể hiện sự phát triển của dự án từ khi hình
                            thành đến khi giao hàng đảm bảo hoàn thành đúng cách
                            cho khách hàng và các bên liên quan.
                          </p>
                        </li>
                        <li className="mt-3">
                          iv. Yêu cầu đánh giá
                          <p className="ml-5">
                            Đánh giá cuối cùng của dự án cung cấp một cái nhìn
                            sâu hơn về điểm mạnh và điểm yếu, từ đầu đến cuối.
                            Tìm hiểu thông tin chi tiết và rút ra bài học cho
                            lần sau.
                          </p>
                        </li>
                        <li className="mt-3">
                          v. Vượt quá ngân sách
                          <p className="ml-5">
                            Có thể xác định chính xác tình trạng thất thoát ngân
                            sách cũng như các nguồn lực chưa được sử dụng giúp
                            hiểu rõ hơn về thành công (hoặc thất bại) và giúp
                            quản lý lãng phí.
                          </p>
                        </li>
                      </ul>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </TabPanel>
          <TabPanel value={value} index={1}>
            Item Two
          </TabPanel>
          <TabPanel value={value} index={2}>
            Item Three
          </TabPanel>
          <TabPanel value={value} index={3}>
            Item Four
          </TabPanel>
          <TabPanel value={value} index={4}>
            Item Five
          </TabPanel>
          <TabPanel value={value} index={5}>
            Item Six
          </TabPanel>
          <TabPanel value={value} index={6}>
            Item Seven
          </TabPanel>
        </div>
      </div>
    </>
  );
};

export default TutorialTest;
