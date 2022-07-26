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
          <TabPanel value={value} index={0} className="w-[900px]">
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
                  <p className="mt-2 ">
                    Tất cả các thông tin liên quan đến dự án được note vào Điều
                    lệ dự án và các biên bản của các bên liên quan. Khi điều lệ
                    dự án được phê duyệt, dự án chính thức được bắt đầu bởi
                    Project Owner.
                  </p>
                </div>
              </div>
            </div>
          </TabPanel>
          <TabPanel value={value} index={1}>
            <div class="header" id="top">
              <h1>Scroll Down</h1>
              <i class="fa fa-angle-down animated bounce"></i>
            </div>

            <div class="section animate">
              <div class="middle">
                <img src="https://images.unsplash.com/photo-1460400408855-36abd76648b9?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
              <div class="left title">
                <div class="content">
                  <h2>A glorious nature shot.</h2>
                  <p>
                    Wow. What a wonderful image. And look! there are even more
                    images on the right side. Amazing. If you click below, I bet
                    you'll get teleported to a magical land.
                  </p>
                  <a href="#" class="btn-primary">
                    Learn more
                  </a>
                </div>
              </div>
              <div class="right tiles">
                <img src="https://images.unsplash.com/photo-1460400408855-36abd76648b9?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1460400408855-36abd76648b9?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1460400408855-36abd76648b9?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1460400408855-36abd76648b9?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
            </div>

            <div class="section">
              <div class="middle">
                <img src="https://images.unsplash.com/photo-1464655646192-3cb2ace7a67e?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
              <div class="right title">
                <div class="content">
                  <h2>Check out this guy.</h2>
                  <p>
                    What an interesting looking person! I wonder if they've ever
                    climbed Mount Everest, or seen the Egyptian Pyramids. If
                    not, I hope that one day they get to. You go random stock
                    image person! Follow your dreams!
                  </p>
                </div>
              </div>

              <div class="left tiles">
                <img src="https://images.unsplash.com/photo-1464655646192-3cb2ace7a67e?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1464655646192-3cb2ace7a67e?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1464655646192-3cb2ace7a67e?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1464655646192-3cb2ace7a67e?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
            </div>

            <div class="section">
              <div class="middle">
                <img src="https://images.unsplash.com/photo-1465326117523-6450112b60b2?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
              <div class="left title">
                <div class="content">
                  <h2>That is one pretty building.</h2>
                  <p>
                    I once thought about becoming an architect. I wanted to
                    create a house fit for a king. But then I failed maths. So I
                    became a frontend developer instead.
                  </p>
                </div>
              </div>

              <div class="right tiles">
                <img src="https://images.unsplash.com/photo-1465326117523-6450112b60b2?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1465326117523-6450112b60b2?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1465326117523-6450112b60b2?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1465326117523-6450112b60b2?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
            </div>

            <div class="section">
              <div class="middle">
                <img src="https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
              <div class="right title">
                <div class="content">
                  <h2>The future is now.</h2>
                  <p>
                    Check out that technology! Imagine if we went back in time
                    and put one of those in the hands of a neanderthal. Do you
                    think they'd be impressed, or just try to club us to death?
                  </p>
                </div>
              </div>

              <div class="left tiles">
                <img src="https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
                <img src="https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?dpr=2&auto=format&crop=entropy&fit=crop&w=250&h=250&q=80" />
              </div>
            </div>

            <div class="footer">
              <a href="#top" class="scrollTo">
                <i class="fa fa-angle-up animated bounce"></i>
              </a>
              <h1>Scroll Up</h1>
            </div>
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
