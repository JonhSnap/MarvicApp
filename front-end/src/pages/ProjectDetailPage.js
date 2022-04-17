import React from 'react'
import ContainerBoard from '../components/containers/ContainerBoard'
import Sidebar from '../components/sidebar/Sidebar'
import { useParams } from 'react-router-dom'

function ProjectDetailPage() {
  const idProject = useParams().id;
  console.log('id ~ ', idProject);

  return (
    <div className='project-board flex'>
      <Sidebar></Sidebar>
      <ContainerBoard></ContainerBoard>
    </div>
  )
}

export default ProjectDetailPage