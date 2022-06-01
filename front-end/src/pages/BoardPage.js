import React, { useEffect, useState } from 'react'
import ContainerBoard from '../components/containers/ContainerBoard'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux';
import Sidebar from '../components/sidebar/Sidebar';
import { MembersProvider } from '../contexts/membersContext';
import { ListIssueProvider } from '../contexts/listIssueContext';
import { SprintProvider } from '../contexts/sprintContext';
import { BoardProvider } from '../contexts/boardContext';
import { StageProvider } from '../contexts/stageContext';


function BoardPage() {
  const key = useParams().key;
  const { projects } = useSelector(state => state.projects);
  const [currentProject, setCurrentProject] = useState({});

  useEffect(() => {
    document.title = 'Marvic-Board';
    const currProject = projects.find(item => item.key === key);
    setCurrentProject(currProject);
  }, [projects, key])

  return (
    <ListIssueProvider>
      <MembersProvider>
        <SprintProvider>
          <BoardProvider>
            <StageProvider>
              <div className="flex">
                <div className='w-[20%] shrink-0'>
                  <Sidebar nameProject={currentProject.name}></Sidebar>
                </div>
                <div className='w-[80%]'>
                  <ContainerBoard project={currentProject}></ContainerBoard>
                </div>
              </div>
            </StageProvider>
          </BoardProvider>
        </SprintProvider>
      </MembersProvider>
    </ListIssueProvider>
  )
}

export default BoardPage