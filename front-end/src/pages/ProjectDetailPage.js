import React, { useState } from 'react'
import ContainerBoard from '../components/containers/ContainerBoard'
import Sidebar from '../components/sidebar/Sidebar'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux';

function ProjectDetailPage() {
  const key = useParams().key;
  const { projects } = useSelector(state => state.projects);
  const [currentProject] = useState(() => {
    return projects.find(project => project.key === key);
  })  

  return (
    <div className='project-board flex'>
      <Sidebar></Sidebar>
      <ContainerBoard project={currentProject}></ContainerBoard>
    </div>
  )
}

export default ProjectDetailPage