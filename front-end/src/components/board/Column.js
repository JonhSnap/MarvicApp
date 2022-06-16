import React, { useRef, useState } from 'react'
import './Column.scss'
import Issue from './Issue'
import { v4 } from 'uuid'
import { Container, Draggable } from 'react-smooth-dnd'
import sorter from '../../util/sorter'
import { updateIssues } from '../../reducers/listIssueReducer'
import { useListIssueContext } from '../../contexts/listIssueContext'
import { fetchBoard } from '../../reducers/boardReducer'
import { useBoardContext } from '../../contexts/boardContext'
import InputStageName from './InputStageName'
import useModal from '../../hooks/useModal'
import ChooseStagePopup from '../popup/ChooseStagePopup'

function Column({ stage, currentSprint, project }) {
    const [showInput, setShowInput] = useState(false);
    const [showChooseStage, setShowChooseStage, handleCloseShooseStage] = useModal();
    const { listIssue, listIssueOrder } = stage;
    sorter(listIssue, listIssueOrder);
    const columnRef = useRef();
    const [, dispatchIssue] = useListIssueContext();
    const [, dispatchBoard] = useBoardContext();

    // handle issue drop
    const handleIssueDrop = async (dropResult) => {
        const { addedIndex, removedIndex, payload } = dropResult;
        if (addedIndex !== null && removedIndex !== null) {
            const issueRemoved = listIssue[addedIndex];
            const orderTemp = payload.order;
            payload.order = issueRemoved.order + 1;
            issueRemoved.order = orderTemp;
            await updateIssues(payload, dispatchIssue);
            await updateIssues(issueRemoved, dispatchIssue);
            fetchBoard({
                idSprint: currentSprint.id,
                idEpic: null,
                type: 0
            }, dispatchBoard);
            return;
        }

        if (addedIndex !== null && removedIndex === null) {
            const idStage = columnRef.current.dataset.id;
            if (idStage) {
                let preIssue, nextIssue;
                switch (addedIndex) {
                    case 0:
                        payload.order = 0;
                        if (listIssue.length > 0) {
                            nextIssue = listIssue[addedIndex];
                            nextIssue.order += 1;
                        }
                        break;
                    case listIssue.length:
                        let max = listIssue[0].order;
                        for (let i = 1; i < listIssue.length; i++) {
                            if (max < listIssue[i].order) {
                                max = listIssue[i].order
                            }
                        }
                        payload.order = ++max;
                        break;
                    default:
                        preIssue = listIssue[addedIndex - 1];
                        nextIssue = listIssue[addedIndex];
                        payload.order = preIssue.order + 1;
                        nextIssue.order += 1
                        break;
                }
                payload.id_Stage = idStage;
                await updateIssues(payload, dispatchIssue);
                if (nextIssue) {
                    await updateIssues(nextIssue, dispatchIssue);
                }
                fetchBoard({
                    idSprint: currentSprint.id,
                    idEpic: null,
                    type: 0
                }, dispatchBoard);
            }
        }
    }

    return (
        <>
            {
                showChooseStage &&
                <ChooseStagePopup project={project} currentSprint={currentSprint} currentStage={stage} onClose={handleCloseShooseStage} />
            }
            <div ref={columnRef} data-id={stage?.id} className='column'>
                <div className="header header-selector">
                    {
                        showInput ?
                            <InputStageName currentSprint={currentSprint} stage={stage} setShowInput={setShowInput} /> :
                            <span onClick={() => setShowInput(true)} className='stage-name'>{stage.stage_Name}</span>
                    }
                    <span onClick={() => setShowChooseStage(true)} title='Remove Stage' className='remove-icon'>
                        <svg className='pointer-events-none' xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                            <path fillRule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clipRule="evenodd" />
                        </svg>
                    </span>
                </div>
                <div className="container-issue">
                    <Container
                        orientation="vertical"
                        onDrop={handleIssueDrop}
                        getChildPayload={index => listIssue[index]}
                        groupName='column'
                        dragClass="card-ghost"
                        dropClass="card-ghost-drop"
                        dropPlaceholder={{
                            animationDuration: 150,
                            showOnTop: true,
                            className: 'cards-drop-preview'
                        }}
                    >
                        {
                            listIssue.length > 0 &&
                            listIssue.map(item => (
                                <Draggable key={v4()}>
                                    <Issue issue={item} />
                                </Draggable>
                            ))
                        }
                    </Container>
                </div>
            </div>
        </>
    )
}

export default Column