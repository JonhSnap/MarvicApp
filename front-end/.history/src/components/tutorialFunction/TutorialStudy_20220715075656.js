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
        Study các hiện trạng của các app cùng phân khúc
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
            <h2 className="text-xl font-semibold">1. Điểm mạnh</h2>
            <ul className="mt-1 ml-5">
              <li>• Đầy đủ chức năng cho người dùng chuyên nghiệp</li>
              <li>• Các thao tác kéo thả mượt mà</li>
              <li>• Dễ tìm kiếm các issue</li>
              <li>
                • Chức năng thông báo giúp người dùng không bỏ xót thông tin.
              </li>
              <li>• Duy trì kế hoạch nhờ biểu đồ thời gian.</li>
              <li>
                • Hỗ trợ doanh nghiệp có thể phối hợp nhiều dự án cùng lúc.
              </li>
              <li>• Khả năng tùy biến của người dùng tốt.</li>
              <li>
                • Có 1 hệ sinh thái hỗ trợ nhiều sản phẩm, giúp người dùng hoạt
                động 1 cách đồng bộ với các ứng dụng khác.
              </li>
            </ul>
          </div>
          <div>
            <h2 className="mt-4 text-xl font-semibold">2. Điểm yếu</h2>
            <ul className="mt-1 ml-5">
              <li>
                • Có nhiều version qua các năm, bắt buộc người dùng phải dành
                nhiều thời gian để làm quen lại khi có các thay đổi lớn.
              </li>
              <li>
                • Do phát triển liên tục nên sẽ không tránh khỏi việc người dùng
                đang xử dụng phiên bản stable đột nhiên bị đổi mới và xảy ra các
                lỗi xảy ra.
              </li>
              <li>
                • Các hướng dẫn có thể bị lỗi thời do Jira liên tục phát triển.
              </li>
              <li>
                • Số đông người dùng cần tham gia một hoặc nhiều khóa học.
              </li>
              <li>
                • Có quá nhiều thông tin trên giao diện. Dễ làm người dùng bị
                bối rối khi mới sử dụng.
              </li>
              <li>
                • Không hỗ trợ cho người mới biết đến khái niệm Agile (là mô
                hình quản lý mà Jira dùng) được sử dụng nhiều vai trò trong 1 dự
                án.
              </li>
              <li>• Giới hạn nhiều chức năng khi sử dụng miễn phí.</li>
              <li>
                • Chi phí cao, sau 7 ngày dùng thử thì doanh nghiệp càng có quy
                mô lớn thì càng tốn nhiều chi phí: $10 mỗi tháng dành cho tối đa
                10 tài khoản; từ 11-100 tài khoản là $7/tài khoản/tháng
              </li>
              <li>
                • Tốn nhiều thời gian và công sức để setup nên chỉ phát huy tối
                ưu hiệu quả với dự án lớn, không phù hợp với dự án vừa và nhỏ
                (dưới 3 tháng)
              </li>
              <li>
                • Quy trình làm việc phức tạp đòi hỏi phải tìm hiểu kỹ lưỡng
              </li>
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
    </div>
  );
};

export default TutorialStudy;
