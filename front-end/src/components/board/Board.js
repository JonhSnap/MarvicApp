import React, { useEffect } from 'react'
import { v4 } from 'uuid';
import axios from 'axios';
import sorter from '../../util/sorter';
import './Board.scss'
import Column from './Column'
// import { useStageContext } from '../../contexts/stageContext'
import { Container, Draggable } from 'react-smooth-dnd'
// import { fetchStage, updateStage } from '../../reducers/stageReducer';
// import { useSelector } from 'react-redux'
import { fetchBoard } from '../../reducers/boardReducer';
import { useBoardContext } from '../../contexts/boardContext';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import { BASE_URL } from '../../util/constants'

function Board({ board, project, currentSprint }) {
    // const { currentUser } = useSelector(state => state.auth.login)
    // const [, dispatch] = useStageContext();
    const [, dispatchBoard] = useBoardContext();
    const { listStageOrder, listStage } = board;
    sorter(listStage, listStageOrder);


    // handle column drop
    const handleColumnDrop = async (dropResult) => {
        const { addedIndex, removedIndex } = dropResult;
        if (addedIndex !== null && removedIndex !== null) {
            try {
                axios.post(`${BASE_URL}/api/Stages/draganddrop`, {
                    currentPos: removedIndex,
                    newPos: addedIndex,
                    id_Project: project.id
                });
            } catch (error) {
                console.log(error);
            }
        }
        // const StageAdded = { ...listStage[removedIndex] };
        // const StageRemove = { ...listStage[addedIndex] };
        // let stageUpdateAdded = {};
        // let stageUpdateRemoved = {};
        // if (StageAdded) {
        //     stageUpdateAdded.stage_Name = StageAdded?.stage_Name;
        //     stageUpdateAdded.id_Updator = currentUser?.id;
        //     stageUpdateAdded.order = StageRemove?.order;
        // }
        // if (StageRemove) {
        //     stageUpdateRemoved.stage_Name = StageRemove?.stage_Name;
        //     stageUpdateRemoved.id_Updator = currentUser?.id;
        //     stageUpdateRemoved.order = StageAdded?.order;

        // }
        // await updateStage(StageAdded.id, stageUpdateAdded, dispatch);
        // await updateStage(StageRemove.id, stageUpdateRemoved, dispatch);
        // await fetchStage(project.id, dispatch);
        // fetchBoard({
        //     idSprint: currentSprint.id,
        //     idEpic: null,
        //     type: 0
        // }, dispatchBoard);
    }
    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:5001/hubs/marvic')
            .configureLogging(LogLevel.Information)
            .build();
        console.log("create connection....")
        connection
            .start()
            .then((res) => {
                console.log("connection....")
                connection.on("Stagsse", () => {
                    fetchBoard({
                        idSprint: currentSprint.id,
                        idEpic: null,
                        type: 0
                    }, dispatchBoard);
                });
            })
            .catch((e) => console.log("Connecttion faild", e));
    }, [])

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
                            key={v4()}
                            style={{ height: 'auto' }}
                        >
                            <Column currentSprint={currentSprint} stage={item} />
                        </Draggable>
                    ))
                }
            </Container>
        </div>
    )
}

export default Board