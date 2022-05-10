import { faAngleDown } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { useMemo } from 'react'
import { useListIssueContext } from '../../contexts/listIssueContext'
import useModal from '../../hooks/useModal'
import WrapperTask from '../backlog/WrapperTask'
import CreateIssuesComponent from '../CreateComponent'
import OptionComponent from '../option/OptionComponent'
import OptionHeaderBacklogComponent from '../option/OptionHeaderBacklogComponent'
import EditSprintPopup from '../popup/EditSprintPopup'

function Sprint({ sprint, members, project, index }) {
    const [showEditSprint, setShowEditSprint, handleCloseEditSprint] = useModal();
    const [{ issueNormals }, dispatch] = useListIssueContext();
    const issueWithSprint = useMemo(() => {
        return issueNormals.filter(item => item.id_Sprint === sprint.id);
    }, [issueNormals])

    // handle start sprint
    const handleStartSprint = () => {

    }

    return (
        <>
            {showEditSprint && <EditSprintPopup project={project} onClose={handleCloseEditSprint} setshow={setShowEditSprint} sprint={sprint} />}
            <div className='backlog-item'>
                <div className='header-backlog-item w-[98%] py-3 flex justify-between items-center'>
                    <div className='header-right'>
                        <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={faAngleDown} />
                        <div className='name-sprint inline-block'>
                            <span className='name font-medium pr-2'>{sprint?.sprintName}</span>
                        </div>
                        <div className='create-day inline-block font-light pl-2'>
                            <span>({issueWithSprint.length} issues)</span>
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
                        <div
                            onClick={handleStartSprint}
                            className={`rounded-md py-1 px-2  w-fit h-full mx-4 border-solid cursor-pointer
                        bg-primary text-white ${index !== 0 ? 'pointer-events-none bg-opacity-30' : ''}`}>Start Sprint</div>
                        <OptionComponent child={<OptionHeaderBacklogComponent setShowEditSprint={setShowEditSprint} sprint={sprint} project={project} />} />
                    </div>
                </div>
                <div className='main w-[98%] h-fit min-h-[5rem]'>
                    <WrapperTask members={members} project={project} issues={issueWithSprint}></WrapperTask>
                    <CreateIssuesComponent idSprint={sprint.id} project={project} createWhat={"issues"} />
                </div>
            </div>
        </>
    )
}

export default Sprint