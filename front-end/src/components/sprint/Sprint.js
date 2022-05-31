import { faAngleDown, faAngleUp } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { useMemo, useRef, useState } from 'react'
import { useListIssueContext } from '../../contexts/listIssueContext'
import useModal from '../../hooks/useModal'
import WrapperTask from '../backlog/WrapperTask'
import CreateIssuesComponent from '../CreateComponent'
import EditSprintPopup from '../popup/EditSprintPopup'
import OptionSprint from '../option/OptionSprint'
import { useSprintContext } from '../../contexts/sprintContext'
import StartSprintPopup from '../popup/StartSprintPopup'
import { useStageContext } from '../../contexts/stageContext'
import { completeSprint, fetchSprint } from '../../reducers/sprintReducer'
import { NIL } from 'uuid'
import SprintSelectbox from '../selectbox/SprintSelectbox'
import { documentHeight } from '../../util/constants'
import { fetchIssue } from '../../reducers/listIssueReducer'

const secondThirdScreen = documentHeight * 2 / 3;

function Sprint({ sprint, members, project }) {
    const [showWrapperTask, setShowWrapperTask] = useState(true);
    const [coord, setCoord] = useState({});
    const [showSprintSelectBox, setShowSprintSelectBox, handleCloseSprintSelectBox] = useModal();
    const [showEditSprint, setShowEditSprint, handleCloseEditSprint] = useModal();
    const [showStartSprint, setShowStartSprint, handleCloseStartSprint] = useModal();
    const { state: { sprints }, dispatch } = useSprintContext()
    const [{ issueNormals }, dispatchIssue] = useListIssueContext();
    const [{ stages }] = useStageContext();
    const completeSprintRef = useRef();
    const issueWithSprint = useMemo(() => {
        return issueNormals.filter(item => item.id_Sprint === sprint.id);
    }, [issueNormals])
    // check sprint starting
    const checkPrintStarting = useMemo(() => {
        return sprints.some(item => item.is_Started === 1);
    }, [sprints]);
    // orther sprint
    const otherSprint = useMemo(() => {
        return sprints.filter(item => item.id !== sprint.id);
    }, [sprints])

    // handle complete sprint
    const handleCompleteSprint = async () => {
        const stageDone = stages.find(item => item.isDone === 1);
        const issuesNotDone = issueWithSprint.filter(item => item.id_Stage !== stageDone.id);
        if (issuesNotDone && issuesNotDone.length > 0) {
            const bounding = completeSprintRef.current.getBoundingClientRect();
            if (bounding) {
                setCoord(bounding);
                setShowSprintSelectBox(true);
            }
        } else {
            const dataPost = {
                "currentProjectId": project.id,
                "currentSprintId": sprint.id,
                "newSprintId": NIL
            }
            await completeSprint(dataPost, dispatch);
            await fetchSprint(project.id, dispatch);
            fetchIssue(project.id, dispatchIssue);
        }
    }

    return (
        <>
            {showSprintSelectBox &&
                <SprintSelectbox
                    onClose={handleCloseSprintSelectBox}
                    bodyStyle={{
                        top: coord.bottom <= secondThirdScreen ? coord.bottom : null,
                        left: coord.left,
                        bottom: !(coord.bottom <= secondThirdScreen) ? (documentHeight - coord.top) : null
                    }}
                    project={project}
                    sprint={sprint}
                    listSprint={otherSprint}
                />
            }
            {showStartSprint && <StartSprintPopup project={project} onClose={handleCloseStartSprint} setshow={setShowStartSprint} sprint={sprint}></StartSprintPopup>}
            {showEditSprint && <EditSprintPopup project={project} onClose={handleCloseEditSprint} setshow={setShowEditSprint} sprint={sprint} />}
            <div data-id={sprint?.id} className='backlog-item'>
                <div className='header-backlog-item w-[98%] py-3 flex justify-between items-center'>
                    <div className='header-right'>
                        <span onClick={() => setShowWrapperTask(prev => !prev)} className='cursor-pointer'>
                            <FontAwesomeIcon size='1x' className='px-2 inline-block' icon={showWrapperTask ? faAngleDown : faAngleUp} />
                        </span>
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
                        {
                            sprint.is_Started ?
                                (
                                    <div
                                        ref={completeSprintRef}
                                        onClick={handleCompleteSprint}
                                        className={`rounded-md py-1 px-2  w-fit h-full mx-4 border-solid cursor-pointer
                        bg-primary text-white `}>Complete Sprint</div>
                                ) :
                                (
                                    <div
                                        onClick={() => setShowStartSprint(true)}
                                        className={`rounded-md py-1 px-2  w-fit h-full mx-4 border-solid cursor-pointer
                        bg-primary text-white ${(checkPrintStarting) ? 'pointer-events-none opacity-50' : ''}`}>Start Sprint</div>
                                )
                        }
                        <OptionSprint setShowEditSprint={setShowEditSprint} sprint={sprint} project={project} />
                    </div>
                </div>
                <div className='main w-[98%] h-fit min-h-[5rem]'>
                    {
                        showWrapperTask &&
                        <WrapperTask members={members} project={project} issues={issueWithSprint}></WrapperTask>
                    }
                    <CreateIssuesComponent idSprint={sprint.id} project={project} createWhat={"issues"} />
                </div>
            </div>
        </>
    )
}

export default Sprint