import React, { useEffect, useMemo } from 'react'
import { v4 } from 'uuid';
import { useBoardContext } from '../../contexts/boardContext';
import { useSprintContext } from '../../contexts/sprintContext';
import { useStageContext } from '../../contexts/stageContext';
import { fetchBoard } from '../../reducers/boardReducer';
import { fetchSprint } from '../../reducers/sprintReducer';
import { fetchStage } from '../../reducers/stageReducer';
import Board from '../board/Board';
import TopDetail from '../project-detail/TopDetail';
import './ContainerBoard.scss'

function ContainerBoard({ project }) {
    const { state: { sprints }, dispatch } = useSprintContext();
    const [{ boards }, dispatchBoard] = useBoardContext();
    const [, dispatchStage] = useStageContext();

    const currentSprint = useMemo(() => {
        const result = sprints.find(item => item.is_Started === 1);
        return result;
    }, [sprints])

    useEffect(() => {
        if (project && project.id) {
            fetchSprint(project?.id, dispatch);
        }
    }, [project, dispatch])
    useEffect(() => {
        if (currentSprint) {
            fetchBoard(currentSprint.id, dispatchBoard);
        }
    }, [currentSprint, dispatchBoard])
    useEffect(() => {
        if (project && project.id) {
            fetchStage(project.id, dispatchStage);
        }
    }, [project, dispatchStage])

    return (
        <div className='container'>
            <TopDetail project={project} />
            <div className="bottom have-y-scroll">
                {
                    boards.length > 0 &&
                    boards.map((item) => (
                        <Board key={v4()} board={item} project={project} />
                    ))
                }
            </div>
        </div>
    )
}

export default ContainerBoard