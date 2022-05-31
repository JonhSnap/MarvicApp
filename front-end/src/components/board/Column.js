import React, { useRef } from 'react'
import './Column.scss'
import Issue from './Issue'
import { v4 } from 'uuid'
import { Container, Draggable } from 'react-smooth-dnd'
import sorter from '../../util/sorter'
import { updateIssues } from '../../reducers/listIssueReducer'
import { useListIssueContext } from '../../contexts/listIssueContext'
import { fetchBoard } from '../../reducers/boardReducer'
import { useBoardContext } from '../../contexts/boardContext'

function Column({ stage, currentSprint }) {
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
        <div ref={columnRef} data-id={stage?.id} className='column'>
            <div className="header header-selector">{stage.stage_Name}</div>
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
    )
}

export default Column