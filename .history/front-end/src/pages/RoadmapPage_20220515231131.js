import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import ContainerRoadmap from "../components/containers/ContainerRoadmap";
// import Roadmap from "../components/roadmap/Roadmap";
import Sidebar from "../components/sidebar/Sidebar";
import { ListIssueProvider } from "../contexts/listIssueContext";
import { SprintProvider } from "../contexts/sprintContext";

function RoadmapPage() {
  const { key } = useParams();

  const { projects } = useSelector((state) => state.projects);
  const [currentProject, setCurrentProject] = useState({});

  useEffect(() => {
    document.title = "Marvic-roadmap";
    const currProject = projects.find((item) => item?.key === key);
    if (Object.entries(currProject).length > 0) {
      setCurrentProject(currProject);
    }
  }, [projects]);
  return (
    <>
      <SprintProvider>
        <ListIssueProvider>
          <div className="flex">
            <div className="basis-[20%]">
              <Sidebar nameProject={currentProject.name}></Sidebar>
            </div>
            <div className="basis-[80%]">
              <ContainerRoadmap project={currentProject}></ContainerRoadmap>
            </div>
          </div>
        </ListIssueProvider>
      </SprintProvider>
    </>
  );
}

export default RoadmapPage;
