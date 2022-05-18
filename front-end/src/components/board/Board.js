import React from 'react'
import { v4 } from 'uuid';
import sorter from '../../util/sorter';
import './Board.scss'
import Column from './Column'
import { useStageContext } from '../../contexts/stageContext'
import { Container, Draggable } from 'react-smooth-dnd'
import { updateStage } from '../../reducers/stageReducer';

function Board({ board, project }) {
    const [, dispatch] = useStageContext();
    const { listStageOrder, listStage } = board;
    sorter(listStage, listStageOrder);

    // handle column drop
    const handleColumnDrop = (dropResult) => {
        const { addedIndex, removedIndex } = dropResult;
        const StageAdded = { ...listStage[addedIndex] };
        const StageRemove = { ...listStage[removedIndex] };
        if (StageAdded) {
            StageAdded.order = removedIndex;
            StageAdded.Stage_Name = StageAdded.stage_Name
        }
        if (StageRemove) {
            StageRemove.order = addedIndex;
            StageRemove.Stage_Name = StageRemove.stage_Name
        }
        console.log('stage added ~ ', StageAdded);
        console.log('stage remove ~ ', StageRemove);
        updateStage(StageAdded.id, StageAdded, dispatch);
        updateStage(StageRemove.id, StageRemove, dispatch);
    }

    return (
        <div className='board'>
            <Container
                orientation="horizontal"
                dragHandleSelector=".header-selector"
                onDrop={handleColumnDrop}
                getChildPayload={index => listStage[index]}
                dragClass=""
                dropClass=""
                style={{
                    maxWidth: '100%',
                    display: 'flex',
                    alignItems: 'stretch'
                }}
                dropPlaceholder={{
                    animationDuration: 150,
                    showOnTop: true,
                    className: 'cards-drop-preview'
                }}
            >
                {
                    listStage.length > 0 &&
                    listStage.map(item => (
                        <Draggable
                            style={{ height: 'auto' }}
                            key={v4()}>
                            <Column stage={item} />
                        </Draggable>
                    ))
                }
            </Container>
        </div>
    )
}

export default Board