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
const TutorialStudy = () => {
  const classes = useStyles();
  const [value, setValue] = React.useState("one");

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  return (
    <div className={`${classes.root}  ml-[-20px] mt-[-12px] `}>
      <h2 className="text-2xl font-bold text-blue-800 uppercase heading-test animate__animated animate__rollIn animate__delay-1s">
        Study the current status of apps in the same segment
      </h2>
      <AppBar position="static">
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="wrapped label tabs example"
        >
          <Tab value="one" label="Jira" wrapped {...a11yProps("one")} />
          <Tab value="two" label="Monday" {...a11yProps("two")} />
          <Tab value="three" label="Trello" {...a11yProps("three")} />
        </Tabs>
      </AppBar>
      <TabPanel value={value} index="one">
        <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft">
          <div>
            <h2 className="text-xl font-semibold">1. Strength</h2>
            <ul className="mt-1 ml-5">
              <li>• Fully functional for professional users</li>
              <li>• Smooth drag and drop operations</li>
              <li>• Easy to find issues</li>
              <li>
                • The notification function helps users not to miss information.
              </li>
              <li>• Stay on schedule with a timeline.</li>
              <li>
                • Supporting businesses to coordinate multiple projects at the
                same time.
              </li>
              <li>• Good user customization.</li>
              <li>
                • There is an ecosystem that supports many products, helping
                users to operate synchronized with other applications.
              </li>
            </ul>
          </div>
          <div>
            <h2 className="mt-4 text-xl font-semibold">2. Weakness</h2>
            <ul className="mt-1 ml-5">
              <li>
                • There are many versions over the years, forcing users to spend
                plenty of time to get used to the big changes.
              </li>
              <li>
                •Due to continuous development, it is inevitable that users was
                using the stable version suddenly got renewed and problems
                occurred error occurred.
              </li>
              <li>
                • Instructions may be outdated due to continuous development by
                Jira.
              </li>
              <li>• The majority of users need to take one or more courses.</li>
              <li>
                • There is too much information on the interface. Easy to make
                users suffer confused when using it.
              </li>
              <li>
                • Does not support people who are new to the Agile concept
                (which is management model used by Jira) is used in multiple
                roles in a project judgment.
              </li>
              <li>• Limited many functions when using it for free.</li>
              <li>
                • The cost is high, after 7 days of trial, the more businesses
                have The larger the scale, the more it costs: $10 per month for
                up to 10 accounts; from 11-100 accounts is $7/account/month
              </li>
              <li>
                • It takes a lot of time and effort to set up, so it can only be
                maximized effective for large projects, not suitable for small
                and medium projects (under 3 months)
              </li>
              <li>• Complex workflow that requires thorough understanding</li>
            </ul>
          </div>
        </div>
      </TabPanel>
      <TabPanel value={value} index="two">
        <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft">
          <div>
            <h2 className="text-xl font-semibold">1. Điểm mạnh</h2>
            <ul className="mt-1 ml-5">
              <li>
                • Có tính năng thảo luận trên từng công việc, có thể hội thảo
                nội bộ mà cũng có thể thảo luận qua lại với khách hàng.{" "}
              </li>
              <li>• Giao diện hiện đại.</li>
              <li>• Có thể tích hợp với các nhà cung cấp dịch vụ thứ 3.</li>
            </ul>
          </div>
          <div>
            <h2 className="mt-4 text-xl font-semibold">2. Điểm yếu</h2>
            <ul className="mt-1 ml-5">
              <li>• Giao diện không đơn giản hay tinh.</li>
              <li>
                • Thiếu các Quick Helps để giúp người dùng có thể làm quen nhanh
                hơn.
              </li>
              <li>• Mức phí cao</li>
            </ul>
          </div>
        </div>
      </TabPanel>
      <TabPanel value={value} index="three">
        <div className="overflow-y-auto have-y-scroll h-[400px] animate__animated animate__lightSpeedInLeft">
          <div>
            <h2 className="text-xl font-semibold">1. Điểm mạnh</h2>
            <ul className="mt-1 ml-5">
              <li>
                <h3 className="text-base text-blue-800">A. Dễ sử dụng</h3>Trello
                có giao diện làm việc cực kỳ thân thiện, các thao tác không quá
                phức tạp. Bạn chỉ cần tạo danh sách, thêm thẻ việc cần làm hay
                việc thêm thành viên cũng đơn giản chỉ cần thêm email hoặc gửi
                link truy cập. Ngoài ra trên Trello còn cung cấp nhiều mẫu bảng
                với các chủ đề khác nhau khá đa dạng và đẹp mắt.
              </li>
              <li>
                <h3 className="text-base text-blue-800">B. Miễn phí</h3>Trello
                hiện đang cung cấp sản phẩm dưới hình thức Freemium, tức là
                người dùng có thể sử dụng miễn phí các tính năng cơ bản. Với các
                tính năng nâng cao thì bạn phải trả thêm phí từ 5$ một tháng
                /người. Tuy nhiên các tác vụ cơ bản chắc hẳn cũng đủ giúp bạn
                quản lý công việc của mình rồi.
              </li>
              <li>
                <h3 className="text-base text-blue-800">
                  C. Theo dõi trực quan
                </h3>
                Trello được thiết kế dựa trên phương pháp quản lý dự án Kanban,
                nên các giai đoạn công việc sẽ được phân chia thành các danh
                sách như các to-do list. Và chỉ cần nhìn vào giao diện, là bạn
                đã nắm bắt ngay được tiến độ dự án một cách trực quan nhất.
              </li>
            </ul>
          </div>
          <div>
            <h2 className="text-xl font-semibold">2. Điểm yếu</h2>
            <ul className="mt-1 ml-5">
              <li>
                <h3 className="text-base text-blue-800">
                  A. Tương tác kém giữa các thành viên
                </h3>
                Mặc thù trong các thẻ, thành viên có thể trao đổi với nhau nhưng
                lại thiếu 1 hộp thư hoặc giao diện cho các thành viên trao đổi
                chung về toàn bộ dự án. Việc bình luận trong thẻ cũng chưa thân
                thiện, bạn không thể bình luận nhanh bằng phím enter mà phải bấm
                lưu khá bất tiện.
              </li>
              <li>
                <h3 className="text-base text-blue-800">
                  B. Không phù hợp cho quản lý thời gian{" "}
                </h3>
                Với duy nhất một giao diện trải theo chiều ngang, Trello gây khó
                khăn cho người dùng trong việc quản lý thời gian chính xác của
                các công việc. Các card được thiết kế độc lập, cản trở việc quản
                lý mối quan hệ giữa các đầu việc (ví dụ: bạn khó biết được việc
                nào làm trước, việc nào làm sau, việc nào phải làm xong thì mới
                có thể làm được việc khác). Muốn tối ưu lại những yếu tố này,
                bạn sẽ cần những phần mở rộng - tích hợp với ứng dụng Gantt
                chart (trong phiên bản trả phí của Trello).
              </li>
              <li>
                <h3 className="text-base text-blue-800">
                  C. Thiếu báo cáo công việc
                </h3>
                Trello có thể là một công cụ khá hay ho cho làm việc nhóm, nhưng
                lại thiếu đi nhiều tính năng thiết yếu đối với vai trò của một
                người Quản lý (Project/Team manager); trong đó phải kể đến việc
                báo báo. Ứng dụng này không có một giao diện cho phép người quản
                lý theo dõi ngay được công việc đã hoàn thành được bao nhiêu %
                so với dự kiến, những cá nhân nào đang đảm bảo được tiến độ công
                việc được giao,...)
              </li>
            </ul>
          </div>
        </div>
      </TabPanel>
    </div>
  );
};

export default TutorialStudy;
