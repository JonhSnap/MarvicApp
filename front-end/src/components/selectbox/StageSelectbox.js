import React from 'react'
import { v4 } from 'uuid';
import { useListIssueContext } from '../../contexts/listIssueContext';
import { useStageContext } from '../../contexts/stageContext'
import { fetchIssue, updateIssues } from '../../reducers/listIssueReducer';
import createToast from '../../util/createToast';
import SelectBoxBase from './SelectBoxBase'

function StageSelectbox({ onClose, bodyStyle, stage, issue, project }) {
    const [{ stages }] = useStageContext();
    const [, dispatch] = useListIssueContext();

    // handle chooose stage
    const handleChooseStage = async (idStage) => {
        const dataPut = { ...issue };
        dataPut.id_Stage = idStage;
        await updateIssues(dataPut, dispatch);
        await fetchIssue(project.id, dispatch);
        createToast('success', 'Update stage successfully!');
    }

    return (
        <SelectBoxBase
            onClose={onClose}
            bodyStyle={bodyStyle}
        >
            <div className='flex flex-col rounded shadow-md bg-white'>
                {
                    stages.map(item => {
                        return (
                            item.id !== stage.id ?
                                <div onClick={() => handleChooseStage(item.id)} key={v4()} className='px-3 py-2 hover:bg-gray-main cursor-pointer'>{item.stage_Name}</div> :
                                null
                        )
                    })
                }
            </div>
        </SelectBoxBase>
    )
}

export default StageSelectbox