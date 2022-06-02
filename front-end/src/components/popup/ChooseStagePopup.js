import React, { memo } from 'react'
import { useStageContext } from '../../contexts/stageContext'
import { useBoardContext } from '../../contexts/boardContext'
import { fetchBoard } from '../../reducers/boardReducer';
import { deleteStage, fetchStage } from '../../reducers/stageReducer';
import ModalBase from '../modal/ModalBase'

function ChooseStagePopup({ onClose, currentStage, project, currentSprint }) {
    const [{ stages }, dispatchStage] = useStageContext();
    const [, dispatchBoard] = useBoardContext();

    // handle remove stage
    const handleRemoveStage = async (stage) => {
        const dataDelete = { dorward_Id_Stage: stage.id }
        await deleteStage(currentStage.id, dataDelete, dispatchStage);
        await fetchStage(project.id, dispatchStage);
        fetchBoard({
            idSprint: currentSprint.id,
            idEpic: null,
            type: 0
        }, dispatchBoard);
    }

    return (
        <ModalBase
            containerclassName='fixed inset-0 z-10 flex items-center justify-center'
            bodyClassname='relative content-modal'
            onClose={onClose}
        >
            <div className='w-fit min-w-[400px] p-4 rounded-md bg-white'>
                <h2 className='text-center text-[18px] font-bold text-primary py-2'>SELECT STAGE</h2>
                <p className='text-center text-sm italic text-primary mb-5'>Select stage to contain current issue</p>
                <div className='stages flex flex-wrap items-center justify-center -mx-2'>
                    {
                        stages.length > 0 &&
                        stages.map(item => {
                            return item.id !== currentStage.id ?
                                (
                                    <div onClick={() => handleRemoveStage(item)} key={item.id} className="stage w-[33.3333%] p-2">
                                        <p className='cursor-pointer uppercase flex items-center justify-center
                                        rounded w-full p-3 bg-gray-main hover:bg-gray-300 transition-all
                                        font-semibold'>{item.stage_Name}</p>
                                    </div>
                                ) :
                                null
                        })
                    }
                </div>
            </div>
        </ModalBase>
    )
}

export default memo(ChooseStagePopup)