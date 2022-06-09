import React, { useEffect, useMemo } from 'react'
import TopDetail from '../project-detail/TopDetail'
import { NIL } from 'uuid'
import './ContainerBacklog.scss'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAngleDown } from '@fortawesome/free-solid-svg-icons'
import CreateComponent from '../CreateComponent'
import ButtonBacklogComponent from '../backlog/ButtonBacklogComponent'
import { useListIssueContext } from '../../contexts/listIssueContext';
import { fetchIssue } from '../../reducers/listIssueReducer';
import WrapperTask from '../backlog/WrapperTask';
import { useMembersContext } from '../../contexts/membersContext'
import WrapperSprint from '../sprint/WrapperSprint'
import Loading from "../../loading/Loading";
function ContainerBacklog({ project }) {
    const [{ issueNormals, pending }, dispatchIssue] = useListIssueContext();
    const { state: { members } } = useMembersContext();
    const issueNoSprint = useMemo(() => {
        return issueNormals.filter(item => item.id_Sprint === NIL)
    }, [issueNormals])

    // useEffect get issues
    useEffect(() => {
        if (project && Object.entries(project).length > 0) {
            fetchIssue(project.id, dispatchIssue);
        }
    }, [project])

    return (
        <div className='container relative'>
            <TopDetail project={project} />
            {pending ?
                <Loading></Loading> :
                <div className="bottom have-y-scroll">
                    <div className='wrap-backlog'>
                        <div className='main-backlog'>
                            <WrapperSprint members={members} project={project} />
                            <div data-id={NIL} className='backlog-item'>
                                <div className='header-backlog-item w-[98%] py-3 flex justify-between items-center'>
                                    <div className='header-right'>
                                        <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                                        <div className='name-sprint inline-block'>
                                            <span className='name font-medium pr-2'>Backlog</span>
                                        </div>
                                        <div className='create-day inline-block font-light pl-2'>
                                            {/* <span className='day pr-1'>19 Apr - 17 May</span> */}
                                            <span> ({issueNoSprint.length} issues) </span>
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
                                        <ButtonBacklogComponent project={project} text={"Create sprint"} />
                                    </div>
                                </div>
                                <div className='main w-[98%] h-fit min-h-[5rem]'>
                                    <WrapperTask members={members} project={project} issues={issueNoSprint}></WrapperTask>
                                    <CreateComponent project={project} createWhat={"issues"} />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>}
        </div>
    )
}

export default ContainerBacklog