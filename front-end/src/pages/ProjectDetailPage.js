import React, { useEffect, useState } from 'react'
import ContainerBoard from '../components/containers/ContainerBoard'
import Sidebar from '../components/sidebar/Sidebar'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux';

function ProjectDetailPage() {
  const key = useParams().key;
  const { projects } = useSelector(state => state.projects);
  const [currentProject, setCurrentProject] = useState({});
  useEffect(() => {
    const currProject = projects.find(item => item.key === key);
    setCurrentProject(currProject);
  }, [projects, key])

  return (
    <div className='project-board flex'>
      <Sidebar></Sidebar>
      <ContainerBoard project={currentProject}></ContainerBoard>
    </div>
  )
}

export default ProjectDetailPage