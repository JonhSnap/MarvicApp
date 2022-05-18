import React, { useEffect, useState } from 'react'
import ContainerBoard from '../components/containers/ContainerBoard'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux';
import Sidebar from '../components/sidebar/Sidebar';
import { MembersProvider } from '../contexts/membersContext';
import { ListIssueProvider } from '../contexts/listIssueContext';

function BoardPage() {
  const key = useParams().key;
  const { projects } = useSelector(state => state.projects);
  const [currentProject, setCurrentProject] = useState({});
  useEffect(() => {
    const currProject = projects.find(item => item.key === key);
    setCurrentProject(currProject);
  }, [projects, key])

  return (
    <ListIssueProvider>
      <MembersProvider>
        <div className="flex">
          <div className='basis-[20%]'>
            <Sidebar nameProject={currentProject.name}></Sidebar>
          </div>
          <div className='basis-[80%]'>
            <ContainerBoard project={currentProject}></ContainerBoard>
          </div>
        </div>
      </MembersProvider>
    </ListIssueProvider>
  )
}

export default BoardPage