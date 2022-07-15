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
      <AppBar position="static">
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="wrapped label tabs example"
        >
          <Tab
            value="one"
            label="Vòng đời Quản lý dự án"
            wrapped
            {...a11yProps("one")}
          />
          <Tab
            value="two"
            label="Các giai đoạn trong 1 dự án"
            {...a11yProps("two")}
          />
        </Tabs>
      </AppBar>
      <TabPanel value={value} index="one">
        <span className="ml-5">
          • Project Management Life Cycle (Vòng đời quản lý dự án) là một chuỗi
          các hoạt động thiết yếu để hoàn thành các mục tiêu hoặc chỉ tiêu của
          dự án. Nó là một khuôn mẫu bao gồm các giai đoạn để biến một ý tưởng
          thành hiện thực. Các dự án có thể có phạm vi và mức độ khó khác nhau,
          nhưng chúng có thể được áp dụng tới cấu trúc vòng đời của Quản lý dự
          án, bất kể quy mô của dự án là gì.
        </span>
      </TabPanel>
      <TabPanel value={value} index="two">
        Item Two
      </TabPanel>
      <TabPanel value={value} index="three">
        Item Three
      </TabPanel>
    </div>
  );
};

export default TutorialIntroduce;
