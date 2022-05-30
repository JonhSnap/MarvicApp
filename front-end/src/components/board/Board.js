import React from 'react'
import { v4 } from 'uuid';
import axios from 'axios';
import sorter from '../../util/sorter';
import './Board.scss'
import Column from './Column'
import { Container, Draggable } from 'react-smooth-dnd'
import { fetchBoard } from '../../reducers/boardReducer';
import { useBoardContext } from '../../contexts/boardContext';
import { BASE_URL } from '../../util/constants'


function Board({ board, project, currentSprint }) {
    const [, dispatchBoard] = useBoardContext();
    const { listStageOrder, listStage } = board;
    sorter(listStage, listStageOrder);

    // handle column drop
    const handleColumnDrop = async (dropResult) => {
        const { addedIndex, removedIndex } = dropResult;
        if (addedIndex !== null && removedIndex !== null) {
            try {
                const resp = await axios.post(`${BASE_URL}/api/Stages/draganddrop`, {
                    currentPos: removedIndex,
                    newPos: addedIndex,
                    id_Project: project.id
                });
                if (resp.status === 200) {
                    fetchBoard({
                        idSprint: currentSprint.id,
                        idEpic: null,
                        type: 0
                    }, dispatchBoard);
                }
            } catch (error) {
                console.log(error);
            }
        }
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
                            <Column currentSprint={currentSprint} stage={item} />
                        </Draggable>
                    ))
                }
            </Container>
        </div>
    )
}

export default Board