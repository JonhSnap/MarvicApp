import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import ContainerRoadmap from "../components/containers/ContainerRoadmap";
// import Roadmap from "../components/roadmap/Roadmap";
import Sidebar from "../components/sidebar/Sidebar";
import { OpenIssueProvider } from "../contexts/openChildIssueContext";
import { ModalProvider } from "../contexts/modalContext";

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
      <OpenIssueProvider>
        <ModalProvider>
          <div className="flex overflow-hidden h-main-backlog">
            <div className="basis-[20%] h-main-backlog">
              <Sidebar nameProject={currentProject.name}></Sidebar>
            </div>
            <div className="basis-[80%] h-main-backlog">
              <ContainerRoadmap
                project={currentProject}
              ></ContainerRoadmap>
            </div>
          </div>
        </ModalProvider>
      </OpenIssueProvider>
    </>
  );
}

export default RoadmapPage;
