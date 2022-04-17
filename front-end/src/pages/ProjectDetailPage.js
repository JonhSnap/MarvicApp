import React from 'react'
import ContainerBoard from '../components/containers/ContainerBoard'
import Sidebar from '../components/sidebar/Sidebar'

function ProjectDetailPage() {

  return (
    <div className='project-board flex'>
      <Sidebar></Sidebar>
      <ContainerBoard></ContainerBoard>
    </div>
  )
}

export default ProjectDetailPage