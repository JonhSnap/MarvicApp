import React, { useEffect, useReducer, useRef, useState } from 'react'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux'

import Sidebar from '../components/sidebar/Sidebar'
import ContainerBacklog from '../components/containers/ContainerBacklog'


function BacklogPage() {
  const { key } = useParams();

  const { projects } = useSelector(state => state.projects);
  const [currentProject, setCurrentProject] = useState({});

  useEffect(() => {
    document.title = 'Marvic-backlog';
    const currProject = projects.find(item => item?.key === key);
    if (Object.entries(currProject).length > 0) {
      setCurrentProject(currProject);
    }
  }, [projects])


  return (
    <>

      <div className="flex overflow-hidden h-main-backlog">
        <div className='basis-[20%] h-main-backlog'>
          <Sidebar nameProject={currentProject.name}></Sidebar>
        </div>
        <div className='basis-[80%] h-main-backlog'>
          <ContainerBacklog project={currentProject}></ContainerBacklog>
        </div>
      </div>

    </>
  )
}

export default BacklogPage