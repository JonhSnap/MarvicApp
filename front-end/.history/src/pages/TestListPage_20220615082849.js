import React, { useEffect, useState } from "react";

import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import Sidebar from "../components/sidebar/Sidebar";
import ContainerBacklog from "../components/containers/ContainerBacklog";
import { ListIssueProvider } from "../contexts/listIssueContext";
import { MembersProvider } from "../contexts/membersContext";
import { SprintProvider } from "../contexts/sprintContext";
import { StageProvider } from "../contexts/stageContext";
import { BoardProvider } from "../contexts/boardContext";
import { LabelProvider } from "../contexts/labelContext";

const TestListPage = () => {
  return (
    <SprintProvider>
      <ListIssueProvider>
        <MembersProvider>
          <StageProvider>
            <BoardProvider>
              <LabelProvider>
                <div className="flex overflow-hidden h-main-backlog">
                  <div className="basis-[20%] h-main-backlog">
                    <Sidebar nameProject={currentProject.name}></Sidebar>
                  </div>
                  <div className="basis-[80%]">
                    <ContainerArchive
                      project={currentProject}
                    ></ContainerArchive>
                  </div>
                </div>
              </LabelProvider>
            </BoardProvider>
          </StageProvider>
        </MembersProvider>
      </ListIssueProvider>
    </SprintProvider>
  );
};

export default TestListPage;
