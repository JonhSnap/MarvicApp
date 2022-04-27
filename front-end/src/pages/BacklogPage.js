import React, { useEffect, useRef, useState } from 'react'
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { BASE_URL} from '../util/constants'
import axios from 'axios'

import Sidebar from '../components/sidebar/Sidebar'
import MemberComponent from '../components/board/MemberComponent'
import HeaderPlanComponent from '../components/headerPlanning/HeaderPlanComponent'
import '../../src/index.scss'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleDown, faSquareCheck, faTimes, faAngleRight, faFlag, faBolt, faCheck, faLock, faEye, faThumbsUp, faTimeline, faPaperclip, faLink, faPlus, faArrowDownShortWide, faArrowDownWideShort } from '@fortawesome/free-solid-svg-icons'
import OptionComponent from '../components/option/OptionComponent'
import CreateComponent from '../components/CreateComponent'
import OptionHeaderBacklogComponent from '../components/option/OptionHeaderBacklogComponent'
import OptionItemBacklogComponent from '../components/option/OptionItemBacklogComponent'
import ButtonBacklogComponent from '../components/backlog/ButtonBacklogComponent'
import CKEditorComponent from '../components/CKEditorComponent'
import TaskItemComponent from '../components/backlog/TaskItemComponent'


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
          <div className='wrap-backlog w-full h-full flex flex-col'>
            <HeaderPlanComponent project={currentProject} memberComponent={<MemberComponent />} />
            <div className='w-full h-full flex-1 flex-col'>
              <div className='flex flex-row  h-full w-full flex-[3] '>
                <div className='p-2 flex-1 h-full mx-4 min-h-[10rem] bg-[#f4f5f7] rounded-[5px] flex items-center flex-col pb-9'>
                  <div className='flex justify-between w-full px-4 py-2'>
                    <span>Epic</span>
                    <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faTimes} />
                  </div>
                  <div className='w-full p-3 m-[0.2rem] min-h-[3rem] h-fit bg-white flex items-center shadow-md rounded-[5px]'>
                    issues without epic
                  </div>
                  <div className='w-full p-3 m-[0.2rem] min-h-[3rem] h-fit bg-white flex flex-col justify-center shadow-md rounded-[5px]'>
                    <div className='flex items-center'>
                      <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleRight} />
                      <div className='h-5 w-5 inline-block bg-[#d0c6ff] rounded-[5px] mx-2'></div>
                      issues without epic
                    </div>
                    <div className='h-2 w-full bg-[#ddd] rounded-[5px] my-2 relative'>
                      <div className='absolute top-0 left-0  bottom-0 bg-blue-600 rounded-[10px]' style={{ width: "40%" }}>

                      </div>
                    </div>
                  </div>
                  <CreateComponent createWhat={"epic"} />
                </div>
                <div className='main-backlog pb-9 overflow-auto flex-[3] w-full h-full  flex justify-center mb-10'>
                  <div className='backlog-item py-2 flex-1 mx-4 min-h-[10rem] bg-[#f4f5f7] rounded-[5px] flex items-center flex-col '>
                    <div className='header-backlog-item w-[98%] py-3 flex justify-between items-center'>
                      <div className='header-right'>
                        <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                        <div className='name-sprint inline-block'>
                          <span className='name font-medium pr-2'>MPM Sprint 1</span>
                        </div>
                        <div className='create-day inline-block font-light pl-2'>
                          <span className='day pr-1'>19 Apr - 17 May</span>
                          <span> (5 issues) </span>
                        </div>
                      </div>
                      <div className='header-left flex items-center h-9'>
                        <div className='state-sprint flex'>
                          <div className='rounded-full  inline-flex w-5 h-5 text-xs bg-[#dfe1e6] mx-[0.2rem]'>
                            <span className='m-auto'>4</span>
                          </div>
                          <div className='rounded-full  inline-flex w-5 h-5 text-xs bg-[#0052cc]  mx-[0.2rem] text-white'>
                            <span className='m-auto'>4</span>
                          </div>
                          <div className='rounded-full  inline-flex w-5 h-5 text-xs bg-[#00875a]  mx-[0.2rem] text-white'>
                            <span className='m-auto'>4</span>
                          </div>
                        </div>
                        {/* <div className='btn-main rounded-[5px] py-1 px-2  w-fit h-full mx-4 border-solid border-[#000] border-[1px]'>
                                        <span>Complete sprint</span>
                                    </div> */}
                        <ButtonBacklogComponent text={"Complete sprint"} />
                        <OptionComponent child={<OptionHeaderBacklogComponent />} />
                      </div>
                    </div>
                    <div className='main w-[98%] h-fit min-h-[5rem]'>
                    {
                      listIssue.length > 0 &&
                      listIssue.map(item => (
                        <TaskItemComponent key={item.id} issue={item} />            
                      ))
                    }
                      <CreateComponent createWhat={"issues"} />
                    </div>
                  </div>
                </div>
               
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  )
}

export default BacklogPage