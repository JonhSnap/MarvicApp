import React, { useEffect, useMemo } from 'react'
import '../board/Column.scss'
import { useBoardContext } from '../../contexts/boardContext';
import { useLabelContext } from '../../contexts/labelContext';
import { useSprintContext } from '../../contexts/sprintContext';
import { useStageContext } from '../../contexts/stageContext';
import { CHANGE_FILTER_EPIC_BOARD } from '../../reducers/actions';
import { fetchBoard } from '../../reducers/boardReducer';
import { fetchLabel } from '../../reducers/labelReducer';
import { fetchSprint } from '../../reducers/sprintReducer';
import { fetchStage } from '../../reducers/stageReducer';
import { KEY_FILTER_EPIC } from '../../util/constants';
import Board from '../board/Board';
import TopDetailBoard from '../project-detail/TopDetailBoard';
import './ContainerBoard.scss'
import { v4 } from 'uuid';

function ContainerBoard({ project }) {
    const { state: { sprints }, dispatch } = useSprintContext();
    const [{ boards }, dispatchBoard] = useBoardContext();
    const [{ stages }] = useStageContext();
    const [, dispatchStage] = useStageContext();
    const [, dispatchLabel] = useLabelContext();

    const currentSprint = useMemo(() => {
        const result = sprints.find(item => item.is_Started === 1);
        return result;
    }, [sprints])
    const epicFilterStorage = localStorage.getItem(KEY_FILTER_EPIC);

    useEffect(() => {
        if (project && project.id) {
            fetchSprint(project?.id, dispatch);
            fetchLabel(project.id, dispatchLabel);
        }
    }, [project, dispatch, dispatchLabel])
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
        <div className='container-board'>
            <TopDetailBoard currentSprint={currentSprint} project={project} />
            <div className="bottom have-y-scroll">
                {
                    boards.length > 0 &&
                    boards.map((item) => (
                        <Board key={v4()} board={item} currentSprint={currentSprint} project={project} />
                    ))
                }
                {
                    boards.length === 0 &&
                    <div className="flex w-full h-full gap-x-2">
                        {
                            stages.length > 0 &&
                            stages.map(item => (
                                <div key={item.id} className='column'>
                                    <div className="header header-selector">
                                        <span className='stage-name'>{item.stage_Name}</span>
                                    </div>
                                    <div className="container-issue">
                                    </div>
                                </div>
                            ))
                        }
                    </div>
                }
            </div>
        </div>
    )
}

export default ContainerBoard