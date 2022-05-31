import React, { useEffect, useMemo } from 'react'
import { NIL, v4 } from 'uuid';
import { useBoardContext } from '../../contexts/boardContext';
import { useSprintContext } from '../../contexts/sprintContext';
import { useStageContext } from '../../contexts/stageContext';
import { CHANGE_FILTER_EPIC_BOARD } from '../../reducers/actions';
import { fetchBoard } from '../../reducers/boardReducer';
import { fetchSprint } from '../../reducers/sprintReducer';
import { fetchStage } from '../../reducers/stageReducer';
import { KEY_FILTER_EPIC } from '../../util/constants';
import Board from '../board/Board';
import TopDetailBoard from '../project-detail/TopDetailBoard';
import './ContainerBoard.scss'

function ContainerBoard({ project }) {
    const { state: { sprints }, dispatch } = useSprintContext();
    const [{ boards }, dispatchBoard] = useBoardContext();
    const [, dispatchStage] = useStageContext();

    const currentSprint = useMemo(() => {
        const result = sprints.find(item => item.is_Started === 1);
        return result;
    }, [sprints])
    const epicFilterStorage = localStorage.getItem(KEY_FILTER_EPIC);

    useEffect(() => {
        if (project && project.id) {
            fetchSprint(project?.id, dispatch);
        }
    }, [project, dispatch])
    useEffect(() => {
        if (currentSprint) {
            if (epicFilterStorage) {
                dispatchBoard({
                    type: CHANGE_FILTER_EPIC_BOARD,
                    payload: epicFilterStorage
                })
            }
            localStorage.removeItem(KEY_FILTER_EPIC);
            const dataGet = {
                idSprint: currentSprint.id,
                idEpic: null,
                type: 0
            }
            fetchBoard(dataGet, dispatchBoard);
        }
    }, [currentSprint, dispatchBoard, epicFilterStorage])
    useEffect(() => {
        if (project && project.id) {
            fetchStage(project.id, dispatchStage);
        }
    }, [project, dispatchStage])

    return (
        <div className='container'>
            <TopDetailBoard currentSprint={currentSprint} project={project} />
            <div className="bottom have-y-scroll">
                {
                    boards.length > 0 &&
                    boards.map((item) => (
                        <Board key={v4()} board={item} currentSprint={currentSprint} project={project} />
                    ))
                }
            </div>
        </div>
    )
}

export default ContainerBoard