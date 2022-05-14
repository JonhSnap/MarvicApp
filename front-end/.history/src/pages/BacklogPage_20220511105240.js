import React, { useEffect, useReducer, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { BASE_URL } from "../util/constants";
import axios from "axios";

import Sidebar from "../components/sidebar/Sidebar";
import ContainerBacklog from "../components/containers/ContainerBacklog";
import { ListIssueProvider } from "../contexts/listIssueContext";
import {
  fetchIssue,
  initialIssues,
  listIssueReducer,
} from "../reducers/listIssueReducer";
import { GET_ISSUES } from "../reducers/actions";

function BacklogPage() {
  const { key } = useParams();

  const { projects } = useSelector((state) => state.projects);
  const [currentProject, setCurrentProject] = useState({});

  useEffect(() => {
    document.title = "Marvic-backlog";
    const currProject = projects.find((item) => item?.key === key);
    if (Object.entries(currProject).length > 0) {
      setCurrentProject(currProject);
    }
  }, [projects]);

  return (
    <>
      <ListIssueProvider>
        <div className="flex overflow-hidden h-main-backlog">
          <div className="basis-[20%] h-main-backlog">
            <Sidebar nameProject={currentProject.name}></Sidebar>
          </div>
          <div className="basis-[80%] h-main-backlog">
            <ContainerBacklog project={currentProject}></ContainerBacklog>
          </div>
        </div>
      </ListIssueProvider>
    </>
  );
}

export default BacklogPage;
