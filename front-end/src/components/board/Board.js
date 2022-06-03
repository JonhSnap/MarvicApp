import React, { useRef } from 'react'
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
    const iconRef = useRef();
    const [, dispatchBoard] = useBoardContext();
    const { listStageOrder, listStage } = board;
    sorter(listStage, listStageOrder);

    // handle refresh
    const handleRefresh = () => {
        iconRef.current.animate(
            [
                { transform: 'rotate(0)', color: '#009B77' },
                { transform: 'rotate(360deg)', color: '#009B77' }
            ],
            {
                duration: 500,
                iterations: 3,
                endDelay: 100,
            }
        )
        setTimeout(() => {
            fetchBoard({
                idSprint: currentSprint.id,
                idEpic: null,
                type: 0
            }, dispatchBoard);
        }, 1600);
    }
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
            <div onClick={handleRefresh} className="refresh">
                <span title='Refresh' ref={iconRef} className='icon'>
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                        <path strokeLinecap="round" strokeLinejoin="round" d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
                    </svg>
                </span>
            </div>
            <Container
                orientation="horizontal"
                dragHandleSelector=".header-selector"
                onDrop={handleColumnDrop}
                getChildPayload={index => listStage[index]}
                dragClass=""
                dropClass=""
                style={{
                    width: 'auto',
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
            <div className="add-column">
                <img src="https://tse4.mm.bing.net/th?id=OIP.XVkE9uAqQTvg9O1wAjLxDwHaDt&pid=Api&P=0&w=406&h=203" alt="" />
            </div>
        </div>
    )
}

export default Board