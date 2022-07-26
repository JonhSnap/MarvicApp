import React from "react";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
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
    height: 224,
  },
  tabs: {
    borderRight: `1px solid ${theme.palette.divider}`,
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
          <TabPanel value={value} index={0}>
            <div className="flex flex-col">
              <h2 className="text-2xl font-bold heading-test">
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
              <div className="ml-5">
                <h3 className="text-base font-semibold ">
                  1.2 Các giai đoạn trong 1 dự án (Project Management Life Cycle
                  Phases):
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
