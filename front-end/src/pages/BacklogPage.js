import React, { useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { BASE_URL} from '../util/constants'
import axios from 'axios'

import Sidebar from '../components/sidebar/Sidebar'
import ContainerBacklog from '../components/containers/ContainerBacklog'


function BacklogPage() {
  const { key } = useParams();
  
  const { projects } = useSelector(state => state.projects);
  const [currentProject, setCurrentProject] = useState({});
  const [listIssue, setListIssue] = useState([]);

  useEffect(() => {
    const currProject = projects.find(item => item?.key === key);
    if(Object.entries(currProject).length > 0) {
      const fetchIssue = async() => {
        const resp = await axios.get(`${BASE_URL}/api/Issue/GetIssuesByIdProject?idProject=${currProject.id}`)
        if(resp.status === 200) {
          setListIssue([...resp.data]);
        }
      }
      fetchIssue();
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
          <ContainerBacklog setListIssue={setListIssue} project={currentProject} listIssue={listIssue}></ContainerBacklog>
        </div>
      </div>
    </>
  )
}

export default BacklogPage