import React from 'react'
import './Column.scss'
import Issue from './Issue'
import { v4 } from 'uuid'
import { Container, Draggable } from 'react-smooth-dnd'
import sorter from '../../util/sorter'

function Column({ stage }) {
    const { listIssue, listIssueOrder } = stage;
    sorter(listIssue, listIssueOrder);


    // handle issue drop
    const handleIssueDrop = (dropResult) => {
        const { addedIndex, payload } = dropResult;
        if (addedIndex !== null) {
            // 2022-04-21 00:00:00.0000000
            // 2022-09-21 00:00:00.0000000
        }
    }


    return (
        <div className='column'>
            <div className="header header-selector">{stage.stage_Name}</div>
            <div className="container-issue">
                <Container
                    orientation="vertical"
                    onDrop={handleIssueDrop}
                    getChildPayload={index => listIssue[index]}
                    groupName='column'
                    dragClass=""
                    dropClass=""
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