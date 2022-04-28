import React, { useContext, useEffect, useRef, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import useModal from '../../hooks/useModal';
import { getProjects, updateProjects } from '../../redux/apiRequest';
import AddMemberPopup from '../popup/AddMemberPopup';
import { BASE_URL } from '../../util/constants'
import axios from 'axios'
import './ContainerBacklog.scss'
import { v4 } from 'uuid';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleDown, faSquareCheck, faTimes, faAngleRight, faFlag, faBolt, faCheck, faLock, faEye, faThumbsUp, faTimeline, faPaperclip, faLink, faPlus, faArrowDownShortWide, faArrowDownWideShort } from '@fortawesome/free-solid-svg-icons'
import OptionComponent from '../option/OptionComponent'
import CreateComponent from '../CreateComponent'
import OptionHeaderBacklogComponent from '../option/OptionHeaderBacklogComponent'
import ButtonBacklogComponent from '../backlog/ButtonBacklogComponent'
import TaskItemComponent from '../backlog/TaskItemComponent'
import { useListIssueContext } from '../../contexts/listIssueContext';
import { fetchIssue } from '../../reducers/listIssueReducer';
import { CHANGE_FILTERS_NAME } from '../../reducers/actions';
//project, listIssue, setListIssue
function ContainerBacklog({project}) {
    const { id } = project;
    const [{issues}, dispatchIssue] = useListIssueContext();
    const { currentUser } = useSelector(state => state.auth.login);
    const dispatch = useDispatch();
    const [show, setShow, handleClose] = useModal();
    const timer = useRef();
    const [search, setSearch] = useState('')
    const [showEpic, setShowEpic] = useState(false);
    const [showMembers, setShowMembers] = useState(false);
    const [members, setMembers] = useState([])
    const [focus, setFocus] = useState(false);
    const inputRef = useRef();

    const handleFocus = () => {
        setFocus(true);
    }
    const handleBlur = () => {
        setFocus(false);
    }

    // handle click star
    const handleClickStar = () => {
        const putData = () => {
            const dataPut = {
                ...project,
                id_Updator: currentUser.id,
                updateDate: new Date()
            }
            if (project.isStared === 0) {
                dataPut.isStared = 1;
            } else {
                dataPut.isStared = 0;
            }
            console.log(dataPut);
            updateProjects(dispatch, dataPut);
            getProjects(dispatch, currentUser.id);
        }
        putData();
    }
    // handle change show members
    const handleChangeShowMembers = (e) => {
        if (e.target.matches('.js-changeshow')) {
            setShowMembers(prev => !prev);
        }
    }
    // useEffect get issues
    useEffect(() => {
        if(project && Object.entries(project).length > 0) {
            fetchIssue(project.id, dispatchIssue);
        }
    }, [project])
    useEffect(() => {
        const inputEl = inputRef.current;
        inputEl.addEventListener('focus', handleFocus);
        inputEl.addEventListener('blur', handleBlur);

        return () => {
            inputEl.removeEventListener('focus', handleFocus);
            inputEl.removeEventListener('blur', handleBlur);
        }
    }, [])
    useEffect(() => {
        const fetchMember = async () => {
            try {
                const resp = await axios.get(`${BASE_URL}/api/Project/GetAllMemberByIdProject?IdProject=${project.id}`);
                const data = resp.data;
                setMembers(data);
            } catch (error) {
                console.log(error);
            }
        }
        if (id) {
            fetchMember()
        } else {
            console.log('id null');
        }
    }, [id, show])
    // dispatch search
    useEffect(() => {
        if(project?.id) {
            timer.current = setTimeout(() => {
                dispatchIssue({
                type: CHANGE_FILTERS_NAME,
                payload: search
                })
                fetchIssue(project.id, dispatchIssue)          
            }, 1000);
        }
        return () => clearTimeout(timer.current)
    }, [search])
    const handleClickAdd = () => {
        setShow(true);
    }
    // handle delete member
    const handleDeleteMember = (idUser) => {
        const deleteMemberApi = async () => {
            const resp = await axios.post(`${BASE_URL}/api/Project/RemoveMember`, {
                idProject: id,
                idUser
            })
            if (resp.status === 200) {
                setMembers(prev => {
                    const prevCopy = [...prev];
                    const index = prevCopy.findIndex(item => item.id === idUser);
                    prevCopy.splice(index, 1);
                    return prevCopy;
                })
            }
            console.log('resp ~ ', resp);
        }
        deleteMemberApi()
    }
    // handle close epic
    const handleCloseEpic = (e) => {
        e.stopPropagation();
        setShowEpic(false);
    }
    // handle change search
    // const handleChangeSearch = e => {
    //    setSearch(e.target.value)
    //    dispatchIssue({
    //        type: CHANGE_FILTERS_NAME,
    //        payload: e.target.value
    //    })
    //    fetchIssue(project.id, dispatchIssue)
    // }
  return (
    <div className='container'>
        <div className="top">
            { show && <AddMemberPopup project={project} setShow={setShow} onClose={handleClose}></AddMemberPopup>}
            <div className="navigate">
                <span>Projects</span>
                <span>/</span>
                <span>{project.name}</span>
            </div>
            <div className="wrap-key">
                <h3 className="key">{project.key} board</h3>
                {
                    project.isStared ?
                    <svg onClick={handleClickStar} xmlns="http://www.w3.org/2000/svg" className="h-8 w-8 cursor-pointer" viewBox="0 0 20 20" fill='yellow'>
                    <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                    </svg>
                    :
                    <svg onClick={handleClickStar} xmlns="http://www.w3.org/2000/svg" className="h-8 w-8 cursor-pointer" fill="none" viewBox="0 0 24 24" stroke="#ccc" strokeWidth={2}>
                    <path strokeLinecap="round" strokeLinejoin="round" d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z" />
                    </svg>
                }
            </div>
            <div className="actions">
                <div className="actions">
                    <div className={`wrap-input ${focus ? 'expand' : ''}`}>
                        <input
                        value={search}
                        onChange={e => setSearch(e.target.value)}
                        placeholder={focus ? 'Search this board' : ''}
                        ref={inputRef} type="text" />
                        <svg xmlns="http://www.w3.org/2000/svg" className="icon" viewBox="0 0 20 20" fill="#ccc">
                            <path fillRule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clipRule="evenodd" />
                        </svg>
                    </div>
                    <div className="members">
                        <div className="avatar">
                            <img src="https://images.unsplash.com/photo-1644982647708-0b2cc3d910b7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwxfHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=500&q=60" alt="" />
                        </div>
                        <div onClick={handleChangeShowMembers} className='js-changeshow avatar relative flex items-center justify-center p-2 bg-[#ccc] cursor-pointer'>
                            <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 pointer-events-none" viewBox="0 0 20 20" fill="#999">
                                <path fillRule="evenodd" d="M15.707 4.293a1 1 0 010 1.414l-5 5a1 1 0 01-1.414 0l-5-5a1 1 0 011.414-1.414L10 8.586l4.293-4.293a1 1 0 011.414 0zm0 6a1 1 0 010 1.414l-5 5a1 1 0 01-1.414 0l-5-5a1 1 0 111.414-1.414L10 14.586l4.293-4.293a1 1 0 011.414 0z" clipRule="evenodd" />
                            </svg>
                            {
                                showMembers &&
                                <div className="current-members">
                                    {
                                        members.length > 0 ?
                                            members.map(item => (
                                                <div key={v4()} className='w-full flex justify-between items-center px-[10px]'>
                                                    <span className='text-primary'>{item.userName}</span>
                                                    <div onClick={() => handleDeleteMember(item.id)} className='text-[#ccc]  hover:text-red-500 '>remove</div>
                                                </div>
                                            )) :
                                            <p className='text-sm text-center text-[#999]'>Project has no members</p>
                                    }
                                </div>
                            }
                        </div>
                        <div onClick={handleClickAdd} className="add-member">
                            <svg xmlns="http://www.w3.org/2000/svg" className="icon" fill="none" viewBox="0 0 24 24" stroke="#999" strokeWidth={2}>
                                <path strokeLinecap="round" strokeLinejoin="round" d="M18 9v3m0 0v3m0-3h3m-3 0h-3m-2-5a4 4 0 11-8 0 4 4 0 018 0zM3 20a6 6 0 0112 0v1H3v-1z" />
                            </svg>
                        </div>
                    </div>
                </div>
                <div className="filters">              
                    <div onClick={() => setShowEpic(true)} style={showEpic ? {backgroundColor: '#8777D9', color: 'white'} : {}} className="epic">
                        <span className='title'>Epic</span>
                        <span className="icon">
                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                        <path strokeLinecap="round" strokeLinejoin="round" d="M19 9l-7 7-7-7" />
                        </svg>
                        </span>

                        <div
                        style={showEpic ? { transform: 'translateX(-40%) scale(1)',opacity: 1} : {}}
                        className='epic-dropdown p-2 w-[300px] mx-4 bg-white rounded-[5px] flex items-center flex-col'>
                            <div className='flex justify-between w-full px-4 py-2'>
                                <span>Epic</span>
                                <span onClick={handleCloseEpic} className='inline-flex items-center justify-center w-[20px] h-20px] rounded-full hover:bg-primary hover:bg-opacity-20'>
                                <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faTimes} />
                                </span>
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
                            <CreateComponent project={project} createWhat={"epic"} />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div className="bottom">
        <div className='wrap-backlog w-full max-h-[250px] flex flex-col'>
            <div className='w-full h-full flex-1 flex-col'>
              <div className='flex h-full w-full flex-[3] items-start'>

                <div className='main-backlog overflow-auto grow flex justify-center transition-all'>
                  <div className='backlog-item py-2 flex-1 mx-4 min-h-[10rem] bg-[#f4f5f7] rounded-[5px] flex items-center flex-col '>
                    <div className='header-backlog-item w-[98%] py-3 flex justify-between items-center'>
                      <div className='header-right'>
                        <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                        <div className='name-sprint inline-block'>
                          <span className='name font-medium pr-2'>Backlog</span>
                        </div>
                        <div className='create-day inline-block font-light pl-2'>
                          {/* <span className='day pr-1'>19 Apr - 17 May</span> */}
                          <span> ({issues.length} issues) </span>
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
                        <ButtonBacklogComponent text={"Create sprint"} />
                        <OptionComponent child={<OptionHeaderBacklogComponent />} />
                      </div>
                    </div>
                    <div className='main w-[98%] h-fit min-h-[5rem]'>
                    {
                      issues.length > 0 &&
                      issues.map(item => (
                        <TaskItemComponent key={v4()} project={project} issue={item} />            
                      ))
                    }
                      <CreateComponent project={project} createWhat={"issues"} />
                    </div>
                  </div>
                </div>            
              </div>
            </div>
        </div>
        </div>
        </div>
    )
}

export default ContainerBacklog