import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import ContainerRoadmap from "../components/containers/ContainerRoadmap";
// import Roadmap from "../components/roadmap/Roadmap";
import Sidebar from "../components/sidebar/Sidebar";
import { BoardProvider } from "../contexts/boardContext";
import { LabelProvider } from "../contexts/labelContext";
import { ListIssueProvider } from "../contexts/listIssueContext";
import { MembersProvider } from "../contexts/membersContext";
import { SprintProvider } from "../contexts/sprintContext";
import { StageProvider } from "../contexts/stageContext";

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
      <BoardProvider>
        <StageProvider>
          <SprintProvider>
            <ListIssueProvider>
              <MembersProvider>
                <LabelProvider>
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
                </LabelProvider>
              </MembersProvider>
            </ListIssueProvider>
          </SprintProvider>
        </StageProvider>
      </BoardProvider>
    </>
  );
}

export default RoadmapPage;
