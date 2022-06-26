import axios from "axios";
import React, { useEffect, useState } from "react";
import { BASE_URL } from "../../util/constants";
import ArchiveSprint from "../archive/ArchiveSprint";
import TopDetail from "../project-detail/TopDetail";
import "./ContainerArchive.scss";
import { v4 } from "uuid";
import nullImg from "../../images/null.png";
import BreadcrumbsComp from "../project-detail/Breadcrumbs";

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
      id={`scrollable-auto-tabpanel-${index}`}
      aria-labelledby={`scrollable-auto-tab-${index}`}
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
    id: `scrollable-auto-tab-${index}`,
    "aria-controls": `scrollable-auto-tabpanel-${index}`,
  };
}

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    width: "100%",
    backgroundColor: theme.palette.background.paper,
  },
}));

const ContainerArchive = ({ project }) => {
  const classes = useStyles();
  const [value, setValue] = React.useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  const [archive, setArchive] = useState([]);
  useEffect(() => {
    const getArchive = async () => {
      await axios
        .get(`${BASE_URL}/api/Issue/GetIssuesArchive/${project.id}`)
        .then((res) => {
          setArchive(res.data);
        });
    };
    if (project && Object.entries(project).length > 0) {
      getArchive();
    }
  }, [project]);
  return (
    <div className="p-[40px]">
      <div className="flex flex-col w-full">
        <BreadcrumbsComp />
        <h2 className="flex justify-center text-4xl font-semibold text-blue-500">
          Archive
        </h2>
        <div className="overflow-y-auto have-y-scroll h-[500px]">
          {archive && archive.length > 0 ? (
            <div className={classes.root}>
              <AppBar position="static" color="default">
                <Tabs
                  value={value}
                  onChange={handleChange}
                  indicatorColor="primary"
                  textColor="primary"
                  variant="scrollable"
                  scrollButtons="auto"
                  aria-label="scrollable auto tabs example"
                >
                  <Tab label="Item One" {...a11yProps(0)} />
                  <Tab label="Item Two" {...a11yProps(1)} />
                  <Tab label="Item Three" {...a11yProps(2)} />
                  <Tab label="Item Four" {...a11yProps(3)} />
                  <Tab label="Item Five" {...a11yProps(4)} />
                  <Tab label="Item Six" {...a11yProps(5)} />
                  <Tab label="Item Seven" {...a11yProps(6)} />
                </Tabs>
              </AppBar>
              <TabPanel value={value} index={0}>
                Item One
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
          ) : (
            <div className="flex flex-col justify-center w-full">
              <h2 className="text-xl font-semibold">
                No issues have been archived yet
              </h2>
              <div className="w-full flex  justify-center h-[100vh] ">
                <img
                  className="w-[200px] h-[200px] my-[40px] items-center"
                  src={nullImg}
                  alt=""
                />
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default ContainerArchive;
