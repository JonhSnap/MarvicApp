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
import { LabelProvider } from '../contexts/labelContext';
import { ModalProvider } from '../contexts/modalContext';
import axios from 'axios';
import { BASE_URL, KEY_ROLE_USER } from '../util/constants';


function BoardPage() {
  const key = useParams().key;
  const { projects } = useSelector(state => state.projects);
  const [currentProject, setCurrentProject] = useState({});

  useEffect(() => {
    document.title = 'Marvic-Board';
    const currProject = projects.find(item => item.key === key);
    setCurrentProject(currProject);
  }, [projects, key]);
  useEffect(() => {
    const setRole = async () => {
      if (currentProject?.id) {
        const resp = await axios.get(`${BASE_URL}/api/Project/SetUserRoleByIdProject?idProject=${currentProject?.id}`);
        if (resp && resp.status === 200) {
          localStorage.setItem(KEY_ROLE_USER, JSON.stringify(resp.data.value));
        }
      }
    }
    setRole();
  }, [currentProject?.id])

  return (
    <BoardProvider>
      <ModalProvider project={currentProject}>
        <div className="flex">
          <div className='w-[20%] shrink-0'>
            <Sidebar nameProject={currentProject.name}></Sidebar>
          </div>
          <div className='w-[80%]'>
            <ContainerBoard project={currentProject}></ContainerBoard>
          </div>
        </div>
      </ModalProvider>
    </BoardProvider>
  )
}

export default BoardPage